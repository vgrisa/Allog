using aula1.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace aula1.Api.Controllers;

[ApiController]
[Route("api/customers/{customerId}/addresses")]

public class AddressController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<AddressDto>> GetAddresses(int customerId, int addressId)
    {
        var customerDB = Data.Instance.Customers.FirstOrDefault(x => x.Id == customerId);

        if (customerDB == null) return NotFound();

        var addressReturn = new List<AddressDto>();

        addressReturn = customerDB.Addresses.Select(x => new AddressDto
        {
            Id = x.Id,
            City = x.City,
            Street = x.Street
        }).ToList();

        return Ok(addressReturn);
    }

    [HttpGet("{addressId}")]
    public ActionResult<AddressDto> GetAddress(int customerId, int addressId)
    {
        var addressReturn = Data.Instance.Customers.FirstOrDefault(customer => customer.Id == customerId)?
            .Addresses.FirstOrDefault(address => address.Id == addressId);

        return addressReturn != null ? Ok(addressReturn) : NotFound();
    }
}