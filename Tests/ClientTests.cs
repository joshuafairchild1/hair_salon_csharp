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


    public void Dispose()
    {

    }
  }
}
