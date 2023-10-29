using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Get
        public IActionResult Upsert(int? id)
        {
            Company company = new();
            if(id == null || id== 0)
            {
                return View(company);
            }
            else
            {
                company = _unitOfWork.Company.GetFirstOrDefault(x => x.Id == id);
                return View(company);
            }
        }






        

        

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company company)
        {
            if(ModelState.IsValid)
            {
                if(company.Id == 0 || company.Id == null)
                {
                    _unitOfWork.Company.Add(company);
                    TempData["success"] = "Company created successfully";
                }
                else
                {
                    _unitOfWork.Company.Update(company);
                    TempData["success"] = "Company updated successfully";
                }
                _unitOfWork.Save();
                

                return RedirectToAction("Index");
            }
            return View(company);

        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var companies = _unitOfWork.Company.GetAll();
            return Json(new
            {
                data = companies,
            });

        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var companyFromDb = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);

            if (companyFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }

            _unitOfWork.Company.Remove(companyFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });

        }

        #endregion

    }
}
