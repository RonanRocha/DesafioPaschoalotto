using ClosedXML.Excel;
using DesafioPaschoalotto.Application.Dto;
using DesafioPaschoalotto.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DesafioPaschoalotto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRandomUserGeneratorApiService _randomUserGeneratorApiService;
        private readonly IUserService _userService;

        public UsersController(IRandomUserGeneratorApiService randomUserGeneratorApiService, IUserService userService)
        {
            _randomUserGeneratorApiService = randomUserGeneratorApiService;
            _userService = userService;
        }

        [HttpPost]
        [Route("Import")]
        public async Task<IActionResult> GenerateRandomUser()
        {
            await _randomUserGeneratorApiService.ImportRandomUsers();
            return Ok("Users are imported successfuly");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Detail(int id)
        {
            var user = await _userService.GetUserDetailById(id);
            if(user == null) return NotFound();
            return Ok(user);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto userDto)
        {
            await _userService.UpdateUser(userDto);
            return Ok("Users updated successfuly");
        }

        [HttpGet]
        [Route("ExportExcel")]
        public async Task<IActionResult> ExportExcel()
        {
            DataTable data = await _userService.GetUsersToReport();
            
            using XLWorkbook wb = new XLWorkbook();
            wb.AddWorksheet(data, "Users Report");

            using MemoryStream stream = new MemoryStream();
            wb.SaveAs(stream);
            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"ReportUsers");
        }


    }
}
