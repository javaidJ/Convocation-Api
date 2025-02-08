using IUSTConvocation.Domain.Enums;
using IUSTConvocation.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUSTConvocation.Domain.Entities;

public class Registration : BaseModal, IBaseModal
{
    public Guid EntityId { get; set; }
  

    public Module Module { get; set; }


    public RegistrationStatus RegistrationStatus { get; set; } = RegistrationStatus.Approved;


    public ParticipantRole ParticipantRole { get; set; }


    public Guid ConvocationId { get; set; }


    [ForeignKey(nameof(ConvocationId))]
    public Convocation Convocation { get; set; } = null!;
}
