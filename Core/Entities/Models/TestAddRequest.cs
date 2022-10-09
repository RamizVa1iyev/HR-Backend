using Core.Entities.Abstract;

namespace Core.Entities.Models
{
    public class TestAddRequest : IAddModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }
}
