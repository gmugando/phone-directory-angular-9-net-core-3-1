using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectory.Api.DTOs
{
    public class SaveEntryDTO
    {
        public int PhoneBookId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
