namespace Demo02.Controllers;
public class StudentsController : Controller
{
    private readonly IStudentsService _studentsService;
    private readonly IDepartmentsService _departmentsService;

    public StudentsController(IDepartmentsService departmentsService, 
        IStudentsService studentsService)
    {
        _departmentsService = departmentsService;
        _studentsService = studentsService;
    }

    public IActionResult Index()
    {
        return View(_studentsService.GetAllStudents());
    }

    public IActionResult Create()
    {
        StudentFormViewModel viewModel = new()
        {
            Departments = _departmentsService.GetSelectList()
        };

        return View("Form", viewModel);
    }

    [HttpPost]
    public IActionResult Create(StudentFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Departments = _departmentsService.GetSelectList();
            return View("Form", model);
        }
        _studentsService.Create(model);
        return RedirectToAction(nameof(Index));
    }
    public IActionResult Details(int id)
    {
        var student = _studentsService.GetStudentById(id);
        if (student is null)
            return NotFound();

        return View(student);
    }

    public IActionResult ToggleStatus(int id)
    {
        var student = _studentsService.GetStudentById(id);
        if (student is null)
            return NotFound();

        _studentsService.ToggleStatus(student);
        return RedirectToAction(nameof(Index));
    }
    public IActionResult Edit(int id)
    {
        var student = _studentsService.GetStudentById(id);

        if (student is null)
            return NotFound();

        StudentFormViewModel viewModel = _studentsService.GetUpdate(student);
        return View("Form", viewModel);
        
    }

    [HttpPost]
    public IActionResult Edit(StudentFormViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var student = _studentsService.GetStudentById(model.Id);
        if (student is null)
            return NotFound();

        _studentsService.Update(student, model);
        return RedirectToAction(nameof(Index));

    }

    public IActionResult AllowEmail(StudentFormViewModel model)
    {
        var student = _studentsService.GetStudentByEmail(model.Email);
        var isAllowed = student is null || student.Id.Equals(model.Id);

        return Json(isAllowed);
    }
}

