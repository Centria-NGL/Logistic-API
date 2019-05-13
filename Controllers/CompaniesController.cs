using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MongoMVC.Models;
using System.Threading.Tasks;


namespace MongoMVC.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ICompanyRepository _DataAccessProvider = new CompanyRepository();
        public async Task<ActionResult> Index()
        {
            IEnumerable<Company> companies = await _DataAccessProvider.GetCompanies();
            return View(companies);
        }

        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = await _DataAccessProvider.GetCompany(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Companyname,Origin,Destination,Depdate,Arrdate,Availablespace,Transporttype")] Company company)
        {
            if (ModelState.IsValid)
            {
                await _DataAccessProvider.Add(company);
                return RedirectToAction("Index");
            }

            return View(company);
        }

        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = await _DataAccessProvider.GetCompany(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Companyname,Origin,Destination,Depdate,Arrdate,Availablespace,Transporttype")] Company company)
        {
            if (ModelState.IsValid)
            {
                await _DataAccessProvider.Update(company);
                return RedirectToAction("Index");
            }
            return View(company);
        }

        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Company company = await _DataAccessProvider.GetCompany(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await _DataAccessProvider.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
