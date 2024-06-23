

using System.Text.Json.Serialization;

namespace pdksApi.Core.Utilities.Results
{
    public class Result:IResult
    {
		[JsonConstructor]
		public Result(bool success, string message, string type):this(success)
        {
            Message = message;
            Type = type;
        }

        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }
        public string Message { get; }
        public string Type { get; }
    }
}
