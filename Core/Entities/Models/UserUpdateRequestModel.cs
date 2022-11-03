using Core.Entities.Abstract;

namespace Core.Entities.Models
{
    public class UserUpdateRequestModel : IModel
    {
        public UserUpdateRequestModel(int id, string firstName, string lastName, string email, bool status)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Status = status;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}
