using System;
using System.Collections.Generic;

namespace PhoneDirectory.Data.Domain.Models
{
    public class PhoneBook
    {
        public PhoneBook()
        {
            Entries = new List<Entry>();
        }
        public int PhoneBookId { get; set; }
        public string PhoneBookName { get; set; }
        public List<Entry> Entries { get; set; }
    }
}
