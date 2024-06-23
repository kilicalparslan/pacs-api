namespace pdksApi.Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message, string type) : base(false, message, type)
        {
        }
        public ErrorResult() : base(false)
        {
        }
    }
}
