using System.Threading.Tasks;
using Hand_in_2._1.Models;

namespace Hand_in_2._1.Data {
public interface IUserService {
    Task<User> ValidateUser(string userName, string password);
    
    Task<User> ValidateLogin(string username, string password);

}
}