using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hand_in_2._1.Models;

namespace Hand_in_2._1.Data.Impl {
public class InMemoryUserService : IUserService {
    private List<User> users;

    public InMemoryUserService() {
        users = new[] {
            new User {
                ID = 123456,
                Username = "Farmand",
                FirstName = "Kenned",
                LastName = "Ødegaard",
                HairColor = "Black",
                EyeColor = "Brown",
                Age = 53,
                Weight = 84,
                Height = 180,
                Sex = "Male",
                SecurityLevel = 5,
                Password = "1234",
            },
            new User {
                ID = 123456,
                Username = "Moderjord",
                FirstName = "Birgitte",
                LastName = "Tierney",
                HairColor = "Brown",
                EyeColor = "Brown",
                Age = 49,
                Weight = 62,
                Height = 170,
                Sex = "Female",
                SecurityLevel = 4,
                Password = "12345",
            },
            new User {
                ID = 123456,
                Username = "Sønnike",
                FirstName = "Pierre",
                LastName = "Aubameyang",
                HairColor = "Black",
                EyeColor = "Green",
                Age = 16,
                Weight = 74,
                Height = 176,
                Sex = "Male",
                SecurityLevel = 2,
                Password = "123456",
            }
        }.ToList();
    }

    public async Task<User> ValidateUser(string userName, string password)
    {
        User user = users.FirstOrDefault(u => u.Username.Equals(userName) && u.Password.Equals(password));
        if (user != null)
        {
            return user;
        } 
        throw new Exception("User not found");
    }

    public async Task<User> ValidateLogin(string username, string password)
    {
        User user = users.FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password));
        if (user != null)
        {
            return user;
        } 
        throw new Exception("User not found");
    }
}
}