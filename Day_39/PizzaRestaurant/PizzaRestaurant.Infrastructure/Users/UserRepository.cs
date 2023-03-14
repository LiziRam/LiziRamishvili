using System;
using PizzaRestaurant.Domain.Addresses;
using PizzaRestaurant.Domain.Users;
using PizzaRestaurant.Infrastructure.CustomExceptions;

namespace PizzaRestaurant.Infrastructure.Users
{
	public class UserRepository : IUserRepository
	{
        private static List<User> _data = new List<User>
        {
            new User{Id = 1, FirstName = "ლაშა", LastName = "დაუშვილი", Email = "ldaush23@tbc.ge", PhoneNumber = "579837472", Addresses = new List<Address>
            {
                new Address{ Id = 1, UserId = 1 , City = "თბილისი", Country = "საქართველო", Region = "ქვემო ქართლი", Description ="ჩიქოვანის 3ა"}
            } }, 
            new User{Id = 2, FirstName = "ბექა", LastName = "ღვაბერიძე", Email = "nghvab23@tbc.ge", PhoneNumber = "579942594", Addresses = new List<Address>
            {
                new Address{ Id = 2, UserId = 2 , City = "თბილისი", Country = "საქართველო", Region = "ქვემო ქართლი", Description ="კოსტავას 13" }
            } },
        };

        public async Task CreateAsync(CancellationToken cancellationToken, User user)
        {
            if (_data.Exists(x => x.Id == user.Id))
            {
                throw new AlreadyCreatedException();
            }

            user.Id = _data.Max(x => x.Id) + 1;
            user.Addresses[0].UserId = user.Id;
            await Task.Delay(1000, cancellationToken);
            _data.Add(user);
        }

        public async Task<User> GetByIdAsync(CancellationToken cancellationToken, int id)
        {
            return await Task.FromResult(_data.SingleOrDefault(x => x.Id == id));
        }

        public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await Task.FromResult(_data);
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, User user, int id)
        {
            int index = _data.IndexOf(_data.SingleOrDefault(x => x.Id == id));
            user.Id = id;
            user.Addresses[0].UserId = user.Id;
            await Task.Delay(1000, cancellationToken);
            _data[index] = user;
        }

        public async Task<bool> Exists(CancellationToken cancellationToken, int id)
        {
            var user = await Task.FromResult(_data.SingleOrDefault(x => x.Id == id));
            if(user == null)
            {
                return false;
            }
            return true;
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            var user = await GetByIdAsync(cancellationToken, id);
            
            await Task.Delay(1000, cancellationToken);
            _data.Remove(user);
        }
    }
}

