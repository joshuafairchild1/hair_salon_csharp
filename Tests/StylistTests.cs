using Xunit;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HairSalon;

namespace HairSalon.Objects
{
  [Collection("HairSalon")]

  public class StylistTests : IDisposable
  {
    public StylistTests()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Stylist_DatabaseEmptyAtFirst()
    {
      List<Stylist> controlList = new List<Stylist>{};
      List<Stylist> allStylists = Stylist.GetAll();

      Assert.Equal(controlList, allStylists);
    }

    [Fact]
    public void Stylist_Equals_ReturnTrueWhenEqual()
    {
      Stylist stylist1 = new Stylist("John Smith", "(123)-456-7890");
      Stylist stylist2 = new Stylist("John Smith", "(123)-456-7890");

      Assert.Equal(stylist1, stylist2);
    }

    [Fact]
    public void Stylist_Save_SavesObjToDB()
    {
      Stylist newStylist = new Stylist("John Smith", "(123)-456-7890");
      newStylist.Save();

      Stylist savedStylist = Stylist.GetAll()[0];

      Assert.Equal(newStylist, savedStylist);
    }

    [Fact]
    public void Stylist_DeleteAll_RemovesAllStylistFromDB()
    {
      Stylist newStylist = new Stylist("John Smith", "(123)-456-7890");
      newStylist.Save();

      Stylist.DeleteAll();
      List<Stylist> controlList = new List<Stylist>{};
      List<Stylist> testList = Stylist.GetAll();

      Assert.Equal(controlList, testList);
    }

    [Fact]
    public void Stylist_Find_ReturnsStylistFromDB()
    {
      Stylist newStylist = new Stylist("John Smith", "(123)-456-7890");
      newStylist.Save();
      Stylist foundStylist = Stylist.Find(newStylist.GetId());
      Assert.Equal(newStylist, foundStylist);
    }

    [Fact]
    public void Stylist_DeleteClients_DeletesAllStylistsClients()
     {
      Stylist newStylist = new Stylist("John Smith", "(123)-456-7890");
      newStylist.Save();
      Client client1 = new Client("Tom Smith", "(555)-123-4567", newStylist.GetId());
      client1.Save();
      Client client2 = new Client("Billy Bob", "(123)-098-7654", newStylist.GetId());
      client2.Save();

      newStylist.DeleteClients();

      List<Client> controlList = new List<Client>{};
      List<Client> testList = newStylist.GetClients();

      Assert.Equal(controlList, testList);
    }

    [Fact]
    public void Stylist_GetClients_GetsClientsByStylist()
    {
      Stylist newStylist = new Stylist("John Smith", "(123)-456-7890");
      newStylist.Save();

      Client client1 = new Client("Tom Smith", "(555)-123-4567", newStylist.GetId());
      client1.Save();
      Client client2 = new Client("Billy Bob", "(123)-098-7654", newStylist.GetId());
      client2.Save();


      List<Client> controlList = new List<Client>{client1, client2};
      List<Client> testList = newStylist.GetClients();

      Assert.Equal(controlList, testList);
    }

    [Fact]
    public void Stylist_DeleteClient_DeletesASingleClient()
    {
      Stylist newStylist = new Stylist("John Smith", "(123)-456-7890");
      newStylist.Save();

      Client client1 = new Client("Tom Smith", "(555)-123-4567", newStylist.GetId());
      client1.Save();
      Client client2 = new Client("Billy Bob", "(123)-098-7654", newStylist.GetId());
      client2.Save();

      newStylist.DeleteClient(client1);
      List<Client> controlList = new List<Client>{client2};
      List<Client> testList = newStylist.GetClients();

      Assert.Equal(controlList, testList);
    }

    [Fact]
    public void Stylist_Update_UpdatesName()
    {
      Stylist newStylist = new Stylist("John Smith", "(123)-456-7890");
      newStylist.Save();

      newStylist.Update("John Locke", "(481)-347-1234");

      Assert.Equal("John Locke", newStylist.GetName());
    }

    [Fact]
    public void Stylist_Update_UpdatesTelephone()
    {
      Stylist newStylist = new Stylist("John Smith", "(123)-456-7890");
      newStylist.Save();

      newStylist.Update("John Locke", "(481)-347-1234");

      Assert.Equal("(481)-347-1234", newStylist.GetTelephone());
    }

    [Fact]
    public void Stylist_Delete_DeletesSingleStylist()
    {
      Stylist stylist1 = new Stylist("John Smith", "(123)-456-7890");
      stylist1.Save();
      Stylist stylist2 = new Stylist("Smith John", "(555)-342-5444");
      stylist2.Save();

      stylist1.Delete();

      List<Stylist> controlList = new List<Stylist>{stylist2};
      List<Stylist> testList = Stylist.GetAll();

      Assert.Equal(controlList, testList);
    }

    [Fact]
    public void Stylist_SearchByName_ReturnsMatches()
    {
      Stylist stylist1 = new Stylist("JOHN SMITH", "(123)-456-7890");
      stylist1.Save();
      Stylist stylist2 = new Stylist("john smith", "(123)-456-7890");
      stylist2.Save();
      Stylist stylist3 = new Stylist("Jon Hamm", "(123)-456-7890");
      stylist3.Save();

      List<Stylist> controlList = new List<Stylist>{stylist1, stylist2};
      List<Stylist> matches = Stylist.SearchByName("John Smith");

      Assert.Equal(controlList, matches);
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}


// System.Console.WriteLine($"Real: {newStylist.GetName()}, {newStylist.GetTelephone()}, {newStylist.GetId()}");
// System.Console.WriteLine($"Found: {foundStylist.GetName()}, {foundStylist.GetTelephone()}, {foundStylist.GetId()}");
