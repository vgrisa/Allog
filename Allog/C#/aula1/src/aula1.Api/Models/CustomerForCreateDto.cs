using System.ComponentModel.DataAnnotations;
using aula1.Api.Entities;

namespace aula1.Api.Models
{
    public class CustomerForCreateDto
    {
        [Required(ErrorMessage = "You should fill out a First Name")]
        [MaxLength(100, ErrorMessage = "The First Name shouldn't have more than 100 caracters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "You should fill out a Last Name")]
        [MaxLength(100, ErrorMessage = "The Last Name shouldn't have more than 100 caracters")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "You should fill out a CPF")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "The CPF should have 11 caracters")]
        public string Cpf { get; set; } = string.Empty;
    }
}