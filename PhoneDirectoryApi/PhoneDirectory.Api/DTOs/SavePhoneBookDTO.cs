using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectory.Api.DTOs
{
    public class SavePhoneBookDTO
    {
        [Required]
        [MaxLength(30)]
        public string PhoneBookName { get; set; }
    }
}
