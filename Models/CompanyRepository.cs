using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace MongoMVC.Models
{
    public class CompanyRepository : ICompanyRepository
    {
        MongoContext db = new MongoContext();
        public async Task Add(Company company)
        {
            try
            {
                await db.Company.InsertOneAsync(company);
            }
            catch
            {
                throw;
            }
        }
        public async Task<Company> GetCompany(string id)
        {
            try
            {
                FilterDefinition<Company> filter = Builders<Company>.Filter.Eq("Id", id);
                return await db.Company.Find(filter).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Company>> GetCompanies()
        {
            try
            {
                return await db.Company.Find(_ => true).ToListAsync();
            }
            catch
            {
                throw;    
            }
        }
        public async Task Update(Company company)
        {
            try
            {
                await db.Company.ReplaceOneAsync(filter: g => g.Id == company.Id, replacement: company);
            }
            catch
            {
                throw;
            }
        }
        public async Task Delete(string id)
        {
            try
            {
                FilterDefinition<Company> data = Builders<Company>.Filter.Eq("Id", id);
                await db.Company.DeleteOneAsync(data);
            }
            catch
            {
                throw;
            }
        }
    }
}
