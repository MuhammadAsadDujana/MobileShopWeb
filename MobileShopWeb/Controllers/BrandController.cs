using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileShopWeb.Infrastructure.Interfaces;
using MobileShopWeb.Models;
using MobileShopWeb.ViewModel;

namespace MobileShopWeb.Controllers
{
    public class BrandController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> BrandList()
        {
            var BrandList = await  _unitOfWork.Brands.GetBrandTotalProducts();
            return View(BrandList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brand brands)
        {
            if (ModelState.IsValid)
            {
                var brandExists = await _unitOfWork.Brands.GetById(x => x.BrandName.ToLower().Trim() == brands.BrandName.ToLower().Trim());
                if(brandExists != null)
                {
                    TempData["ErrorMsg"] = "Name Already Exists ! " + brandExists.BrandName;
                    return View(brands);
                }

                await _unitOfWork.Brands.Add(brands);
                await _unitOfWork.Save();

                TempData["SuccessMsg"] = "Record Added Successfully !";
                return RedirectToAction("BrandList");
            }
            else
                TempData["ErrorMsg"] = "Something Went Wrong !";

            return View(brands);

        }

        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null || id == 0)
                return NotFound();

            var brand = await _unitOfWork.Brands.GetById(x => x.Id == id);

            if (brand == null)
                return NotFound();

            return View(brand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Brand brands)
        {
            if (ModelState.IsValid)
            {

                _unitOfWork.Brands.Update(brands);
                await _unitOfWork.Save();

                TempData["SuccessMsg"] = "Data Updated Successfully !";
                return RedirectToAction("BrandList");
            }
            else
                  TempData["ErrorMsg"] = "Something Went Wrong !";

            return View(brands);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? BrandId)
        {
            var deleterecord = await _unitOfWork.Brands.GetById(x => x.Id == BrandId);
            if (deleterecord == null)
                return Json(new { msg = "Error in fetching data", success = false });

             _unitOfWork.Brands.Delete(deleterecord);
            await _unitOfWork.Save();

            return Json((new { msg = "Data Deleted Successfully", success = true }));
        }
    }
}
