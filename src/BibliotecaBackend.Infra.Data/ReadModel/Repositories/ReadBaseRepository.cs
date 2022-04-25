using BibliotecaBackend.Domain.Repositories;
using BibliotecaBackend.Infra.Data.ReadModel.DTOs;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBackend.Infra.Data.ReadModel.Repositories
{
    public class ReadBaseRepository<T> : IBaseRepository<T>
        where T : BaseDTO
    {
        private readonly IMongoCollection<T> _collection;

        public ReadBaseRepository(IOptions<MongoDbOptions> options)
        {
            var mongoClient = new MongoClient(
            options.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                options.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<T>(
                options.Value.CollectionName);
        }


        public async Task AddAsync(T aggregateRoot)
        {
            await _collection.InsertOneAsync(aggregateRoot);
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _collection.Find(x => x.Key.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task Remove(T aggregateRoot)
        {
            await _collection.DeleteOneAsync(x => x.Id == aggregateRoot.Id);
        }

        public async Task Update(T aggregateRoot)
        {
            var filters = 
            await _collection.ReplaceOneAsync(x => x.Id == aggregateRoot.Id, aggregateRoot);
        }
    }
}
