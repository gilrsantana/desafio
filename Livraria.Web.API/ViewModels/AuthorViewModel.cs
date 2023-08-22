using Livraria.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Web.API.ViewModels;

public class AuthorViewModel
{
    public Guid Id { get; set; }
    [Required]
    public Name Name { get; set; } = null!;
    
    [Required]
    public DateTime BirthDate { get; set; }

    public DateTime? DeathDate { get; set; }

    public string? Nationality { get; set; }

    public string? Biography { get; set; }

}
