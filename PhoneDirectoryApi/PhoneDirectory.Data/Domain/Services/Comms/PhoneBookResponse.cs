using PhoneDirectory.Data.Domain.Models;

namespace PhoneDirectory.Data.Domain.Services.Comms
{
    public class PhoneBookResponse :  BaseResponse<PhoneBook>
    {
        public PhoneBookResponse(PhoneBook phoneBook) : base(phoneBook)
        { }

        public PhoneBookResponse(string message) : base(message)
        { }
    }
}
