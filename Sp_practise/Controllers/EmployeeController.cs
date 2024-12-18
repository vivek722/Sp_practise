using AutoMapper;
using Domain.Model;
using Domain.Service.Service;
using Entity.FirebaseManagement;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Sp_practise.RequestModel;
using Sp_practise.ResponseModel;

namespace Sp_practise.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly IFirebaseUploadImageService _firebaseUploadImageService;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper, IFirebaseUploadImageService firebaseUploadImageService)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _firebaseUploadImageService = firebaseUploadImageService;
        }

        [HttpGet("GetEmployee")]
        public async Task<IActionResult> GetEmployee(string? searchstring)
        {
            try
            {
                if (searchstring != null)
                {
                    var getdata = await _employeeService.SearchString(searchstring);
                   // var MappingData = _mapper.Map<EmployeeViewModel>(getdata);
                    return Ok(new DataResponseList() { Data = getdata, status = StatusCodes.Status200OK, Message = "Your search data" });
                }
                else
                {
                    var getdata = await _employeeService.GetAll();
                    return Ok(new DataResponseList() { Data = getdata, status = StatusCodes.Status200OK, Message = "Your all data" });
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse() { Status = "Error", Message = ex.Message });
            }

        }
            [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromForm] EmployeeViewModel employeeEntity)
        {
            try
            {
                if (employeeEntity.image != null)
                {
                    try
                    {
                        var file = Guid.NewGuid().ToString() + "-" + employeeEntity.image.FileName;
                        var path = Path.Combine(Path.GetTempPath(), file);
                        employeeEntity.imagepath = path;
                        var folder = "Demo-Images";
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            employeeEntity.image.CopyTo(stream);
                        }
                        var url = await _firebaseUploadImageService.FireBaseUploadImageAsync(file, path, folder);
                        employeeEntity.imagepath = url;
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse() { Status = "Error", Message = ex.Message });
                    }
                }
                var employeermaping = _mapper.Map<EmployeeEntity>(employeeEntity);
                var Addemployee = await _employeeService.addEmployee(employeermaping);
                return Ok(new DataResponseList() { Data = Addemployee, status = StatusCodes.Status200OK, Message = "Employee add successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse() { Status = "Error", Message = ex.Message });
            }
        }
        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> deleteEmployee([FromForm] int id)
        {
            try
            {
                var deleteEmployee = await _employeeService.DeleteEmployee(id);
                return Ok(new DataResponseList() { Data = deleteEmployee, status = StatusCodes.Status200OK, Message = "Employee delete successfully" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse() { Status = "Error", Message = e.Message });
            }
        }
        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromForm] EmployeeViewModel employeeViewModel)
        {
            try
            {
                if (employeeViewModel.image != null)
                {
                    try
                    {
                        var file = Guid.NewGuid().ToString() + "-" + employeeViewModel.image.FileName;
                        var path = Path.Combine(Path.GetTempPath(), file);
                        employeeViewModel.imagepath = path;

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            employeeViewModel.image.CopyTo(stream);
                        }
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse() { Status = "Error", Message = ex.Message });
                    }
                }
                var mapingEmployee = _mapper.Map<EmployeeEntity>(employeeViewModel);
                var updatedEmployee = _employeeService.UpdateEmployee(mapingEmployee);
                return Ok(new DataResponseList() { Data = updatedEmployee, status = StatusCodes.Status200OK, Message = "Employee update successfully" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse() { Status = "error", Message = e.Message });
            }
        }
        [HttpGet("GetByIdEmployee")]
        public async Task<IActionResult> GetByIdEmployee(int id)
        {
            try
            {
                var result = await _employeeService.GetById(id);
                return Ok(new DataResponseList () {  Data= result,status=StatusCodes.Status200OK,Message ="Your employee data"});
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse() { Status = "Error", Message = ex.Message });
            }

        }

    }
}