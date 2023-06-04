using System.ComponentModel.DataAnnotations;

namespace aula1.Api.Entities;

public class Address
{
    public int Id { get; set; }
    // public int CustomerId { get; set; }
    
    [Required(ErrorMessage = "You should fill out a Street")]
    [MaxLength(100, ErrorMessage = "The Street shouldn't have more than 100 caracters")]
    public string Street { get; set; } = string.Empty;

    [Required(ErrorMessage = "You should fill out a City")]
    [MaxLength(100, ErrorMessage = "The City shouldn't have more than 100 caracters")]
    public string City { get; set; } = string.Empty;
}