using Cafeinator.Infra.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Cafeinator.DataAccess.DataServices
{
  public class DataService : IDataService
  {
    string baseUrl = "";
    string UserAPI ="";
    string DrinkAPI = "";

    public DataService()
    {
      baseUrl=ConfigurationManager.AppSettings["BaseUrl"];
      UserAPI= ConfigurationManager.AppSettings["UserAPI"];
      DrinkAPI= ConfigurationManager.AppSettings["DrinkAPI"];
    }

    public async Task<List<Drink>> GetDrinksAsync()
    {
      try
      {
        string resp = await sendGetRequestAsync(DrinkAPI);
        var drinks = JsonConvert.DeserializeObject<List<Drink>>(resp);
        return drinks;
      }
      catch (Exception ex)
      {
        //TODO: handle exception here
        throw ex;
      }
    }

    public async Task<Drink> GetUserLastChoiceAsync(User user)
    {
      try
      {
        string resp = await sendGetRequestAsync(DrinkAPI + "?usrID=" + user.UsrID);
        var drink = JsonConvert.DeserializeObject<Drink>(resp);
        return drink;
      }
      catch (Exception ex)
      {
        //TODO: handle exception here
        throw ex;
      }
    }

    public async Task<int> SaveLastUserDrinkAsync(Drink drink, int userID)
    {
      try
      {
        var result = await sendPostRequestAsync<Menu>(DrinkAPI, new Menu { Drink = drink, UsrID = userID });
        int Nline = JsonConvert.DeserializeObject<int>(result);
        return Nline;
      }
      catch (Exception ex)
      {
        //TODO: handle exception here

        throw ex;
      }
    }

    public async Task<int> DeleteMenuAsync(int id)
    {
      try
      {
        string url = DrinkAPI + "/" + id;
        return await DeleteRequestAsync(url);
      }
      catch (Exception ex)
      {

        throw ex;
      }

    }

    public async Task<User> LoginAsync(string bCode)
    {
      try
      {
        string resp = await sendGetRequestAsync(UserAPI + "?bCode=" + bCode);
        
        var user = JsonConvert.DeserializeObject<User>(resp);
        return user;
      }
      catch (Exception ex)
      {
        //TODO: handle exception here
        throw ex;
      }
      
    }

    public async Task<User> CreateUserAsync(User user)
    {
      try
      {
        var result = await sendPostRequestAsync<User>(UserAPI, user);
        User u = JsonConvert.DeserializeObject<User>(result);
        return u;
      }
      catch (Exception ex)
      {
        //TODO: handle exception here
        throw ex;
      }
    }

    public async Task<int> DeleteUserAsync(int id)
    {
      try
      {
        string url = UserAPI + "/" + id;
        return await DeleteRequestAsync(url);
      }
      catch (Exception ex)
      {

        throw ex;
      }

    }


    private async Task<string> sendGetRequestAsync(string url)
    {
      HttpClient client = new HttpClient();
      client.BaseAddress = new Uri(baseUrl);
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      var response = await client.GetAsync(url);
      string resp = await response.Content.ReadAsStringAsync();
      return resp;
    }

    private async Task<string> sendPostRequestAsync<T>(string url,T data)
    {
      HttpClient client = new HttpClient();
      client.BaseAddress = new Uri(baseUrl);
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      var response = await client.PostAsJsonAsync<T>(url, data);
      string resp = await response.Content.ReadAsStringAsync();
      return resp;
    }

    private async Task<int> DeleteRequestAsync(string url)
    {
      HttpClient client = new HttpClient();
      client.BaseAddress = new Uri(baseUrl);
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      var response = await client.DeleteAsync(url);
      string resp = await response.Content.ReadAsStringAsync();
      return JsonConvert.DeserializeObject<int>(resp);
    }
  }
}
