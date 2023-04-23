using Domain.Contracts.CourseManagment;
using Domain.DTOs.CourseManagment.Request;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[Action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ICourseManagment _courseManagment;
        public CourseController(IConfiguration config, ICourseManagment courseManagment)
        {
            _courseManagment = courseManagment;
            _configuration = config;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllCourses()
        {
           var res=await _courseManagment.GetAllCourses();
            if (res.Status== ResponseStateEnum.Success)
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(500, res);
            }
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> AddCourse(AddCourseRequest request)
        {
            var res = await _courseManagment.AddCourse(request);
            if (res.Status == ResponseStateEnum.Success)
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(500, res);
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetCourse(GeneralCourseRequest request)
        {
            var res = await _courseManagment.GetCourseDetail(request);
            if (res.Status == ResponseStateEnum.Success)
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(500, res);
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteCourse(GeneralCourseRequest request)
        {
            var res = await _courseManagment.DeleteCourse(request);
            if (res.Status == ResponseStateEnum.Success)
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(500, res);
            }
        }
        [HttpPatch]
        [Authorize]
        public async Task<IActionResult> UpdateCourse(UpdateCourseResquest request)
        {
            var res = await _courseManagment.UpdateCourse(request);
            if (res.Status == ResponseStateEnum.Success)
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(500, res);
            }
        }
    }
}
