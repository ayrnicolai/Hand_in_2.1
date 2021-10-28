using System.Collections.Generic;
using System.Threading.Tasks;
using Hand_in_2._1.Models;

namespace Hand_in_2._1.Models
{
    public interface IAdultData
    {
        Task<IList<Person>> getAdult();
        Task<Person> AddAdult(Person adults);
        Task RemoveAdult(int id);
    }
}