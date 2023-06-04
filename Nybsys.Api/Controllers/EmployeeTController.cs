using Microsoft.AspNetCore.Mvc;
using Nybsys.Api.Utils;
using Nybsys.DataAccess.Contracts;
using Nybsys.EntityModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nybsys.Api.Controllers
{
    [ApiController]
    public class EmployeeTController : ControllerBase
    {
        private IEmployeeTRepository _EmployeeTRepository;
        public IDesignationRepository _DesignationRepository;
        public EmployeeTController(IEmployeeTRepository employeeTRepository, IDesignationRepository designationRepository)
        {
            _EmployeeTRepository = employeeTRepository;
            _DesignationRepository = designationRepository; 
        }
        [HttpPost]
        [Route(LabelHelper.NybsysApiHelper.SaveEmployeeT)]
        public JsonResult AddEmployee([FromBody] EmployeeT employee)
        {
            bool result = false;
            string Message = "";
            try
            {
                result = _EmployeeTRepository.Create(employee);
                return new JsonResult(new { result = result, Message = "Save successfully" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { result = false, ex.Message });
            }

        }

        [HttpPost]
        [Route(LabelHelper.NybsysApiHelper.UpdateEmployeeT)]
        public JsonResult UpdateEmployee([FromBody] EmployeeT employee)
        {
            bool result = false;
            string Message = "";
            try
            {
                result = _EmployeeTRepository.Update(employee);
                return new JsonResult(new { result = result, model = employee, Message = "Update successfully" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { result = false, ex.Message });
            }
        }
        [HttpGet]
        [Route(LabelHelper.NybsysApiHelper.GetByEmployeeIdT)]
        public JsonResult GetByEmployeeId(int id)
        {
            EmployeeT Model = new EmployeeT();
            bool result = false;
            string Message = "";
            try
            {
                Model = _EmployeeTRepository.GetById(id);
                return new JsonResult(new { result = true, model = Model });

            }
            catch (Exception ex)
            {
                return new JsonResult(new { result = false, ex.Message });
            }

        }
        [HttpGet]
        [Route(LabelHelper.NybsysApiHelper.GetAllEmployeT)]
        public JsonResult GetAllEmployee()
        {
            List<EmployeeT> employees = new List<EmployeeT>();
            bool result = false;
            string Message = "";
            try
            {
                employees = _EmployeeTRepository.GetAll().OrderByDescending(x => x.Id).ToList();
                return new JsonResult(new { result = true, list = employees });

            }
            catch (Exception ex)
            {
                return new JsonResult(new { result = false, ex.Message });
            }

        }
        [HttpDelete]
        [Route(LabelHelper.NybsysApiHelper.DeleteEmployeeT)]
        public JsonResult DeleteEmployee(int id)
        {
            EmployeeT employee = new EmployeeT();
            bool result = false;
            string Message = "";
            try
            {
                employee.Id = id;
                result = _EmployeeTRepository.Delete(employee);
                return new JsonResult(new { result = result, Message = "Delete successfully" });

            }
            catch (Exception ex)
            {
                return new JsonResult(new { result = false, ex.Message });
            }

        }
        [HttpGet]
        [Route(LabelHelper.NybsysApiHelper.GetAllDesignationT)]
        public JsonResult GetAllEDesignation()
        {
            List<EDesignation> employees = new List<EDesignation>();
            bool result = false;
            string Message = "";
            try
            {
                employees = _DesignationRepository.GetAll().OrderByDescending(x => x.Id).ToList();
                return new JsonResult(new { result = true, list = employees });

            }
            catch (Exception ex)
            {
                return new JsonResult(new { result = false, ex.Message });
            }

        }
    }
}
