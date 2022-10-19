using AgileSolutions.Business.Abstract.Services;
using AgileSolutions.Business.Concrete.Dtos.DepartmentDtos;
using AgileSolutions.Business.Concrete.Dtos.EmployeeDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgileSolutions.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> logger;
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            this.employeeService = employeeService;
            this.logger = logger;
        }
        [HttpGet("/employees")]
        public async Task<IActionResult> Get()
        {
            logger.LogInformation("Start Get method in EmployeeController.");
            var result = await employeeService.GetAllForStateAsync(true, "Department");

            if (result.Status)
            {
                logger.LogInformation(result.Message + " in EmployeeController Get method");
                return Ok(result.List);
            }
            else
            {
                logger.LogError(result.Message + " in EmployeeController Get method");
                return NotFound(result.Message);
            }
        }
        [HttpPost("/employee/add")]
        public async Task<IActionResult> Add(EmployeeAddDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            logger.LogInformation("Start Add method in EmployeeController.");
            var result = await employeeService.AddAsync(dto);
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in EmployeeController Add method");
                return Ok();
            }
            else
            {
                logger.LogError(result.Message + " in EmployeeController Add method");
                return NotFound(result.Message);
            }
        }
        [HttpPut("/employee/update")]
        public async Task<IActionResult> Update(EmployeeUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            logger.LogInformation("Start Update method in EmployeeController.");
            var result = await employeeService.UpdateAsync(dto);
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in EmployeeController Update method");
                return Ok();
            }
            else
            {
                logger.LogError(result.Message + " in EmployeeController Update method");
                return NotFound(result.Message);
            }
        }
        [HttpDelete("/employee/delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            logger.LogInformation("Start Delete method in EmployeeController.");
            var result = await employeeService.DeleteAsync(id);
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in EmployeeController Delete method");
                return Ok();
            }
            else
            {
                logger.LogError(result.Message + " in EmployeeController Delete method");
                return NotFound(result.Message);
            }
        }

        [HttpGet("/employee/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            logger.LogInformation("Start GetById method in EmployeeController.");
            var result = await employeeService.GetByIdAsync(id, "Department");
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in EmployeeController GetById method");
                return Ok(result.List);
            }
            else
            {
                logger.LogError(result.Message + " in EmployeeController GetById method");
                return NotFound(result.Message);
            }
        }
    }
}
