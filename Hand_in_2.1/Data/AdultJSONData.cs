using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text.Json;
using System.Threading.Tasks;
using Hand_in_2._1.Models;

namespace Hand_in_2._1.Data
{
    public class AdultJSONData : IAdultData
    {
        private string adultFile = "adults.json";
        private IList<Person> adults;

        public AdultJSONData()
        {
            if (!File.Exists(adultFile))
            {
                Seed();
                WriteToAdultFile();

            }
            else
            {
                string content = File.ReadAllText(adultFile);
                adults = JsonSerializer.Deserialize<List<Person>>(content);
            }
        }

        public void Seed()
        {
            Person[] ad =
            {
                new Person
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Sten",
                    HairColor = "Brown",
                    EyeColor = "Brown",
                    Age = 26,
                    Weight = 70,
                    Height = 186,
                    Sex = "Male"
                },
            };
            adults = ad.ToList();

        }

        public async Task<IList<Person>> getAdult()
        {
            List<Person> tmp = new List<Person>(adults);
            return tmp;

        }

        public async Task<Person> AddAdult(Person adult)
        {
            int max = adults.Max(adult => adult.Id);
            adult.Id = (++max);
            adults.Add(adult);
            WriteToAdultFile();
            return adult;
        }

        public async Task RemoveAdult(int id)
        {
            Person toRemove = adults.First(t => t.Id == id);
            adults.Remove(toRemove);
            WriteToAdultFile();
            
        }

        private void WriteToAdultFile()
        {
            string adultAsJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(adultFile, adultAsJson);
        }
    }
}