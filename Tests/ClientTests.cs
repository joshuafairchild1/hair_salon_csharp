using Xunit;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HairSalon.Objects
{
  [Collection("HairSalon")]

  public class ClientTests : IDisposable
  {
    public ClientTests()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Client_DatabaseEmptyAtFirst()
    {
      List<Client> controlList = new List<Client>{};
      List<Client> allClients = Client.GetAll();

      Assert.Equal(controlList, allClients);
    }

    [Fact]
    public void Client_Equals_ReturnTrueWhenEqual()
    {
      Client client1 = new Client("Tom Smith", "(555)-123-4567", 1);
      Client client2 = new Client("Tom Smith", "(555)-123-4567", 1);

      Assert.Equal(client1, client2);
    }

    [Fact]
    public void Client_Save_SavesObjToDB()
    {
      Stylist newStylist = new Stylist("John Smith", "(123)-456-7890");
      newStylist.Save();
      Client newClient = new Client("Tom Smith", "(555)-123-4567", newStylist.GetId());
      newClient.Save();

      Client savedClient = Client.GetAll()[0];

      Assert.Equal(newClient, savedClient);
    }

    [Fact]
    public void Client_DeleteAll_RemovesAllClientsFromDB()
    {
      Client newClient = new Client("Tom Smith", "(555)-123-4567", 1);
      newClient.Save();

      Client.DeleteAll();
      List<Client> controlList = new List<Client>{};
      List<Client> testList = Client.GetAll();

      Assert.Equal(controlList, testList);
    }

    [Fact]
    public void Client_Find_ReturnsClientFromDB()
    {
      Client newClient = new Client("Tom Smith", "(555)-123-4567", 1);
      newClient.Save();
      Client foundClient = Client.Find(newClient.GetId());
      Assert.Equal(newClient, foundClient);
    }

    [Fact]
    public void Client_Update_UpdatesName()
    {
      Stylist newStylist = new Stylist("John Smith", "(123)-456-7890");
      newStylist.Save();

      Client newClient = new Client("Tom Smith", "(555)-123-4567", newStylist.GetId());
      newClient.Save();

      newClient.Update("John Locke", "(481)-347-1234");

      Assert.Equal("John Locke", newClient.GetName());
      Assert.Equal("(481)-347-1234", newClient.GetTelephone());
    }

    [Fact]
    public void Client_Update_UpdatesTelephone()
    {
      Stylist newStylist = new Stylist("John Smith", "(123)-456-7890");
      newStylist.Save();

      Client newClient = new Client("Tom Smith", "(555)-123-4567", newStylist.GetId());
      newClient.Save();

      newClient.Update("John Locke", "(481)-347-1234");

      Assert.Equal("(481)-347-1234", newClient.GetTelephone());
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}


// System.Console.WriteLine($"Real: {newClient.GetName()}, {newClient.GetTelephone()}, {newClient.GetId()}, stylist id: {newClient.GetStylistId()}");
// System.Console.WriteLine($"Found: {savedClient.GetName()}, {savedClient.GetTelephone()}, {savedClient.GetId()}, stylist id: {savedClient.GetStylistId()}");
