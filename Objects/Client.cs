using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HairSalon.Objects
{
  public class Client
  {
    private string _name;
    private string _telephone;
    private int _id;
    private int _stylistId;


    public Client(string name, string telephone, int stylistId, int id = 0)
    {
      _name = name;
      _telephone = telephone;
      _id = id;
      _stylistId = stylistId;
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
    public int GetStylistId()
    {
      return _stylistId;
    }
    public void SetStylistId(int newStylistId)
    {
      _stylistId = newStylistId;
    }

    public static List<Client> GetAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients", conn);
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
  }
}
