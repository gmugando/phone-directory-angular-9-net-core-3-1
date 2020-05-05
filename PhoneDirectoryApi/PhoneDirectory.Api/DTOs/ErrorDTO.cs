using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectory.Api.DTOs
{
    public class ErrorDTO
    {
        public bool Success => false;
        public List<string> Messages { get; private set; }

        public ErrorDTO(List<string> messages)
        {
            this.Messages = messages ?? new List<string>();
        }

        public ErrorDTO(string message)
        {
            this.Messages = new List<string>();

            if (!string.IsNullOrWhiteSpace(message))
            {
                this.Messages.Add(message);
            }
        }
    }
}
