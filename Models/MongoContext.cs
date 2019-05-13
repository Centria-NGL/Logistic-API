using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace MongoMVC.Models
{
    public class MongoContext
    {
        private readonly IMongoDatabase _mongoDb;
        public MongoContext()
        
            var client = new MongoClient("mongodb+srv://Logistics:<password>@logistics-hr6zq.gcp.mongodb.net/test?retryWrites=true");
            _mongoDb = client.GetDatabase("Logistics");
        }
        public IMongoCollection<Company> Company
        {
            get
            {
                return _mongoDb.GetCollection<Company>("Company");
            }
        }

    }
}