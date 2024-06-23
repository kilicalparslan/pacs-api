namespace pdksApi.Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        public SuccessResult(string message, string type) : base(true, message, type)
        {
        }

        public SuccessResult() : base(true)
        {
        }
    }
}
