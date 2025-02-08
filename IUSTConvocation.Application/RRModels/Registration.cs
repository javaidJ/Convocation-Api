using IUSTConvocation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUSTConvocation.Application.RRModels
{
   
    public class RegistrationRequest
    {
        public Guid? EntityId { get; set; }

        public Module Module { get; set; }


        public ParticipantRole ParticipantRole { get; set; }

        public Guid ConvocationId { get; set; }
    }



    public class RegistrationResponse : RegistrationRequest
    
    {
        public Guid Id { get; set; }

        public DateTimeOffset CreatedOn { get; set; }


        public string Name { get; set; } = string.Empty;

        public Gender Gender { get; set; }

        public string Email { get; set; } = string.Empty;

        public string ContactNo { get; set; } = string.Empty;

        public DateTimeOffset? ConvocationDate { get; set; } = null!;

        public int DaysLeft { get; set; }

  
    }


    public class PendingStudentRegistrationResponse: RegistrationResponse
    {
        public RegistrationStatus RegistrationStatus { get; set; }
    }
    public class RegistrationUpdate: RegistrationRequest
    {
        public Guid  Id { get; set; }
    }

    public class StudentRegistrationUpdateStatusRequest
    {
        public Guid? StudentId { get; set; }

        public Guid ConvocationId { get; set; }

        public RegistrationStatus RegistrationStatus { get; set; }
    }


}
