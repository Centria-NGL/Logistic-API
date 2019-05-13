using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoMVC.Models
{
        public interface ICompanyRepository
        {
            Task Add(Company company);
            Task Update(Company company);
            Task Delete(string id);
            Task<Company> GetCompany(string id);
            Task<IEnumerable<Company>> GetCompanies();
        }
}

