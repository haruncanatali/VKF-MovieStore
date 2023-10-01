namespace MovieStore.Application.Common.Models;

public class BaseResponseModel<T>
{
    public bool Succeeded { get; set; }

    public string[] Errors { get; set; }

    public string FriendlyMessage { get; set; }

    public T Data { get; set; }

    public BaseResponseModel<T> Success( T data, string friendlyMessage = "")
    {
        return new BaseResponseModel<T>
        {
            Data = data,
            FriendlyMessage = friendlyMessage,
            Succeeded = true
        };
    }

    public BaseResponseModel<T> Failure(IEnumerable<string> errors)
    {
        return new BaseResponseModel<T>
        {
            Errors = errors.ToArray(),
            Succeeded = false
        };
    }
}