

namespace Shared.Dto
{
      public class ResponseChecker<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}