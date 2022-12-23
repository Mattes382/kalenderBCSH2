using kalendar.Models;
using MongoDB.Driver;

namespace kalendar.Services
{
    public class PoznamkyService
    {
        private readonly IMongoCollection<Poznamka> _poznamkyCollection;

        public PoznamkyService(IMongoClient client)
        {
            var database = client.GetDatabase("kalendar");
            _poznamkyCollection = database.GetCollection<Poznamka>("poznamky");
        }


        public async Task<List<Poznamka>> GetAsync() =>
            await _poznamkyCollection.Find(x => true).ToListAsync();

        public async Task<Poznamka?> GetAsync(string id) =>
            await _poznamkyCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Poznamka newPoznamka) =>
            await _poznamkyCollection.InsertOneAsync(newPoznamka);

        public async Task UpdateAsync(string id, Poznamka updatedPoznamka) =>
            await _poznamkyCollection.ReplaceOneAsync(x => x.Id == id, updatedPoznamka);

        public async Task RemoveAsync(string id) =>
            await _poznamkyCollection.DeleteOneAsync(x => x.Id == id);
    }
}
