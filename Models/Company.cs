using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoMVC.Models
{

        public class Company
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }
            public string Companyname { get; set; }
            public string Origin { get; set; }
            public string Destination { get; set; }
            public int Depdate { get; set; }
            public int Arrdate { get; set; }
            public int Availablespace { get; set; }
            public string Transporttype { get; set; }
        }
}
