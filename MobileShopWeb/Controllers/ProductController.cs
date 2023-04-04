using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobileShopWeb.Infrastructure.Interfaces;
using MobileShopWeb.Models;
using MobileShopWeb.ViewModel;
using System.Drawing;

namespace MobileShopWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> ProductList()
        {
            
            ProductVM vm = new ProductVM();
            vm.Products = await _unitOfWork.Products.GetAll(includeProperties: "Brand");

            foreach (var item in vm.Products)
            {
                var productColorsVM = _unitOfWork.Products.BindProductVM(item);

                var productColorsList = await _unitOfWork.Colors.GetProductColors(productColorsVM.Id);
                if(productColorsList.Count > 0)
                {
                    productColorsVM.Colors = _unitOfWork.Products.BindCommaSeparatedColors(productColorsList);

                    vm.productAndColors.Add(productColorsVM);
                }
              
            }

            return View(vm);
        }

        public async Task<IActionResult> Create()
        {

            CreateProductVM vm = new CreateProductVM();

            var Brands = await _unitOfWork.Brands.GetAll();
            var Colors = await _unitOfWork.Colors.GetAll();

            vm.BrandsListItem = _unitOfWork.Brands.BindDropDownListBrand(Brands);
            vm.ColorsListItem = _unitOfWork.Colors.BindDropDownListColor(Colors);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductVM vm)
        {
            if (ModelState.IsValid)
            {
                var productExists = await _unitOfWork.Products.GetById(x => x.ProductName.ToLower() == vm.Products.ProductName.ToLower());
                if (productExists != null)
                {
                    TempData["ErrorMsg"] = "Name Already Exists ! " + productExists.ProductName;
                    return View(vm);
                }


                await _unitOfWork.Products.Add(vm.Products);
                await _unitOfWork.Save();

                var newProductColorList = await _unitOfWork.ProductColors.EditProductColors(vm.Color, vm.Products.Id);
                await _unitOfWork.ProductColors.AddRange(newProductColorList);
                await _unitOfWork.Save();

                TempData["SuccessMsg"] = "Record Added Successfully !";
                return RedirectToAction("ProductList");
            }
            else
                TempData["ErrorMsg"] = "Something Went Wrong !";

            return View(vm);

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? ProductId)
        {
            var deleterecord = await _unitOfWork.Products.GetById(x => x.Id == ProductId);
            if (deleterecord == null)
                return Json(new { msg = "Error in fetching data", success = false });

            _unitOfWork.Products.Delete(deleterecord);
            await _unitOfWork.Save();

            return Json((new { msg = "Data Deleted Successfully", success = true }));
        }

        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null || id == 0)
                    return NotFound();

            CreateProductVM vm = new CreateProductVM();
            var getProduct = await _unitOfWork.Products.GetById(x => x.Id == id, "Brand");
            var selectedProductColors = await _unitOfWork.Colors.GetProductColorsWithIds(getProduct.Id);
            vm.Products = getProduct;
            vm.ColorsListItem = selectedProductColors;
            vm.BrandsListItem = _unitOfWork.Brands.SelectedBrandDropDownList(getProduct);

            if (getProduct == null)
                return NotFound();

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreateProductVM vm)
        {
            if (ModelState.IsValid)
            {

                var oldProductColorsList= await _unitOfWork.ProductColors.GetAllById(x => x.ProductId == vm.Products.Id);
                 _unitOfWork.ProductColors.DeleteRange(oldProductColorsList.ToList());

                _unitOfWork.Products.Update(vm.Products);

                var newProductColorList = await _unitOfWork.ProductColors.EditProductColors(vm.Color, vm.Products.Id);
                await _unitOfWork.ProductColors.AddRange(newProductColorList);

                 await _unitOfWork.Save();

                TempData["SuccessMsg"] = "Data Updated Successfully !";
                return RedirectToAction("ProductList");
            }
            else
                TempData["ErrorMsg"] = "Something Went Wrong !";

            return View(vm);
        }
    }
}
