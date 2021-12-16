using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace senai.SpMedicalGroup.webApi.Domains
{
    public class Localizacao
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        //definimos que vai ser um id em bson

        [BsonRequired]
        //estamos dizendo que vai ser obrigatório
        public string Latitude { get; set; }

        [BsonRequired]
        public string Longitude { get; set; }
    }
}
