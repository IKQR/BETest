using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Qualitative.BL.Abstract.IService;
using Qualitative.Models.Entities;
using Qualitative.Models.Result;
using Qualitative.Models.Student;

namespace Qualitative.Web.Controllers
{
    [Route("students")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(
            IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            StudentModel model = new StudentModel();

            return View(model);
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(StudentModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            long result = await _studentService.Create(model);

            return RedirectToAction(nameof(Item), new { id = result });
        }

        public async Task<IActionResult> Index()
        {
            List<StudentModel> models = await _studentService.GetAll();

            return View(models);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Item([FromRoute] Int64 id)
        {
            Result<StudentModel> result = await _studentService.GetById(id);

            if (result.Success)
            {
                return View(result.Data);
            }

            if (result.ErrorType == ErrorType.NotFound)
            {
                return View("NotFoundError");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> Update([FromRoute] Int64 id)
        {
            Result<StudentModel> result = await _studentService.GetById(id);

            if (result.Success)
            {
                return View(result.Data);
            }

            if (result.ErrorType == ErrorType.NotFound)
            {
                return View("NotFoundError");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("edit/{id}")]
        public async Task<IActionResult> Update([FromRoute] Int64 id,[FromForm] StudentModel model)
        {
            if (!ModelState.IsValid)
            {
                View(model);
            }

            Result result = await _studentService.Update(id, model);

            if (result.Success)
            {
                return RedirectToAction("Item", new { id = id });
            }

            if (result.ErrorType == ErrorType.NotFound)
            {
                return View("NotFoundError");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Int64 id)
        {
            Result result = await _studentService.Delete(id);

            if (result.Success)
            {
                return View();
            }

            if (result.ErrorType == ErrorType.NotFound)
            {
                return View("NotFoundError");
            }

            return RedirectToAction("Index");
        }
    }
}
