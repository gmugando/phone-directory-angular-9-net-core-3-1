using PhoneDirectory.Data.Domain.Models;
using PhoneDirectory.Data.Domain.Repositories;
using PhoneDirectory.Data.Domain.Services;
using PhoneDirectory.Data.Domain.Services.Comms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Data.Services
{
    public class PhoneBookService : IPhoneBookService
    {
        private readonly IPhoneBookRepository _phonebookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PhoneBookService(IPhoneBookRepository phonebookRepository, IUnitOfWork unitOfWork)
        {
            _phonebookRepository = phonebookRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PhoneBook>> ListAsync()
        {
            return await _phonebookRepository.ListAsync();
        }

        public async Task<PhoneBookResponse> SaveAsync(PhoneBook phonebook)
        {
            try
            {
                await _phonebookRepository.AddAsync(phonebook);
                await _unitOfWork.CompleteAsync();

                return new PhoneBookResponse(phonebook);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new PhoneBookResponse($"An error occurred when saving the phonebook: {ex.Message}");
            }
        }

        public async Task<PhoneBookResponse> UpdateAsync(int id, PhoneBook phonebook)
        {
            var existingPhonebook = await _phonebookRepository.FindByIdAsync(id);

            if (existingPhonebook == null)
                return new PhoneBookResponse("PhoneBook not found.");

            existingPhonebook.PhoneBookName = phonebook.PhoneBookName;

            try
            {
                _phonebookRepository.Update(existingPhonebook);
                await _unitOfWork.CompleteAsync();

                return new PhoneBookResponse(existingPhonebook);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new PhoneBookResponse($"An error occurred when updating the phonebook: {ex.Message}");
            }
        }

        public async Task<PhoneBookResponse> DeleteAsync(int id)
        {
            var existingPhonebook = await _phonebookRepository.FindByIdAsync(id);

            if (existingPhonebook == null)
                return new PhoneBookResponse("Phonebook not found.");

            try
            {
                _phonebookRepository.Remove(existingPhonebook);
                await _unitOfWork.CompleteAsync();

                return new PhoneBookResponse(existingPhonebook);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new PhoneBookResponse($"An error occurred when deleting the phonebook: {ex.Message}");
            }
        }
    }
}
