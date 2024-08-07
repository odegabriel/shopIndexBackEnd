using MyProjectWithoutDocker.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProjectWithoutDocker.Dtos
{
    public record class ItemsDto
    (
        string brand,
        string title,
        string price,
        string description,
        string imagUrl
    );
    
}

//public Guid Id { get; set; }
//public required string Brand { get; set; }
//public required string Title { get; set; }
//public required string Price { get; set; }
//public required string Description { get; set; }
//public required string ImageUrl { get; set; }
//[ForeignKey("UserId")]
//public Guid UserId { get; set; }
//public required UserModel User { get; set; }