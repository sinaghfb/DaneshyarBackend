using Domain.Contracts.TermManagment;
using Domain.DTOs.TermManagment.Request;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[Action]")]
    [ApiController]
    public class TermCourseController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ITermManagment _termManagment;
        public TermCourseController(IConfiguration config, ITermManagment termManagment)
        {
            _configuration = config;
            _termManagment = termManagment;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllTermCourses()
        {
            var res = await _termManagment.GetAllTermCourses();
            if (res.Status == ResponseStateEnum.Success)
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
        public async Task<IActionResult> AddTermCourse(AddTermCourseRequest request)
        {
            var res = await _termManagment.AddTermCourse(request);
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
        public async Task<IActionResult> GetTermCourse(GeneralTermRequestModel request)
        {
            var res = await _termManagment.GetTermCourseDetail(request.TermId);
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
        public async Task<IActionResult> DeleteTermCourse(GeneralTermRequestModel request)
        {
            var res = await _termManagment.DeleteTermCourse(request.TermId);
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
        public async Task<IActionResult> RecoverTermCourse(RecoverTermCourseRequest request)
        {
            var res = await _termManagment.RecoverTermCourse(request);
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
        public async Task<IActionResult> UpdateTermCourse(UpdateTermCourseRequest request)
        {
            var res = await _termManagment.UpdateTermCourse(request);
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
