namespace Demo02.Controllers;
public class DepartmentsController : Controller
{
    private readonly IDepartmentsService _departmentsService;

    public DepartmentsController(IDepartmentsService departmentsService)
    {
        _departmentsService = departmentsService;
    }

    public IActionResult Index()
    {
        return View(_departmentsService.GetAllDepartments());
    }

    public IActionResult Create()
    {
        return View("Form");
    }

    [HttpPost]
    public IActionResult Create(DepartmentFormViewModel model)
    {
        if (!ModelState.IsValid)
            return View("Form", model);
       
        _departmentsService.Create(model);
        return RedirectToAction(nameof(Index));
    }
    public IActionResult Details(int id)
    {
        var departments = _departmentsService.GetDepartmentById(id);
        if (departments is null)
            return NotFound();

        return View(departments);
    }

    public IActionResult ToggleStatus(int id)
    {
        var department = _departmentsService.GetDepartmentById(id);
        if (department is null)
            return NotFound();

        _departmentsService.ToggleStatus(department);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var department = _departmentsService.GetDepartmentById(id);
        if (department is null)
            return NotFound();

        var viewModel = _departmentsService.GetUpdate(department);
        return View("Form", viewModel);
    }

    [HttpPost]
    public IActionResult Edit(DepartmentFormViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var department = _departmentsService.GetDepartmentById(model.Id);
        if (department is null)
            return NotFound();

        _departmentsService.Update(department, model);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult AllowDepartment(DepartmentFormViewModel model) 
    { 
        var department = _departmentsService.GetDepartmentByName(model.Name);
        var isAllowed = department is null || department.Id.Equals(model.Id);

        return Json(isAllowed);
    }
}
