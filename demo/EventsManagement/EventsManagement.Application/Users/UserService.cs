using System.Security.Cryptography;
using System.Text;
using EventsManagement.Application.ExceptionHandling.CustomExceptions;
using EventsManagement.Application.Users.Repositories;
using EventsManagement.Application.Users.Requests;
using EventsManagement.Application.Users.Responses;
using EventsManagement.Domain.Users;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;

namespace EventsManagement.Application.Users
{
    public class UserService : IUserService
    {
        private const string SECRET_KEY = "a7Hj8sf1";
        private readonly IUserRepository _repository;
        private readonly int _userId;

        public UserService(IUserRepository repository, IHttpContextAccessor accessor) {
            _repository = repository;
            
            //var IdClaim = accessor.HttpContext.User.Claims.Single(x => x.Type == "UserId");
            //_userId = int.Parse(IdClaim.Value);
        }

        //1. ------------------------------მომხმარებლისთვის---------------------------------

        public async Task<UserResponseModel> CreateAsync(CancellationToken cancellationToken,
            UserCreateRequestModel userCreateRequest)
        {
            var userExists = await _repository.Exists(cancellationToken, userCreateRequest.UserName).ConfigureAwait(false);

            if (userExists)
                throw new UsernameTakenException();

            var emailExists = await _repository.EmailExists(cancellationToken, userCreateRequest.Email).ConfigureAwait(false);

            if (emailExists)
                throw new EmailTakenException();

            var userEntity = userCreateRequest.Adapt<User>();
            userEntity.PasswordHash = GenerateHash(userCreateRequest.Password);

            var newUser = await _repository.CreateAsync(cancellationToken, userEntity).ConfigureAwait(false);
            return newUser.Adapt<UserResponseModel>();
        }

        public async Task<int> GetIdByUsername(CancellationToken cancellationToken, string username)
        {
            var userId = await _repository.GetIdByUsername(cancellationToken, username).ConfigureAwait(false);

            if (userId == null)
                throw new UserNotFoundException();
                

            return userId;
        }

        public async Task<string> AuthenticateAsync(CancellationToken cancellationToken, string username,
            string password)
        {
            var hashedPassword = GenerateHash(password);
            var userEntity = await _repository.GetAsync(cancellationToken, username, hashedPassword).ConfigureAwait(false);

            if (userEntity == null)
                throw new InvalidLoginRequestException();

            return userEntity.UserName;
        }

        private string GenerateHash(string input)
        {
            using (var sha = SHA512.Create())
            {
                var bytes = Encoding.ASCII.GetBytes(input + SECRET_KEY);
                var hashBytes = sha.ComputeHash(bytes);

                var sb = new StringBuilder();

                for (var i = 0; i < hashBytes.Length; i++) sb.Append(hashBytes[i].ToString("X2"));

                return sb.ToString();
            }
        }

        public async Task<UserResponseModel> GetAsync(CancellationToken cancellationToken, int id) {
            if (id != _userId)
                throw new WrongUserException(); 

            var userExists = await _repository.Exists(cancellationToken, id).ConfigureAwait(false);
            if (!userExists)
                throw new UserNotFoundException();

            var user = await _repository.GetByIdAsync(cancellationToken, id).ConfigureAwait(false);
            return user.Adapt<UserResponseModel>();
        }

        public async Task UpdateAsync(CancellationToken cancellationToken,
            UserEditRequestModel userEditRequest, int id)
        {
            if (id != _userId)
                throw new WrongUserException();

            var userExists = await _repository.Exists(cancellationToken, id).ConfigureAwait(false);
            if (!userExists)
                throw new UserNotFoundException();

            var userToUpdate = userEditRequest.Adapt<User>();

            userToUpdate.PasswordHash = GenerateHash(userEditRequest.Password);
            userToUpdate.Id = id;

            await _repository.UpdateAsync(cancellationToken, userToUpdate).ConfigureAwait(false);
        }

        //2. ------------------------------ადმინისთვის---------------------------------

        public async Task<UserResponseForAdminModel> GetUserByIdAsync(CancellationToken cancellationToken, int id)
        {
            var userExists = await _repository.Exists(cancellationToken, id).ConfigureAwait(false);
            if (!userExists)
                throw new UserNotFoundException();

            var user = await _repository.GetByIdAsync(cancellationToken, id).ConfigureAwait(false);
            return user.Adapt<UserResponseForAdminModel>();
        }

        public async Task<List<UserResponseForAdminModel>> GetAllActiveUsersAsync(CancellationToken cancellationToken)
        {
            var allUsers = await _repository.GetAllActiveAsync(cancellationToken).ConfigureAwait(false);
            var usersResponse = allUsers.Adapt<List<UserResponseForAdminModel>>();
            return usersResponse.ToList();
        }

    }
}
