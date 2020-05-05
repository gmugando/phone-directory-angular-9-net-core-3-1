namespace PhoneDirectory.Api.DTOs
{
    public class EntryDTO
    {
        public int EntryId { get; set; }

        public int PhoneBookId { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public PhoneBookDTO PhoneBook { get; set; }
    }
}
