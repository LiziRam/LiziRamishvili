using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using Mapster;
using Todo.Application.ExceptionHandling.CustomExceptions;
using Todo.Application.Users.Repositories;
using Todo.Application.Users.Requests;
using Todo.Application.Users.Responses;
using Todo.Domain.Users;

namespace Todo.Application.Users
{
    public class UserService : IUserService
    {
        const string SECRET_KEY = "a7Hj8sf1";
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserResponseModel> CreateAsync(CancellationToken cancellationToken, UserCreateRequestModel userCreateRequest)
        {
            var userExists = await _repository.Exists(cancellationToken, userCreateRequest.Username);

            if (userExists)
                throw new UserAlreadyExistsException();

            var userEntity = userCreateRequest.Adapt<User>();
            userEntity.PasswordHash = GenerateHash(userCreateRequest.Password);

            var newUser = await _repository.CreateAsync(cancellationToken, userEntity);

            return newUser.Adapt<UserResponseModel>();
        }

        public async Task<string> AuthenticateAsync(CancellationToken cancellationToken, string username, string password)
        {
            var hashedPassword = GenerateHash(password);
            var userEntity = await _repository.GetAsync(cancellationToken, username, hashedPassword);

            if (userEntity == null)
                throw new InvalidLoginRequestException();

            return userEntity.Username;
        }

        
        private string GenerateHash(string input)
        {
            using (SHA512 sha = SHA512.Create())
            {
                byte[] bytes = Encoding.ASCII.GetBytes(input + SECRET_KEY);
                byte[] hashBytes = sha.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                return sb.ToString();
            }
        }

        public async Task<int> GetIdByUsername(CancellationToken cancellationToken, string username)
        {
            var userId = await _repository.GetIdByUsername(cancellationToken, username);

            if(userId == null)
            {
                throw new UserNotFoundException();
            }

            return userId;
        }
    }
}

