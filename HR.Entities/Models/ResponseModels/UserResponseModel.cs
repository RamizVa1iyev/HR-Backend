using Core.Entities.Abstract;

namespace HR.Entities.Models.ResponseModels
{
    public class UserResponseModel : IModel
    {
        public UserResponseModel() { }
        public UserResponseModel(int id, string firstName, string lastName, string email, byte[] passwordHash, byte[] passwordSalt, bool status, int employeeId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Status = status;
            EmployeeId = employeeId;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }
        public int EmployeeId { get; set; }
    }
}
