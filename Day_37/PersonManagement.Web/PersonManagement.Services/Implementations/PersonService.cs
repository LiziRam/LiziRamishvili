using PersonManagement.Services.Abstractions;
using PersonManagement.Services.Models;

namespace PersonManagement.Services.Implementations
{
    public class PersonService : IPersonService
    {

        #region PersonData

        private static List<PersonServiceModel> _persons = new List<PersonServiceModel>
        {
            new PersonServiceModel
            {
                Id = 1, FirstName = "გიორგი" , LastName ="ჩიქოვანი", Gender = true, BirthDate = DateTime.Now.AddYears(-15), PersonIdentifier ="0000000000", City = new CityServiceModel{ Name = "თბილისი", Population= 1300000}
            },
            new PersonServiceModel
            {
                Id = 2, FirstName = "ნათია" , LastName ="შვილი", Gender = true, BirthDate = DateTime.Now.AddYears(-15), PersonIdentifier ="0000000000", City = new CityServiceModel{ Name = "თბილისი", Population= 1300000}

            },
            new PersonServiceModel
            {
                Id = 3, FirstName = "თეკლე" , LastName ="გიორგობიანი", Gender = true, BirthDate = DateTime.Now.AddYears(-15), PersonIdentifier ="0000000000", City = new CityServiceModel{ Name = "თბილისი", Population= 1300000}

            }
        };

        #endregion

        public async Task<List<PersonServiceModel>> GetAllAsync()
        {
            return await Task.FromResult(_persons);
        }

        public async Task<PersonServiceModel> GetByIdAsync(int id)
        {
            return await Task.FromResult(_persons.SingleOrDefault(x => x.Id == id));
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (!_persons.Exists(x => x.Id == id))
                return false;

            var person = await GetByIdAsync(id);

            _persons.Remove(person);

            return true;
        }

        public async Task<int> CreateAsync(PersonServiceModel person)
        {
            var id = _persons.Max(x => x.Id) + 1;
            person.Id = id;
            _persons.Add(person);

            return await Task.FromResult(id);
        }
    }
}
