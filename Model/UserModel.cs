using System.ComponentModel.DataAnnotations;

namespace MyProjectWithoutDocker.Model
{
    public class UserModel
    {
        [Key]
        public required Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<UserItemsModel>? Items { get; set; }

    }
}
