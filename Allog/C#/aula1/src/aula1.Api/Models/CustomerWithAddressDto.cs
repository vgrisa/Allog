using aula1.Api.Entities;

namespace aula1.Api.Models;

public class CustomerWithAddressDto
{
    public int Id { get; set; }
    public string FirstName { private get; set; } = string.Empty;
    public string LastName { private get; set; } = string.Empty;
    public string FulName
    {
        get
        {
            return FirstName + " " + LastName;
        }
    }
    public string Cpf { get; set; } = string.Empty;
    public ICollection<AddressDto> Addresses { get; set; } = new List<AddressDto>();
}