using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectory.Api.DTOs
{
    public class EntryQueryDTO : QueryDTO
    {
        public int? PhoneBookId { get; set; }

        public string EntryName { get; set; }
    }
}
