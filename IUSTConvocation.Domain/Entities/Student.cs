using System.ComponentModel.DataAnnotations.Schema;
using IUSTConvocation.Domain.Entities;
using IUSTConvocation.Domain.Enums;
using IUSTConvocation.Domain.Interfaces;

namespace IUSTConvocation.Domain.Entities;

public class Student : BaseModal, IBaseModal
{
    public string RegNumber { get; set; } = string.Empty;


    public string Name { get; set; } = string.Empty;


    public string Parentage { get; set; } = string.Empty;


    public Guid? DepartemntId { get; set; }


    public Course Course { get; set; }


    public int Batch { get; set; }


    public double Percentage { get; set; } 


    public Position Position { get; set; }

    public bool IsDeleted { get; set; }



    #region navigationprops
    [ForeignKey(nameof(Id))]
    public User User { get; set; } = null!;




    [ForeignKey(nameof(DepartemntId))]
    public Department Department { get; set; } = null!;

    #endregion
}
