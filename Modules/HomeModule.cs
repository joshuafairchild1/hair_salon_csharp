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
        Dictionary<string, object> model = new Dictionary<string, object>{};
        string formType = Request.Query["form-type"];
        model.Add("form-type", formType);
        return View["form.cshtml", model];
      };
      Post["/"] = _ => {
        Stylist newStylist = new Stylist(Request.Form["stylist-name"], Request.Form["stylist-telephone"]);
        newStylist.Save();
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };
      Get["/stylists/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        Stylist selectedStylist = Stylist.Find(parameters.id);
        List<Client> selectedClients = selectedStylist.GetClients();
        model.Add("clients", selectedClients);
        model.Add("stylist", selectedStylist);
        return View["stylist.cshtml", model];
      };
      Get["/stylists/{id}/clients/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        Stylist selectedStylist = Stylist.Find(parameters.id);
        string formType = Request.Query["form-type"];
        model.Add("form-type", formType);
        model.Add("stylist", selectedStylist);
        return View["form.cshtml", model];
      };
      Post["/stylists/{id}/clients/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        Client newClient = new Client(Request.Form["client-name"], Request.Form["client-telephone"], parameters.id);
        newClient.Save();
        Stylist selectedStylist = Stylist.Find(parameters.id);
        List<Client> selectedClients = selectedStylist.GetClients();
        model.Add("clients", selectedClients);
        model.Add("stylist", selectedStylist);
        return View["stylist.cshtml", model];
      };
      Get["/stylists/delete"] = _ => {
        return View["stylists_delete_confirmation.cshtml"];
      };
      Delete["/"] = _ => {
        Stylist.DeleteAll();
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };
      Delete["/stylist/{id}/deleted"] = parameters => {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        selectedStylist.Delete();
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };
    }
  }
}
