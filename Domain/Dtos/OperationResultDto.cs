using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Domain.Dtos
{
    public class OperationResultDto
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public OperationResultDto(bool? status, string message)
        {
            Status = status ?? false;
            Message = message;
        }

    }

    public class OperationResultDto<T> : OperationResultDto
    {
        public T? Result { get; set; }
        public OperationResultDto(bool status, string message, T? result) : base(status, message)
        {
            Result = result;
        }

    }
}
