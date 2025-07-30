using EmployeeAttendanceTracker.Bussiness.IServices;
using EmployeeAttendanceTracker.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAttendanceTracker.Presentation.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)

        {
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            return View(departments);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Department department)
        {
            try
            {
                await _departmentService.AddDepartmentAsync(department);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] Department department)
        {
            try
            {
                await _departmentService.UpdateDepartmentAsync(department);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _departmentService.DeleteDepartmentAsync(id);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> IsNameUnique(string name)
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            return Json(departments.All(d => d.Name != name));
        }
         
        [HttpGet]
        public async Task<IActionResult> IsCodeUnique(string code)
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            return Json(departments.All(d => d.Code != code));
        }
    }
}
