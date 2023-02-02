using System;
using PizzaRestaurant.Domain.Addresses;
using PizzaRestaurant.Infrastructure.CustomExceptions;

namespace PizzaRestaurant.Infrastructure.Addresses
{
	public class AddressRepository : IAddressRepository
	{
        private static List<Address> _data = new List<Address>
        {
            new Address{ Id = 1, UserId = 1 , City = "თბილისი", Country = "საქართველო", Region = "ქვემო ქართლი", Description ="ჩიქოვანის 3ა"},
            new Address{ Id = 2, UserId = 2 , City = "თბილისი", Country = "საქართველო", Region = "ქვემო ქართლი", Description ="კოსტავას 13" },
        };

        public async Task CreateAsync(CancellationToken cancellationToken, Address address)
        {
            if (_data.Exists(x => x.Id == address.Id))
                throw new AlreadyCreatedException();

            address.Id = _data.Max(x => x.Id) + 1;
            await Task.Delay(1000, cancellationToken);
            _data.Add(address);
        }

        public async Task<Address> GetByIdAsync(CancellationToken cancellationToken, int id)
        {
            return await Task.FromResult(_data.SingleOrDefault(x => x.Id == id));
        }

        public async Task<List<Address>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await Task.FromResult(_data);
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, Address address, int id)
        {
            int index = _data.IndexOf(_data.SingleOrDefault(x => x.Id == id));
            address.Id = id;
            await Task.Delay(1000, cancellationToken);
            _data[index] = address;
        }

        public async Task<bool> Exists(CancellationToken cancellationToken, int id)
        {
            var address = await Task.FromResult(_data.SingleOrDefault(x => x.Id == id));
            if(address == null)
            {
                return false;
            }
            return true;
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            var address = await GetByIdAsync(cancellationToken, id);
            
            await Task.Delay(1000, cancellationToken);
            _data.Remove(address);
        }
    }
}

