using System;
using Mapster;
using PizzaRestaurant.Application.Addresses.Requests;
using PizzaRestaurant.Application.Addresses.Responses;
using PizzaRestaurant.Application.ExceptionHandling.CustomExceptions;
using PizzaRestaurant.Application.Users.Requests;
using PizzaRestaurant.Application.Users.Responses;
using PizzaRestaurant.Domain.Users;
using PizzaRestaurant.Infrastructure.Users;
using PizzaRestaurant.Infrastructure.Addresses;
using PizzaRestaurant.Domain.Addresses;

namespace PizzaRestaurant.Application.Users
{
	public class UserService : IUserService
	{
        private IUserRepository _userRepo;
        private IAddressRepository _addressRepo;

        public UserService(IUserRepository repo, IAddressRepository addRepo)
        {
            _userRepo = repo;
            _addressRepo = addRepo;
        }

        public async Task CreateAsync(CancellationToken cancellationToken, UserRequestModel user)
        {
            var userToInsert = user.Adapt<User>();
            var addressToInsert = user.Address.Adapt<Address>();

            userToInsert.Addresses.Add(addressToInsert);

            
            await _userRepo.CreateAsync(cancellationToken, userToInsert);
            await _addressRepo.CreateAsync(cancellationToken, addressToInsert); 
        }
        
        public async Task<UserResponseModel> GetAsync(CancellationToken cancellationToken, int id)
        {
            var res = await _userRepo.GetByIdAsync(cancellationToken, id);
            if (res == null)
                throw new NotFoundException();

            var userResponse = res.Adapt<UserResponseModel>();
            var addressResponse = new List<AddressResponseModel>();
            foreach (var address in res.Addresses)
            {
                addressResponse.Add(address.Adapt<AddressResponseModel>());
            }
            userResponse.Addresses = addressResponse;
            await Task.Delay(1000, cancellationToken);
            return userResponse;
        }

        public async Task<List<UserResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var users = await _userRepo.GetAllAsync(cancellationToken);
            if (users == null)
            {
                throw new EmptyListException();
            }
            await Task.Delay(1000, cancellationToken);
            var userResponses = users.Adapt<List<UserResponseModel>>();
            foreach (var userResponse in userResponses)
            {
                foreach (var user in users)
                {
                    if (userResponse.Id == user.Id)
                    {
                        userResponse.Addresses = user.Addresses.Adapt<List<AddressResponseModel>>();
                    }
                }
            }
            return userResponses;
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, UserRequestModel user, int id)
        {
            if (!await _userRepo.Exists(cancellationToken, id))
                throw new NotFoundException();

            var userToUpdate = user.Adapt<User>();
            var addressToUpdate = user.Address.Adapt<Address>();

            var oldUser = await _userRepo.GetByIdAsync(cancellationToken, id);

            if (oldUser.Addresses.Count != 0)
            {
                foreach (var address in oldUser.Addresses)
                {
                    userToUpdate.Addresses.Add(address);
                }
            }
            
            int addressToChangeId = userToUpdate.Addresses[0].Id;
            userToUpdate.Addresses[0] = addressToUpdate; //პირველი მისამართი შევუცვალე ახლით

            await _userRepo.UpdateAsync(cancellationToken, userToUpdate, id);
            await _addressRepo.UpdateAsync(cancellationToken, addressToUpdate, addressToChangeId);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            if (!await _userRepo.Exists(cancellationToken, id))
                throw new NotFoundException();

            var listUsers = await _userRepo.GetByIdAsync(cancellationToken, id);
            foreach (var address in listUsers.Addresses)
            {
                await _addressRepo.DeleteAsync(cancellationToken, address.Id);
            }
            
            await _userRepo.DeleteAsync(cancellationToken, id);
        }
    }
}

