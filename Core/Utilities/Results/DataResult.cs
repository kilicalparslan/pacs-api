

using Newtonsoft.Json;

namespace pdksApi.Core.Utilities.Results
{
    [Serializable]
    public class DataResult<T> : Result, IDataResult<T>
    {
		[JsonConstructor]
		public DataResult(T data, bool success, string message, string type) : base(success, message, type)
        {
            Data = data;
        }
	
		public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
