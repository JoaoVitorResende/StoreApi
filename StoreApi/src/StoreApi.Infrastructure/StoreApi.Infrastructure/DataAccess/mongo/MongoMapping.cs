using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using StoreApi.Domain.Entities;

namespace StoreApi.Infrastructure.DataAccess.mongo
{
    internal static class MongoMapping
    {
        public static void Register()
        {
            // O registro só pode acontecer uma vez por execução
            if (BsonClassMap.IsClassMapRegistered(typeof(Item)))
                return;

            BsonClassMap.RegisterClassMap<Item>(map =>
            {
                map.AutoMap();

                map.MapIdProperty(i => i.Id)
                   .SetIdGenerator(StringObjectIdGenerator.Instance)
                   .SetSerializer(new StringSerializer(BsonType.ObjectId));

                // Por padrão o decimal vai como texto no Mongo; Decimal128 permite ordenar e comparar como número
                map.MapMember(i => i.Price).SetSerializer(new DecimalSerializer(BsonType.Decimal128));
                map.MapMember(i => i.Quantity).SetSerializer(new DecimalSerializer(BsonType.Decimal128));
            });
        }
    }
}
