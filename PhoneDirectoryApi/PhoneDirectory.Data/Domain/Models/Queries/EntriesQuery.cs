using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectory.Data.Domain.Models.Queries
{
    public class EntriesQuery : Query
    {
        public int? PhoneBookId { get; set; }

        public string EntryName { get; set; }


        public EntriesQuery(int? phonebookId, string entryName, int page, int itemsPerPage) : base(page, itemsPerPage)
        {
            PhoneBookId = phonebookId;

            EntryName = entryName;
        }
    }
}
