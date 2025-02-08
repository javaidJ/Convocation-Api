using IUSTConvocation.Domain.Entities;
using IUSTConvocation.Domain.Interfaces;

namespace IUSTConvocation.Domain.Entities;

public class Department : BaseModal, IBaseModal
{

    public string DepartmentName { get; set; } = string.Empty;

    public bool IsDeleted { get; set; }

}
