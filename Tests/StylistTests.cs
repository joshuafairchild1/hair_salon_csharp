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
    // public StylistTest()
    // {
    //   DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    // }

    [Fact]
    public void Stylist_DatabaseEmptyAtFirst()
    {
      List<Stylist> controlList = new List<Stylist>{};
      List<Stylist> allStylists = Stylist.GetAll();

      Assert.Equal(controlList, allStylists);
    }

    public void Dispose()
    {

    }
  }
}
