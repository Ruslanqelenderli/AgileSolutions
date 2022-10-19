using AgileSolutions.UI.Api;
using AgileSolutions.UI.ViewModels.DepartmentViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AgileSolutions.UI.Controllers
{
    public class DepartmentController : Controller
    {
        public  async Task<IActionResult> List()
        {
            var url = "http://localhost:5094/departments/";
            var response = await  Api<DepartmentGetViewModel>.GetAsync(url);
            
            return View(response);
            
        }
        
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(DepartmentAddViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var url = "http://localhost:5094/department/add/";
            var response=await Api<DepartmentGetViewModel>.PostAsync(url, vm);
            if (response.IsSuccessStatusCode)
            {
                TempData["AddedMessage"] = "Added";
                return RedirectToAction("List");
            }
            return NotFound();
        }

        public async Task<IActionResult> Update(int id)
        {
            var url = $"http://localhost:5094/department/{id}/";
            var response = await Api<DepartmentUpdateViewModel>.GetAsync(url);
            return View(response.FirstOrDefault());
            
        }
        [HttpPost]
        public async Task<IActionResult> Update(DepartmentUpdateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var url = "http://localhost:5094/department/update/";
            var response = await Api<DepartmentGetViewModel>.PutAsync(url, vm);
            if (response.IsSuccessStatusCode)
            {
                TempData["UpdatedMessage"] = "Updated";
                return RedirectToAction("List");
            }
            return NotFound();
        }
        public async Task<IActionResult> Delete(int id)
        {
            var url = $"http://localhost:5094/department/delete/{id}";
            var response = await Api<DepartmentGetViewModel>.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                TempData["DeletedMessage"] = "Deleted";
                return RedirectToAction("List");
            }
            return NotFound();
        }
    }
}
