namespace aula1.Api.Models;

public class AddressDto
{
    public int Id { get; set; }
    // public int CustomerId { get; set; }
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
}