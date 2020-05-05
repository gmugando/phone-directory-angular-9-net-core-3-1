using PhoneDirectory.Data.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectory.Data.Domain.Services.Comms
{
    public class EntryResponse: BaseResponse<Entry>
    {
        public EntryResponse(Entry entry) : base(entry) { }

        public EntryResponse(string message) : base(message) { }
    }
}
