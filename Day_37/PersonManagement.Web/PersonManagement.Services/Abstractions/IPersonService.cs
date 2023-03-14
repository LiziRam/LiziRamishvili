using PersonManagement.Services.Models;

namespace PersonManagement.Services.Abstractions
{
    public  interface IPersonService
    {
        Task<List<PersonServiceModel>> GetAllAsync();
        Task<PersonServiceModel> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<int> CreateAsync(PersonServiceModel person);
    }
}
