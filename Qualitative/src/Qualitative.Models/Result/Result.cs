using Qualitative.Models.Entities;

namespace Qualitative.Models.Result
{
    public class Result
    {
        public bool Success { get; set; }
        public ErrorType ErrorType { get; set; }
    }

    public class Result<TData> : Result
    {
        public TData Data { get; set; }
    }
}
