using kalendar.Models;
using MongoDB.Driver;

namespace kalendar.Services
{
    public class PoznamkyService
    {
        private readonly IMongoCollection<Poznamka> _udalostiCollection;

        public PoznamkyService(IMongoClient client)
        {
            var database = client.GetDatabase("kalendar");
            _udalostiCollection = database.GetCollection<Poznamka>("poznamky");
        }


        public async Task<List<Poznamka>> GetAsync() =>
            await _udalostiCollection.Find(x => true).ToListAsync();

        public async Task<Poznamka?> GetAsync(string id) =>
            await _udalostiCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Poznamka newUdalost) =>
            await _udalostiCollection.InsertOneAsync(newUdalost);

        public async Task UpdateAsync(string id, Poznamka updatedUdalost) =>
            await _udalostiCollection.ReplaceOneAsync(x => x.Id == id, updatedUdalost);

        public async Task RemoveAsync(string id) =>
            await _udalostiCollection.DeleteOneAsync(x => x.Id == id);
    }
}
