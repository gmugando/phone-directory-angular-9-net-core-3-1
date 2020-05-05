using AutoMapper;
using PhoneDirectory.Api.DTOs;
using PhoneDirectory.Data.Domain.Models;
using PhoneDirectory.Data.Domain.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectory.Api.Mapping
{
    public class DTOToModelProfile : Profile
    {
        public DTOToModelProfile()
        {
            CreateMap<PhoneBookDTO, PhoneBook>();

            CreateMap<SavePhoneBookDTO, PhoneBook>();

            CreateMap<SaveEntryDTO, Entry>();

            CreateMap<EntryQueryDTO, EntryDTO>();

            CreateMap<EntryQueryDTO, EntriesQuery>();
        }
    }
}
