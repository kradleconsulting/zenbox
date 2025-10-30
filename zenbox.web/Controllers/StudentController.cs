using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using zenbox.core.Interface;
using zenbox.model;
using zenbox.model.Entity;

namespace zenbox.web.Controllers
{
    [Authorize]    
    public class StudentController(IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager, IStudentService studentService) : BaseController(httpContextAccessor, webHostEnvironment, userManager)
    {

        [Route("/students")]
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
                return Unauthorized();

            var model = new StudentListViewmodel()
            {
                Items = studentService.GetList().Result.Select(e => new StudentViewmodel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    IsActive = e.IsActive,
                    UserId = e.UserId
                })
            };

            return View(new LayoutModel<StudentListViewmodel>(model, "Students", sidebar));
        }


        [HttpPost]
        public async Task<IActionResult> Add(StudentViewmodel student)
        {
            var user = await userManager.GetUserAsync(User);

            var model = new StudentModel
            {
                Name = student.Name,                
                IsActive = student.IsActive,
                UserId = student.UserId
            };

            model = await studentService.Add(model);

            return Ok(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await studentService.Delete(id);

            return Ok();
        }
    }
}
