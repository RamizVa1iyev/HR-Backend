﻿
namespace Core.Entities.Concrete
{
    public class User : Entity
    {
        public User()
        {
        }

        public User(int id, string firstName, string lastName, string email, byte[] passwordSalt, byte[] passwordHash,bool status) : this()
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
            Status = status;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }
    }
}
