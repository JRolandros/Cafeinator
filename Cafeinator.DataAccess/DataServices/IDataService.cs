using Cafeinator.Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafeinator.DataAccess.DataServices
{
  public interface IDataService
  {
    Task<User> LoginAsync(string bCode);
    Task<User> CreateUserAsync(User user);
    Task<int> DeleteUserAsync(int usrID);
    Task<int> DeleteMenuAsync(int usrID);
    Task<Drink> GetUserLastChoiceAsync(User user);
    Task<List<Drink>> GetDrinksAsync();
    Task<int> SaveLastUserDrinkAsync(Drink drink, int userID);
  }
}
