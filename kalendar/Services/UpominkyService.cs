using kalendar.Models;
using MongoDB.Driver;

namespace kalendar.Services
{
    public class UpominkyService
    {
        private readonly IMongoCollection<Upominka> _upominkyCollection;

        public UpominkyService(IMongoClient client)
        {
            var database = client.GetDatabase("kalendar");
            _upominkyCollection = database.GetCollection<Upominka>("upominky");
        }


        public async Task<List<Upominka>> GetAsync() =>
            await _upominkyCollection.Find(x => true).ToListAsync();

        public async Task<Upominka?> GetAsync(string id) =>
            await _upominkyCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Upominka newUpominka) =>
            await _upominkyCollection.InsertOneAsync(newUpominka);

        public async Task UpdateAsync(string id, Upominka updatedUpominka) =>
            await _upominkyCollection.ReplaceOneAsync(x => x.Id == id, updatedUpominka);

        public async Task RemoveAsync(string id) =>
            await _upominkyCollection.DeleteOneAsync(x => x.Id == id);
    }
}
