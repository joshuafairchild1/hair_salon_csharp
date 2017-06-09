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
      Get["/stylists/delete"] = _ => {
        return View["stylists_delete_confirmation.cshtml"];
      };
      Get["/stylists/{stylistId}/clients/{clientId}/edit"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        string formType = Request.Query["form-type"];
        Stylist selectedStylist = Stylist.Find(parameters.stylistId);
        Client selectedClient = Client.Find(parameters.clientId);
        model.Add("form-type", formType);
        model.Add("client", selectedClient);
        model.Add("stylist", selectedStylist);
        return View["form.cshtml", model];
      };
      Get["/stylists/{stylistId}/edit"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        string formType = Request.Query["form-type"];
        Stylist selectedStylist = Stylist.Find(parameters.stylistId);
        model.Add("form-type", formType);
        model.Add("stylist", selectedStylist);
        return View["form.cshtml", model];
      };
      Post["/"] = _ => {
        Stylist newStylist = new Stylist(Request.Form["stylist-name"], Request.Form["stylist-telephone"]);
        newStylist.Save();
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
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
      Delete["/stylist/{id}/clients/deleted"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        Stylist selectedStylist = Stylist.Find(parameters.id);
        selectedStylist.DeleteClients();
        List<Client> selectedClients = selectedStylist.GetClients();
        model.Add("clients", selectedClients);
        model.Add("stylist", selectedStylist);
        return View["stylist.cshtml", model];
      };
      Delete["/stylists/{stylistId}/clients/{clientId}/delete"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        Client toDelete = Client.Find(parameters.clientId);
        Stylist selectedStylist = Stylist.Find(parameters.stylistId);
        selectedStylist.DeleteClient(toDelete);
        List<Client> selectedClients = selectedStylist.GetClients();
        model.Add("clients", selectedClients);
        model.Add("stylist", selectedStylist);
        return View["stylist.cshtml", model];
      };
      Patch["/stylists/{stylistId}/clients/{clientId}/edit"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        Stylist selectedStylist = Stylist.Find(parameters.stylistId);
        Client selectedClient = Client.Find(parameters.clientId);
        selectedClient.Update(Request.Form["client-name"], Request.Form["client-telephone"]);
        List<Client> selectedClients = selectedStylist.GetClients();
        model.Add("clients", selectedClients);
        model.Add("stylist", selectedStylist);
        return View["stylist.cshtml", model];
      };
      Patch["/stylists/{stylistId}/edit"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        Stylist selectedStylist = Stylist.Find(parameters.stylistId);
        selectedStylist.Update(Request.Form["stylist-name"], Request.Form["stylist-telephone"]);
        List<Client> selectedClients = selectedStylist.GetClients();
        model.Add("clients", selectedClients);
        model.Add("stylist", selectedStylist);
        return View["stylist.cshtml", model];
      };
    }
  }
}
