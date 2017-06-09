using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HairSalon.Objects
{
  public class Stylist
  {
    private string _name;
    string _telephone;
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

    }
  }
}
