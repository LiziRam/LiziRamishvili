using System;
namespace Todo.Application.Users.Responses
{
	public class UserResponseModel
	{
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}

