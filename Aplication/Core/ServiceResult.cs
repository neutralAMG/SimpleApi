

namespace Aplication.Core
{
    public class ServiceResult<TData> where TData : class
    {
        public ServiceResult()
        {
            IsSuccess = true;
        }
        public bool IsSuccess { get; set; }
        public string? message {  get; set; }
        
        public TData? Data { get; set;}
    }
}
