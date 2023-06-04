using aula1.Api;
using aula1.Api.Entities;
using aula1.Api.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace aula1.Api.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomersController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<CustomerDto>> GetCustomers()
    {
        var customersDB = Data.Instance.Customers;
        List<CustomerDto> customers = new List<CustomerDto>();

        customers = customersDB.Select(x => new CustomerDto
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Cpf = x.Cpf
        }).ToList();

        return Ok(customers);
    }

    [HttpGet("{id}", Name = "GetCustomerById")]
    public ActionResult<CustomerDto> GetCustomerById(int id)
    {
        System.Console.WriteLine("id: " + id);
        var customerDB = Data.Instance.Customers.FirstOrDefault(x => x.Id == id);
        if (customerDB == null) return NotFound();

        CustomerDto customerDto = new CustomerDto()
        {
            Id = customerDB.Id,
            FirstName = customerDB.FirstName,
            LastName = customerDB.LastName,
            Cpf = customerDB.Cpf,
        };
        return Ok(customerDto);
        // return (result == null ? NotFound() : Ok(customer));
    }

    [HttpGet("cpf/{cpf}")]
    public ActionResult<CustomerDto> GetCustomerByCpf(string cpf)
    {
        System.Console.WriteLine("cpf: " + cpf);
        var customerDB = Data.Instance.Customers.FirstOrDefault(x => x.Cpf == cpf);
        if (customerDB == null) return NotFound();

        CustomerDto customerDto = new CustomerDto()
        {
            Id = customerDB.Id,
            FirstName = customerDB.FirstName,
            LastName = customerDB.LastName,
            Cpf = customerDB.Cpf,
        };
        return Ok(customerDto);
        // return (result == null ? NotFound() : Ok(customer));
    }

    [HttpPost]
    public ActionResult<CustomerDto> CreateCustomer(CustomerForCreateDto customerCreate)
    {
        if (!ModelState.IsValid)
        {
            Response.ContentType = "application/problem+json";

            //cria a fabrica de um objeto de detalhes de problema de validacao
            var problemDetailsFactory = HttpContext.RequestServices.GetRequiredService<ProblemDetailsFactory>();

            //cria um objeto de detalhes de problema de validacao
            var validationProblemDetails = problemDetailsFactory.CreateValidationProblemDetails(HttpContext, ModelState);

            //atribui o status code 422 no corpo response
            validationProblemDetails.Status = StatusCodes.Status422UnprocessableEntity;

            return UnprocessableEntity(validationProblemDetails);
        }

        // List<AddressDto> addresses = new List<AddressDto>();
        // var customersDB = Data.Instance.Customers.ToList();

        // addresses = customerCreate.Addresses.Select((x, index) => new Address
        // {
        //     Id = customersDB.SelectMany(c => c.Addresses).Max(x => x.Id),
        //     // CustomerId = Data.Instance.Customers.Max(x => x.Id) + 1,
        //     Street = x.Street
        // }).ToList();


        var customer = new Customer()
        {
            Id = Data.Instance.Customers.Max(x => x.Id) + 1,
            FirstName = customerCreate.FirstName,
            LastName = customerCreate.LastName,
            Cpf = customerCreate.Cpf,
            // Addresses = addresses
        };

        Data.Instance.Customers.Add(customer);

        var customerDto = new CustomerDto()
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Cpf = customer.Cpf,
            // Addresses = addresses
        };

        return CreatedAtRoute(
            "GetCustomerById",
            new { id = customerDto.Id },
            customerDto
        );
    }

    [HttpPut("{id}")]
    public ActionResult UpdateCustomer(int id, CustomerForUpdateDto customer)
    {
        if (customer.Id == id) return BadRequest();

        var editaCustomer = Data.Instance.Customers.FirstOrDefault(x => x.Id == id);

        if (editaCustomer == null) return NotFound();

        editaCustomer.Cpf = customer.Cpf;
        editaCustomer.FirstName = customer.FirstName;
        editaCustomer.LastName = customer.LastName;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteCustomer(int id)
    {
        var customersDB = Data.Instance.Customers;
        var deleteCustomer = customersDB.FirstOrDefault(x => x.Id == id);

        if (deleteCustomer != null)
        {
            customersDB.Remove(deleteCustomer);
            return NoContent();
        }
        return NotFound();
    }

    [HttpPatch("{id}")]
    public ActionResult PartiallyUpdateCustomer([FromBody] JsonPatchDocument<CustomerForPatchDto> patchDocument, [FromRoute] int id)
    {
        var customerDB = Data.Instance.Customers.FirstOrDefault(x => x.Id == id);

        if (customerDB == null) return NotFound();

        var customerPatch = new CustomerForPatchDto
        {
            FirstName = customerDB.FirstName,
            LastName = customerDB.LastName,
            Cpf = customerDB.Cpf
        };

        patchDocument.ApplyTo(customerPatch);

        customerDB.FirstName = customerPatch.FirstName;
        customerDB.LastName = customerPatch.LastName;
        customerDB.Cpf = customerPatch.Cpf;

        return NoContent();
    }

    [HttpGet("with-address")]
    public ActionResult<IEnumerable<CustomerWithAddressDto>> GetCustomerWithAddress()
    {
        var customersDB = Data.Instance.Customers;

        var customersReturn = customersDB.Select(x => new CustomerWithAddressDto
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Cpf = x.Cpf,
            Addresses = x.Addresses.Select(address => new AddressDto
            {
                Id = address.Id,
                City = address.City,
                Street = address.Street
            }).ToList()
        });

        return Ok(customersReturn);
    }
}