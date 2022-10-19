using AgileSolutions.Business.Abstract.Services;
using AgileSolutions.Business.Concrete.Dtos.DepartmentDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgileSolutions.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> logger;
        private readonly IDepartmentService departmentService;

        public DepartmentController(ILogger<DepartmentController> logger, IDepartmentService departmentService)
        {
            this.logger = logger;
            this.departmentService = departmentService;
        }


        [HttpGet("/departments")]
        public async Task<IActionResult> Get()
        {
            logger.LogInformation("Start Get method in DepartmentController.");
            var result = await departmentService.GetAllForStateAsync(true, "Employees");

            if (result.Status)
            {
                logger.LogInformation(result.Message + " in DepartmentController Get method");
                return Ok(result.List);
            }
            else
            {
                logger.LogError(result.Message + " in DepartmentController Get method");
                return NotFound(result.Message);
            }
        }
        [HttpPost("/department/add")]
        public async Task<IActionResult> Add(DepartmentAddDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            logger.LogInformation("Start Add method in DepartmentController.");
            var result = await departmentService.AddAsync(dto);
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in DepartmentController Add method");
                return Ok();
            }
            else
            {
                logger.LogError(result.Message + " in DepartmentController Add method");
                return NotFound(result.Message);
            }
        }
        [HttpPut("/department/update")]
        public async Task<IActionResult> Update(DepartmentUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            logger.LogInformation("Start Update method in DepartmentController.");
            var result = await departmentService.UpdateAsync(dto);
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in DepartmentController Update method");
                return Ok();
            }
            else
            {
                logger.LogError(result.Message + " in DepartmentController Update method");
                return NotFound(result.Message);
            }
        }
        [HttpDelete("/department/delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            logger.LogInformation("Start Delete method in DepartmentController.");
            var result = await departmentService.DeleteAsync(id);
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in DepartmentController Delete method");
                return Ok();
            }
            else
            {
                logger.LogError(result.Message + " in DepartmentController Delete method");
                return NotFound(result.Message);
            }
        }

        [HttpGet("/department/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            logger.LogInformation("Start GetById method in DepartmentController.");
            var result = await departmentService.GetByIdAsync(id, "Employees");
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in DepartmentController GetById method");
                return Ok(result.List);
            }
            else
            {
                logger.LogError(result.Message + " in DepartmentController GetById method");
                return NotFound(result.Message);
            }
        }
    }
}
