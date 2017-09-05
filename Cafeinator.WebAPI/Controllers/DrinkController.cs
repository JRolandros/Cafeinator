using Cafeinator.Infra.Models;
using Cafeinator.WebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cafeinator.WebAPI.Controllers
{
  public class DrinkController : ApiController
  {
    // GET api/Drink
    public List<Drink> Get()
    {
      using (CafeinatorDBEntities dbCtx = new CafeinatorDBEntities())
      {        
        var drinks = dbCtx.GetAllDrinkType();
        return convertTDrinkTypeToDrinks(drinks);
      }

    }

    /// <summary>
    /// Get user last choice
    /// </summary>
    /// <param name="usrID"></param>
    /// <returns></returns>

    [HttpGet]
    public Drink GetUserLastChoce(int usrID)
    {
      using(CafeinatorDBEntities dbCtx =new CafeinatorDBEntities())
      {
        return dbCtx.GetUserLastChoice(usrID).Select(x =>
        {
          return new Drink
          {
            DrkID = (int)x?.drkID,
            DrkLabel = x?.drkLabel,
            SugarQty = (int)x?.sugarQty
          };
        }).FirstOrDefault();
      }
    }

    /// <summary>
    /// Save user last choice
    /// </summary>
    /// <param name="drink"></param>
    /// <param name="usrID"></param>
    /// <returns></returns>
    // POST api/Drink
    public int Post(Menu menu)
    {
      using(CafeinatorDBEntities CafeinatorDBEntities =new CafeinatorDBEntities())
      {
        return CafeinatorDBEntities.SaveUserLastChoice(menu.UsrID, menu.Drink.DrkID, menu.Drink.SugarQty);
      }
    }

    public int Delete(int id)
    {
      using(CafeinatorDBEntities dbCtx=new CafeinatorDBEntities())
      {
        return dbCtx.DeleteMenu(id);
      }
    }
    private List<Drink> convertTDrinkTypeToDrinks(ObjectResult<GetAllDrinkType_Result> drks)
    {
      List<Drink> drinks = drks.Select(x =>
      {
        var drink = new Drink
        {
          DrkID = x.drkID,
          DrkLabel = x.drkLabel
        };
        return drink;
      }).ToList();

      return drinks;
    }
  }
}