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
      Client newClient = new Client("Tom Smith", "(555)-123-4567", 1);
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

    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
