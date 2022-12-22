using kalendar.Models;
using MongoDB.Driver;

namespace kalendar.Services
{
    public class UpominkyService
    {
        private readonly IMongoCollection<Upominka> _udalostiCollection;

        public UpominkyService(IMongoClient client)
        {
            var database = client.GetDatabase("kalendar");
            _udalostiCollection = database.GetCollection<Upominka>("upominky");
        }


        public async Task<List<Upominka>> GetAsync() =>
            await _udalostiCollection.Find(x => true).ToListAsync();

        public async Task<Upominka?> GetAsync(string id) =>
            await _udalostiCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Upominka newUpominka) =>
            await _udalostiCollection.InsertOneAsync(newUpominka);

        public async Task UpdateAsync(string id, Upominka updatedUpominka) =>
            await _udalostiCollection.ReplaceOneAsync(x => x.Id == id, updatedUpominka);

        public async Task RemoveAsync(string id) =>
            await _udalostiCollection.DeleteOneAsync(x => x.Id == id);
    }
}
