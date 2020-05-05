using PhoneDirectory.Data.Domain.Models;
using PhoneDirectory.Data.Domain.Models.Queries;
using PhoneDirectory.Data.Domain.Repositories;
using PhoneDirectory.Data.Domain.Services;
using PhoneDirectory.Data.Domain.Services.Comms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Data.Services
{
    public class EntryService : IEntryService
    {
        private readonly IEntryRepository _entryRepository;
        private readonly IPhoneBookRepository _phonebookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EntryService(IEntryRepository entryRepository, IPhoneBookRepository phonebookRepository, IUnitOfWork unitOfWork)
        {
            _entryRepository = entryRepository;
            _phonebookRepository = phonebookRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<QueryResult<Entry>> ListAsync(EntriesQuery query)
        {
            return await _entryRepository.ListAsync(query);
        }

        public async Task<EntryResponse> SaveAsync(Entry entry)
        {
            try
            {
                var existingPhonebook = await _phonebookRepository.FindByIdAsync(entry.PhoneBookId);
                if (existingPhonebook == null)
                    return new EntryResponse("Invalid phonebook.");

                await _entryRepository.AddAsync(entry);
                await _unitOfWork.CompleteAsync();

                return new EntryResponse(entry);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new EntryResponse($"An error occurred when saving the entry: {ex.Message}");
            }
        }

        public async Task<EntryResponse> UpdateAsync(int id, Entry entry)
        {
            var existingEntry = await _entryRepository.FindByIdAsync(id);

            if (existingEntry == null)
                return new EntryResponse("Entry not found.");

            var existingPhonebook = await _phonebookRepository.FindByIdAsync(entry.PhoneBookId);
            if (existingPhonebook == null)
                return new EntryResponse("Invalid Phonebook.");

            existingEntry.Name = entry.Name;
            existingEntry.PhoneNumber = entry.PhoneNumber;
            existingEntry.PhoneBookId = entry.PhoneBookId;

            try
            {
                _entryRepository.Update(existingEntry);
                await _unitOfWork.CompleteAsync();

                return new EntryResponse(existingEntry);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new EntryResponse($"An error occurred when updating the entry: {ex.Message}");
            }
        }

        public async Task<EntryResponse> DeleteAsync(int id)
        {
            var existingEntry = await _entryRepository.FindByIdAsync(id);

            if (existingEntry == null)
                return new EntryResponse("Entry not found.");

            try
            {
                _entryRepository.Remove(existingEntry);
                await _unitOfWork.CompleteAsync();

                return new EntryResponse(existingEntry);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new EntryResponse($"An error occurred when deleting the entry: {ex.Message}");
            }
        }
    }
}
