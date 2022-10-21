using AgileSolutions.UI.Api;
using AgileSolutions.UI.ViewModels.DepartmentViewModels;
using AgileSolutions.UI.ViewModels.EmployeeViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AgileSolutions.UI.Controllers
{
    public class EmployeeController : Controller
    {
        public async Task<IActionResult> List()
        {
            var url = "http://localhost:5094/employees/";
            var response = await Api<EmployeeGetViewModel>.GetAsync(url);

            return View(response);

        }

        public async Task<IActionResult> Add()
        {
            var url = "http://localhost:5094/departments/";
            var response = await Api<DepartmentGetViewModel>.GetAsync(url);
            ViewBag.Departments = response;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(EmployeeAddViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                var urldepartment = "http://localhost:5094/departments/";
                var responsedepartment = await Api<DepartmentGetViewModel>.GetAsync(urldepartment);
                ViewBag.Departments = responsedepartment;
                return View(vm);
            }
            var url = "http://localhost:5094/employee/add/";
            var response = await Api<EmployeeGetViewModel>.PostAsync(url, vm);
            if (response.IsSuccessStatusCode)
            {
                TempData["AddedMessage"] = "Added";
                return RedirectToAction("List");
            }
            return NotFound();
        }

        public async Task<IActionResult> Update(int id)
        {
            var url = $"http://localhost:5094/employee/{id}/";
            var response = await Api<EmployeeUpdateViewModel>.GetAsync(url);
            var urldepartments = "http://localhost:5094/departments/";
            var responsedepartments = await Api<DepartmentGetViewModel>.GetAsync(urldepartments);
            ViewBag.Departments = responsedepartments;
            return View(response.FirstOrDefault());

        }
        [HttpPost]
        public async Task<IActionResult> Update(EmployeeUpdateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var url = "http://localhost:5094/employee/update/";
            var response = await Api<EmployeeGetViewModel>.PutAsync(url, vm);
            if (response.IsSuccessStatusCode)
            {
                TempData["UpdatedMessage"] = "Updated";
                return RedirectToAction("List");
            }
            return NotFound();
        }
        public async Task<IActionResult> Delete(int id)
        {
            var url = $"http://localhost:5094/employee/delete/{id}";
            var response = await Api<EmployeeGetViewModel>.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                TempData["DeletedMessage"] = "Deleted";
                return RedirectToAction("List");
            }
            return NotFound();
        }
    }
}
