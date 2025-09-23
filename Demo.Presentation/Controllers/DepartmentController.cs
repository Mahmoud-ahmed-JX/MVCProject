using BuisnessLogic.DTOS;
using BuisnessLogic.DTOS.DepartmentDtos;
using BuisnessLogic.Services.Classes;
using BuisnessLogic.Services.Interfaces;
using Demo.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class DepartmentController(IDepartmentService _departmentService,IWebHostEnvironment _env,ILogger<DepartmentController> _logger) : Controller
    {
        //    private readonly DepartmentService _departmentService = departmentService;

        #region Index
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        }
        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateDepartmentDto departmentDto)
        {
            if (ModelState.IsValid)
            {
                try {
                    var res = _departmentService.AddDepartment(departmentDto);

                    if (res > 0)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError("", "Department Can not be created");

                    }
                }
                catch (Exception ex) {
                    if (_env.IsDevelopment())
                    {
                        _logger.LogError($"Department Can not be create {ex.Message}");

                 
                    }
                    else
                    {
                        _logger.LogError($"Department Can not be create {ex}");
                        return View("Error");
                    }
                }
                }
            
                return View(departmentDto);
            
        }
        #endregion

        #region Details
        public IActionResult Details(int? Id) {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            var department = _departmentService.GetDepartmentById(Id.Value);
            if(department is null)
                return NotFound();
            return View(department);
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if(!Id.HasValue)
            {
                return BadRequest();
            }

            var department = _departmentService.GetDepartmentById(Id.Value);

            if(department is null)
                return NotFound();
            DepartmentEditViewModel dep = new DepartmentEditViewModel()
            {
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreatedOn = department.CreatedOn.HasValue ? department.CreatedOn.Value : default
            };
            return View(dep);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int? Id,DepartmentEditViewModel department) {
            if (ModelState.IsValid)
            {
               
                try
                {
                    if(!Id.HasValue) return BadRequest();
                    var updatedDepartmentDto = new UpdatedDepartmentDto()
                    {
                        Id = Id.Value,
                        Code = department.Code,
                        Name = department.Name,
                        Description = department.Description,
                        DateOfCreation = department.CreatedOn
                    };
                    int res = _departmentService.UpdateDepartment(updatedDepartmentDto);
                    if (res > 0)
                        return RedirectToAction(nameof(Index));
                    else
                        ModelState.AddModelError("", "Department can not be updated");

                }
                catch (Exception ex)
                {
                    if (_env.IsDevelopment())
                    {
                        _logger.LogError($"Department Can not be updated because {ex.Message}");
                    }
                    else
                    {
                        _logger.LogError($"Department Can not be updated because {ex}");
                        return View("Error");
                    }
                }
            }
            return View(department);
        }
        #endregion

        #region Delete

        [HttpPost]
        public IActionResult Delete(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();
            try
            {
                bool res = _departmentService.DeleteDepartment(Id.Value);
                if (res)
                    return RedirectToAction(nameof(Index));
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    _logger.LogError($"Department Can not be deleted because {ex.Message}");
                }
                else
                {
                    _logger.LogError($"Department Can not be deleted because {ex}");
                    return View("Error");
                }
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
