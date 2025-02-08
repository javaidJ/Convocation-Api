using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUSTConvocation.Application.RRModels;
public class AttendeRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Designation { get; set; }
    public bool IsStudent { get; set; }
    public int? EntityId { get; set; }
}

public class AttendeResponse : AttendeRequest
{
    public Guid Id { get; set; }
}
public class AttendeUpdateRequest : AttendeRequest 
{
    public Guid Id { get; set; }
}

