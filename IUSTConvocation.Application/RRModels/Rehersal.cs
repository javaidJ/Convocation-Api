
namespace IUSTConvocation.Application.RRModels;
public class RehersalRequest
{
    public DateTimeOffset RehersalDate { get; set; }

    public Guid IUSTConvocationId { get; set; }
}

public class RehersalResponse : RehersalRequest
{
    public Guid Id { get; set; }
}

public class RehersalUpdateRequest : RehersalRequest
{
    public Guid Id { get; set; }
}
