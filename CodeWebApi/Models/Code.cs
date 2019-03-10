using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWebApi.Models
{
    public class Code
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("CodeName")]
        public string CodeName { get; set; }

        [BsonElement("Spy")]
        public string Spy { get; set; }         
    }
}
