using Nancy;
using Nancy.ViewEngines.Razor;
using HairSalon.Objects;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace HairSalon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };
      Get["/stylists/new"] = _ => {
        return View["form.cshtml"];
      };
    }
  }
}
