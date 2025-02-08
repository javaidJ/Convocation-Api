namespace IUSTConvocation.Application.Shared;

public class APIResponse<T>
{
    private readonly bool isSuccess;
    private readonly int statusCode;
    private readonly string message;
    private readonly T? result;

    public bool IsSuccess => isSuccess;
    public int StatusCode => statusCode;
    public string Message => message;
    public T? Result => result;

    public APIResponse(T? result, int statusCode = APIStatusCodes.OK, string message = "Success")
    {
        if ((int)statusCode < 100 || (int)statusCode >= 600)
        {
            throw new ArgumentException(APIMessages.InvaildStatusCode);
        }

        isSuccess = true;
        this.statusCode = statusCode;
        this.message = message;
        this.result = result;
    }

    public APIResponse(string message, int statusCode = APIStatusCodes.BadRequest)
    {
        if ((int)statusCode < 100 || (int)statusCode >= 600)
        {
            throw new ArgumentException(APIMessages.InvaildStatusCode);
        }

        isSuccess = false;
        this.statusCode = statusCode;
        this.message = message;
        this.result = default;
    }

    // Additional Constructors
    public APIResponse(T result, string message, int statusCode = APIStatusCodes.OK)
        : this(result, statusCode, message)
    {
    }

    public APIResponse(int statusCode = APIStatusCodes.OK, string message = "Success")
        : this(default, statusCode, message)
    {
    }

    // Static Factory Methods
    public static APIResponse<T> SuccessResponse(T? result, int statusCode = APIStatusCodes.OK, string message = "Success")
    {
        return new APIResponse<T>(result, statusCode, message);
    }


    public static APIResponse<T> SuccessResponse(T? result, string message, int statusCode = APIStatusCodes.OK)
    {
        return new APIResponse<T>(result, statusCode, message);
    }

    public static APIResponse<T> ErrorResponse(string message = "Error", int statusCode = APIStatusCodes.BadRequest)
    {
        return new APIResponse<T>(message, statusCode);
    }
}


//public class APIResponse<T>
//{
//    private readonly bool isSuccess;
//    private readonly int APIStatusCodes;
//    private readonly string message;
//    private readonly T? result;

//    public bool IsSuccess => isSuccess;
//    public int APIStatusCodes => APIStatusCodes;
//    public string Message => message;
//    public T? Result => result;

//    public APIResponse(T? result, int APIStatusCodes = Shared.APIStatusCodes.OK, string message = "Success")
//    {
//        if ((int)APIStatusCodes < 100 || (int)APIStatusCodes >= 600)
//        {
//            throw new ArgumentException(APIMessages.InvaildAPIStatusCodes);
//        }

//        isSuccess = true;
//        this.APIStatusCodes = APIStatusCodes;
//        this.message = message;
//        this.result = result;
//    }

//    public APIResponse(string message, int APIStatusCodes = Shared.APIStatusCodes.BadRequest)
//    {
//        if ((int)APIStatusCodes < 100 || (int)APIStatusCodes >= 600)
//        {
//            throw new ArgumentException(APIMessages.InvaildAPIStatusCodes);
//        }

//        isSuccess = false;
//        this.APIStatusCodes = APIStatusCodes;
//        this.message = message;
//        this.result = default;
//    }

//    // Additional Constructors
//    public APIResponse(T result, string message, int APIStatusCodes = Shared.APIStatusCodes.OK)
//        : this(result, APIStatusCodes, message)
//    {
//    }

//    public APIResponse(int APIStatusCodes = Shared.APIStatusCodes.OK, string message = "Success")
//        : this(default, APIStatusCodes, message)
//    {
//    }

//    // Static Factory Methods
//    public static APIResponse<T> SuccessResponse(T? result, int APIStatusCodes = Shared.APIStatusCodes.OK, string message = "Success")
//    {
//        return new APIResponse<T>(result, APIStatusCodes, message);
//    }


//    public static APIResponse<T> SuccessResponse(T? result,  string message = "Success", int APIStatusCodes = Shared.APIStatusCodes.OK)
//    {
//        return new APIResponse<T>(result, APIStatusCodes, message);
//    }
//    public static APIResponse<T> ErrorResponse(string message = "Error", int APIStatusCodes = Shared.APIStatusCodes.BadRequest)
//    {
//        return new APIResponse<T>(message, APIStatusCodes);
//    }
//}
