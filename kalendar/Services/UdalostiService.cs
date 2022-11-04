using kalendar.Models;
using MongoDB.Driver;

namespace kalendar.Services
{
    public class UdalostiService
    {
        private readonly IMongoCollection<Udalost> _udalostiCollection;

        public UdalostiService(IMongoClient client)
        {
            var database = client.GetDatabase("kalendar");
            _udalostiCollection = database.GetCollection<Udalost>("udalosti");
        }


        public async Task<List<Udalost>> GetAsync() =>
            await _udalostiCollection.Find(x => true).ToListAsync();

        public async Task<Udalost?> GetAsync(string id) =>
            await _udalostiCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Udalost newUdalost) =>
            await _udalostiCollection.InsertOneAsync(newUdalost);

        public async Task UpdateAsync(string id, Udalost updatedUdalost) =>
            await _udalostiCollection.ReplaceOneAsync(x => x.Id == id, updatedUdalost);

        public async Task RemoveAsync(string id) =>
            await _udalostiCollection.DeleteOneAsync(x => x.Id == id);
    }
}
