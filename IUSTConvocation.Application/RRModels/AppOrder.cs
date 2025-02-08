namespace IUSTConvocation.Application.RRModels;

public class AppOrderRequest
{
    public Guid GownId { get; set; }

    public Guid ConvocationId { get; set; }
}

public class AppOrderResponse
{
    public string OrderId { get; set; } = null!;


    public decimal Amount { get; set; }

    public string Name { get; set; } = null!;


    public string Email { get; set; } = null!;


    public string Contact { get; set; } = string.Empty;


    public string Address { get; set; } = string.Empty;


    public string Description { get; set; } = string.Empty;

    public string Receipt { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;
}