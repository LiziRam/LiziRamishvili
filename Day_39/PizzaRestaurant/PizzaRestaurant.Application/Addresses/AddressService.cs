using System;
using Mapster;
using PizzaRestaurant.Application.Addresses.Requests;
using PizzaRestaurant.Application.Addresses.Responses;
using PizzaRestaurant.Application.ExceptionHandling.CustomExceptions;
using PizzaRestaurant.Domain.Addresses;
using PizzaRestaurant.Infrastructure.Addresses;
using PizzaRestaurant.Infrastructure.Users;

namespace PizzaRestaurant.Application.Addresses
{
	public class AddressService : IAddressService
	{
        private IAddressRepository _addressRepo;
        private IUserRepository _userRepo;
        
        public AddressService(IAddressRepository repo, IUserRepository userRepo)
        {
            _addressRepo = repo;
            _userRepo = userRepo;
        }
        
        public async Task CreateAsync(CancellationToken cancellationToken, AddressRequestModel address)
        {
            var userExists = await _userRepo.Exists(cancellationToken, address.UserId);
            if (!userExists)
            {
                throw new UserNotFoundException();
            }
            var addressToInsert = address.Adapt<Address>();
            await _addressRepo.CreateAsync(cancellationToken, addressToInsert);

            var newUser = await _userRepo.GetByIdAsync(cancellationToken, address.UserId);
            newUser.Addresses.Add(addressToInsert);
            await _userRepo.UpdateAsync(cancellationToken, newUser, newUser.Id);  //იუზერს დავუმატე მისამართი
        }
        
        public async Task<AddressResponseModel> GetAsync(CancellationToken cancellationToken, int id)
        {
            var res = await _addressRepo.GetByIdAsync(cancellationToken, id);
            if (res == null)
                throw new NotFoundException();
            else
                return res.Adapt<AddressResponseModel>();
        }

        public async Task<List<AddressResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var res = await _addressRepo.GetAllAsync(cancellationToken);
            return res.Adapt<List<AddressResponseModel>>();
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, AddressRequestModel address, int id)
        {
            if (!await _addressRepo.Exists(cancellationToken, id))
                throw new NotFoundException();

            var oldAddress = await _addressRepo.GetByIdAsync(cancellationToken, id);
            var addressToUpdate = address.Adapt<Address>();

            if(oldAddress.UserId == addressToUpdate.UserId)
            {
                //თუ იგივე იუზერს ვუაფდეითებთ მისამართს
                var userToUpdate = await _userRepo.GetByIdAsync(cancellationToken, addressToUpdate.UserId);
                foreach (var addr in userToUpdate.Addresses)
                {
                    if (addr.Id == id)
                    {
                        userToUpdate.Addresses.Remove(addr);
                        break;
                    }
                }
                userToUpdate.Addresses.Add(addressToUpdate);
                await _userRepo.UpdateAsync(cancellationToken, userToUpdate, userToUpdate.Id);  //იუზერს დავუაფდეითე მისამართი

                //ეს იქნებ ცალკე გავიტანო
                await _addressRepo.UpdateAsync(cancellationToken, addressToUpdate, id);
            }
            else
            {
                //თუ ახალ იუზერს ვაძლევთ დააფდეითებულ მისამართს

                var userExists = await _userRepo.Exists(cancellationToken, addressToUpdate.UserId);
                if (!userExists)
                {
                    throw new UserNotFoundException();
                }

                var newUser = await _userRepo.GetByIdAsync(cancellationToken, addressToUpdate.UserId);
                newUser.Addresses.Add(addressToUpdate);
                await _userRepo.UpdateAsync(cancellationToken, newUser, newUser.Id);  //ახალ იუზერს დავუმატე მისამართი

                var oldUser = await _userRepo.GetByIdAsync(cancellationToken, oldAddress.UserId);
                foreach (var addr in oldUser.Addresses)
                {
                    if (addr.Id == id)
                    {
                        oldUser.Addresses.Remove(addr); //ძველ იუზერს წავუშალე მისამართი
                        break;
                    }
                }

                await _addressRepo.UpdateAsync(cancellationToken, addressToUpdate, id); //დავააფდეითე მისამართების დატა
            }
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            if (!await _addressRepo.Exists(cancellationToken, id))
                throw new NotFoundException();
            
            var addressToDelete = await _addressRepo.GetByIdAsync(cancellationToken, id);
            var ownerUser = await _userRepo.GetByIdAsync(cancellationToken, addressToDelete.UserId);
            foreach (var address in ownerUser.Addresses)
            {
                if(address.Id == id)
                {
                    ownerUser.Addresses.Remove(address); //წავშალოთ იუზერების მისამართებიდან
                    break;
                }
            }

            await _addressRepo.DeleteAsync(cancellationToken, id); //წავშალოთ მისამართებიდან
        }
    }
}

