namespace pdksApi.Core.Utilities.Results
{

    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
        string Type { get; }
    }
}
