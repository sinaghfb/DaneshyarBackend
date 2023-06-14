using Domain.Contracts.TermManagment;
using Domain.DTOs.TermManagment.Request;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[Action]")]
    [ApiController]
    public class TermController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ITermManagment _termManagment;
        public TermController(IConfiguration config, ITermManagment termManagment)
        {
            _configuration = config;
            _termManagment = termManagment;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllTerms()
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
        public async Task<IActionResult> AddTerm(AddTermRequest request)
        {
            var res = await _termManagment.AddTerm(request);
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
        public async Task<IActionResult> GetTerm(GeneralTermRequestModel request)
        {
            var res = await _termManagment.GetTermDetail(request.TermId);
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
        public async Task<IActionResult> DeleteTerm(GeneralTermRequestModel request)
        {
            var res = await _termManagment.DeleteTerm(request.TermId);
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
        public async Task<IActionResult> UpdateTerm(UpdateTermRequest request)
        {
            var res = await _termManagment.UpdateTerm(request);
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
