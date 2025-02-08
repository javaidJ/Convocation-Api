using IUSTConvocation.Domain.Enums;
using IUSTConvocation.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUSTConvocation.Domain.Entities;

public class Employee : BaseModal, IBaseModal
{
	public string Name { get; set; } = string.Empty;

	public string? EmpCode { get; set; } = string.Empty;

    public Designation? Designation { get; set; }

    public bool IsDeleted { get; set; }


    public Guid? DepartemntId { get; set; }


    [ForeignKey(nameof(DepartemntId))]
    public Department Department { get; set; } = null!;


    [ForeignKey(nameof(Id))]
	public User User { get; set; } = null!;

}
