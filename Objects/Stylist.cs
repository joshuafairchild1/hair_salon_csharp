using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HairSalon.Objects
{
  public class Stylist
  {
    private string _name;
    private string _telephone;
    private int _id;

    public Stylist(string name, string telephone, int id = 0)
    {
      _name = name;
      _telephone = telephone;
      _id = id;
    }

    public int GetId()
    {
      return _id;
    }
    public void SetId(int newId)
    {
      _id = newId;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    public string GetTelephone()
    {
      return _telephone;
    }
    public void SetTelephone(string newTelephone)
    {
      _telephone = newTelephone;
    }

    public override bool Equals(System.Object otherStylist)
    {
      if(!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = this.GetId() == newStylist.GetId();
        bool nameEquality = this.GetName() == newStylist.GetName();
        bool telephoneEquality = this.GetTelephone() == newStylist.GetTelephone();
        return (idEquality && nameEquality && telephoneEquality);
      }
    }

    public static List<Stylist> GetAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM stylists", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      List<Stylist> allStylists = new List<Stylist>{};
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string telephone = rdr.GetString(2);
        Stylist newStylist = new Stylist(name, telephone, id);
        allStylists.Add(newStylist);
      }

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return allStylists;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO stylists (name, telephone) OUTPUT INSERTED.id VALUES (@StylistName, @StylistTelephone);", conn);
      SqlParameter nameParam = new SqlParameter("@StylistName", this.GetName());
      SqlParameter telephoneParam = new SqlParameter("@StylistTelephone", this.GetTelephone());
      cmd.Parameters.Add(nameParam);
      cmd.Parameters.Add(telephoneParam);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM stylists; DELETE FROM clients;", conn);
      cmd.ExecuteNonQuery();

      if(conn != null)
      {
        conn.Close();
      }
    }

    public static Stylist Find(int idToFind)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM stylists WHERE id = @StylistId;", conn);
      SqlParameter idParam = new SqlParameter("@StylistId", idToFind);
      cmd.Parameters.Add(idParam);

      SqlDataReader rdr = cmd.ExecuteReader();


      string name = null;
      string telephone = null;
      int id = 0;

      while(rdr.Read())
      {
        id = rdr.GetInt32(0);
        name = rdr.GetString(1);
        telephone = rdr.GetString(2);
      }
      Stylist foundStylist = new Stylist(name, telephone, id);

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }

      return foundStylist;
    }

    public void DeleteClients()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM clients WHERE stylist_id = @StylistId;", conn);

      SqlParameter idParam = new SqlParameter("@StylistId", this.GetId());
      cmd.Parameters.Add(idParam);

      cmd.ExecuteNonQuery();
      if(conn != null)
      {
        conn.Close();
      }
    }

    public List<Client> GetClients()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE stylist_id = @StylistId;", conn);
      SqlParameter idParam = new SqlParameter("@StylistId", this.GetId());
      cmd.Parameters.Add(idParam);
      SqlDataReader rdr = cmd.ExecuteReader();

      List<Client> allClients = new List<Client>{};
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string telephone = rdr.GetString(2);
        int stylistId = rdr.GetInt32(3);
        Client newClient = new Client(name, telephone, stylistId, id);
        allClients.Add(newClient);
      }

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }

      return allClients;
    }

    public void DeleteClient(Client toDelete)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM clients WHERE id = @ClientId;", conn);
      SqlParameter idParam = new SqlParameter("@ClientId", toDelete.GetId());
      cmd.Parameters.Add(idParam);
      cmd.ExecuteNonQuery();
      if(conn != null)
      {
        conn.Close();
      }
    }

    public void Update(string name, string telephone)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE stylists SET name = @StylistName, telephone = @StylistTelephone OUTPUT INSERTED.name, INSERTED.telephone WHERE id = @StylistId;", conn);

      SqlParameter nameParam = new SqlParameter("@StylistName", name);
      SqlParameter telephoneParam = new SqlParameter("@StylistTelephone", telephone);
      SqlParameter idParam = new SqlParameter("@StylistId", this.GetId());

      cmd.Parameters.Add(nameParam);
      cmd.Parameters.Add(telephoneParam);
      cmd.Parameters.Add(idParam);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._name = rdr.GetString(0);
        this._telephone = rdr.GetString(1);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }

    public void Delete()
    {

    }
  }
}
