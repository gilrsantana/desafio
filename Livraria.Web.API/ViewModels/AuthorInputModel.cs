using System.ComponentModel.DataAnnotations;
using Livraria.Domain.ValueObjects;

namespace Livraria.Web.API.ViewModels
{
    public class AuthorInputModel
    {
        [Required]
        public Name Name { get; set; } = null!;
    
        [Required]
        public DateTime BirthDate { get; set; }

        public DateTime? DeathDate { get; set; }
        
        [MaxLength(80)]
        public string? Nationality { get; set; }
        
        [MaxLength(500)]
        public string? Biography { get; set; }
    }
}
