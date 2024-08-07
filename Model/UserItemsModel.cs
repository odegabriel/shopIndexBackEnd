using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProjectWithoutDocker.Model
{
    public class UserItemsModel
    {
        [Key]
        public Guid Id { get; set; }
        public required string Brand { get; set; }
        public required string Title { get; set; }
        public required string Price { get; set; }
        public required string DiscountPrice { get; set; }
        public required string PhotoUrl { get; set; }
        public required Guid UserId { get; set; }
        public  UserModel? User { get; set; }
    }
}

