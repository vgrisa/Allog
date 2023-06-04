using aula1.Api.Entities;

namespace aula1.Api.Models
{
    public class CustomerForUpdateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
    }
}