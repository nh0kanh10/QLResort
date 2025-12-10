using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model.ToolHoTro
{
    public class OperationResult<T>
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }

        public static OperationResult<T> Ok(T data = default)
        {
            return new OperationResult<T> { Success = true, Data = data };
        }

        public static OperationResult<T> Fail(string error)
        {
            return new OperationResult<T> { Success = false, ErrorMessage = error };
        }
    }
}
