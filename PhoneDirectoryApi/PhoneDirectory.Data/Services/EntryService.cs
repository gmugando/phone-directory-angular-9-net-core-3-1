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
        //private readonly IMemoryCache _cache;

        public EntryService(IEntryRepository entryRepository, IPhoneBookRepository phonebookRepository, IUnitOfWork unitOfWork)
        {
            _entryRepository = entryRepository;
            _phonebookRepository = phonebookRepository;
            _unitOfWork = unitOfWork;
            //_cache = cache;
        }

        public async Task<QueryResult<Entry>> ListAsync(EntriesQuery query)
        {
            // Here I list the query result from cache if they exist, but now the data can vary according to the category ID, page and amount of
            // items per page. I have to compose a cache to avoid returning wrong data.
            //string cacheKey = GetCacheKeyForProductsQuery(query);

            //var products = await _cache.GetOrCreateAsync(cacheKey, (entry) => {
            //    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
            //    return _productRepository.ListAsync(query);
            //});

            //return products;
            return await _entryRepository.ListAsync(query);
        }

        public async Task<EntryResponse> SaveAsync(Entry entry)
        {
            try
            {
                /*
                 Notice here we have to check if the category ID is valid before adding the product, to avoid errors.
                 You can create a method into the CategoryService class to return the category and inject the service here if you prefer, but 
                 it doesn't matter given the API scope.
                */
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

        //private string GetCacheKeyForProductsQuery(ProductsQuery query)
        //{
        //    string key = CacheKeys.ProductsList.ToString();

        //    if (query.CategoryId.HasValue && query.CategoryId > 0)
        //    {
        //        key = string.Concat(key, "_", query.CategoryId.Value);
        //    }

        //    key = string.Concat(key, "_", query.Page, "_", query.ItemsPerPage);
        //    return key;
        //}
    }
}
