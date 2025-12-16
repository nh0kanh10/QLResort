using System;

namespace QLResort.Core.ClassHoTro
{
    // Non-generic version
    

    // Generic version
    public class OperationResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string ErrorMessage 
        { 
            get => Message; 
            set => Message = value; 
        }
        public T Data { get; set; }

        public static OperationResult<T> Ok(T data = default, string message = "")
        {
            return new OperationResult<T> { Success = true, Data = data, Message = message };
        }

        public static OperationResult<T> Fail(string message)
        {
            return new OperationResult<T> { Success = false, Message = message };
        }
    }
}
