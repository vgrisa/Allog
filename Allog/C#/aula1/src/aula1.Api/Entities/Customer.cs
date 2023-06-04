namespace aula1.Api.Entities;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty; 
    public ICollection<Address> Addresses { get; set; } = new List<Address>();
}