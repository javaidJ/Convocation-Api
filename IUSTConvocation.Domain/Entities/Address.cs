using System.ComponentModel.DataAnnotations.Schema;
using IUSTConvocation.Domain.Enums;
using IUSTConvocation.Domain.Interfaces;

namespace IUSTConvocation.Domain.Entities;

public class Address : BaseModal, IBaseModal
{
    public string Country { get; set; } = string.Empty;


    public string State { get; set; } = string.Empty;


    public string City { get; set; } = string.Empty;


    public int PostalCode { get; set; }

    public string AddressLine { get; set; } = string.Empty;


    public Guid EntityId { get; set; }


    public Module   Module{ get; set; }
}
