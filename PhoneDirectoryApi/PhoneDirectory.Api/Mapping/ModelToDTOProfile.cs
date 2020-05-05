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
    public class ModelToDTOProfile : Profile
    {
        public ModelToDTOProfile()
        {
            CreateMap<PhoneBook, PhoneBookDTO>();

            CreateMap<Entry, EntryDTO>();

            CreateMap<QueryResult<Entry>, QueryResultDTO<EntryDTO>>();

            CreateMap<EntriesQuery, EntryQueryDTO>();
        }
    }
}
