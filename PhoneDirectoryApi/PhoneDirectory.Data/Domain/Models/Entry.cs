using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectory.Data.Domain.Models
{
    public class Entry
    {
        public int EntryId { get; set; }

        public int PhoneBookId { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public PhoneBook PhoneBook { get; set; }
    }
}
