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

    public void Dispose()
    {

    }
  }
}
