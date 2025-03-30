namespace Retech.Application.Models;
public class ApiResult
{
    protected ApiResult(bool succeeded, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Errors = errors;
    }

    public bool Succeeded { get; set; }
    public IEnumerable<string> Errors { get; set; }

    public static ApiResult Success()
    {
        return new ApiResult(true, new List<string>());
    }

    public static ApiResult Failure(IEnumerable<string> errors)
    {
        return new ApiResult(false, errors);
    }
}

public class ApiResult<T>
{
    private ApiResult()
    {
    }

    private ApiResult(bool succeeded, T result, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Result = result;
        Errors = errors;
    }

    public bool Succeeded { get; set; }

    public T? Result { get; set; }

    public IEnumerable<string> Errors { get; set; }

    public static ApiResult<T> Success(T result)
    {
        return new ApiResult<T>(true, result, new List<string>());
    }

    public static ApiResult<T> Failure(IEnumerable<string> errors)
    {
        return new ApiResult<T>(false, default, errors);
    }
}
