using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using StoreApi.Domain.Entities;
using StoreApi.Domain.Repositories.Items;
using StoreApi.Infrastructure.DataAccess.mongo;

namespace StoreApi.Infrastructure.DataAccess.Mongo.Repositories
{
    internal class ItemRepository : IItemReadOnlyRepository, IItemWriteOnlyRepository
    {
        private readonly MongoContext _context;

        public ItemRepository(MongoContext context)
        {
            _context = context;
        }

        // O Mongo grava na hora, por isso não existe Commit aqui
        public async Task Add(Item item)
        {
            await _context.Items.InsertOneAsync(item);
        }

        public async Task Update(Item item)
        {
            if (!ObjectId.TryParse(item.Id, out _))
                return;

            await _context.Items.ReplaceOneAsync(i => i.Id == item.Id, item);
        }

        public async Task Delete(string id)
        {
            if (!ObjectId.TryParse(id, out _))
                return;

            await _context.Items.DeleteOneAsync(i => i.Id == id);
        }

        public async Task<Item?> GetById(string id)
        {
            // Id que não é um ObjectId válido estouraria exceção no driver
            if (!ObjectId.TryParse(id, out _))
                return null;

            return await _context.Items
                .Find(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Item>> GetAll()
        {
            return await _context.Items
               .Find(_ => true)
               .ToListAsync();
        }
    }
}