using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Cafeinator.DataAccess.DataServices;
using Cafeinator.Infra.Models;
using System.Collections.Generic;

namespace Cafeinator.Tests.ServicesTest
{
  

  [TestClass]
  public class DataServiceTest :BaseUnitTest
  {
    [TestMethod]
    public void LoginAPI_Assert_Get_Correct_User_By_BCode()
    {
      User u = null;
      service.LoginAsync(mockUser.BCode).ContinueWith(x =>
      {
        u = x.Result;
      }).Wait();

      Assert.AreEqual(u.UsrName, mockUser.UsrName);
    }

    [TestMethod]
    public void LoginAPI_Assert_Get_User_Not_Found_By_BCode()
    {
      User u = null;
      service.LoginAsync("2011").ContinueWith(x =>
      {
        u = x.Result;
      }).Wait();

      Assert.IsNull(u);
    }

    [TestMethod]
    public void DrinkAPI_Assert_GetAllDrinks_Return_3_Drinks()
    {
      List<Drink> drinks=null;

      service.GetDrinksAsync().ContinueWith(x =>
      {
        drinks = x.Result;
      }).Wait();

      Assert.AreEqual(drinks?.Count, 3);
    }

    [TestMethod]
    public void UserAPI_Assert_CreateUser_Return_A_User_With_ID()
    {
      var createdUser = new User { BCode = "666", UsrName = "UserCreated" };
      service.CreateUserAsync(createdUser).ContinueWith(x =>
      {
        createdUser = x.Result;
      }).Wait();

      Assert.IsNotNull(createdUser);
      Assert.AreEqual(createdUser.BCode, createdUser.BCode);
      Assert.AreNotEqual(createdUser.UsrID, 0);
      if(createdUser != null)
      serviceMock.DeleteMockUser(createdUser.UsrID).Wait();
    }

    [TestMethod]
    public void DrinkAPI_SaveLastUserDrink_And_GetLastUserChoice_To_Return_DrinkID_1_And_SugarQty_4()
    {
      Drink lastdrink = new Drink { DrkID = 1, DrkLabel = "Cafe", SugarQty = 4 };
      service.SaveLastUserDrinkAsync(lastdrink, mockUser.UsrID).Wait();
      Drink saveddrink = null;
      service.GetUserLastChoiceAsync(mockUser).ContinueWith(x =>
      {
        saveddrink = x.Result;
      }).Wait();

      Assert.IsNotNull(saveddrink);
      Assert.AreEqual(lastdrink.DrkID, saveddrink.DrkID);
      Assert.AreEqual(lastdrink.SugarQty, saveddrink.SugarQty);
    }

    //TODO Create other tests here for dataservices

  }
}
