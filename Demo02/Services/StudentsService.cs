namespace Demo02.Services;

public class StudentsService : IStudentsService
{
	private readonly ApplicationDbContext _context;
	private readonly IDepartmentsService _departmentsService;


	public StudentsService(ApplicationDbContext context, IDepartmentsService departmentsService)
	{
		_context = context;
		_departmentsService = departmentsService;
	}

	public IEnumerable<Student> GetAllStudents()
	{
		return _context.Students.Include(d => d.Department).AsNoTracking().ToList();
	}

	public Student? GetStudentById(int id)
	{
		return _context.Students.Include(d => d.Department).SingleOrDefault(s => s.Id == id);
	}

	public Student? GetStudentByEmail(string email)
	{
		return _context.Students.SingleOrDefault(s => s.Email == email);
	}

	public void Create(StudentFormViewModel model)
	{

		Student student = new()
		{
			Name = model.Name,
			Age = model.Age,
			Email = model.Email,
			Password = model.Password,
			ConfirmPassword = model.ConfirmPassword,
			DepartmentId = model.DepartmentId,
			IsDeleted = model.IsDeleted,
			CreatedOn = DateTime.Now
		};
		_context.Add(student);
		_context.SaveChanges();
	}

	public void ToggleStatus(Student student)
	{
		student.IsDeleted = !student.IsDeleted;
		student.LastUpdatedOn = DateTime.Now;

		_context.SaveChanges();
	}

	public StudentFormViewModel GetUpdate(Student student)
	{
		if (student.Department.IsDeleted is false)
		{
			StudentFormViewModel viewModel = new()
			{
				Id = student.Id,
				Name = student.Name,
				Age = student.Age,
				Email = student.Email,
				Password = student.Password,
				ConfirmPassword = student.Password,
				DepartmentId = student.DepartmentId,
				Departments = _departmentsService.GetSelectList(),
				IsDeleted = student.IsDeleted
			};
			return viewModel;
		}
		else
		{
			StudentFormViewModel viewModel = new()
			{
				Id = student.Id,
				Name = student.Name,
				Age = student.Age,
				Email = student.Email,
				Password = student.Password,
				ConfirmPassword = student.Password,
				DepartmentId = student.DepartmentId,
				Departments = _departmentsService.GetSelectListWithDeleted(),
				IsDeleted = student.IsDeleted
			};
			return viewModel;
		}
	}

	public void Update(Student student, StudentFormViewModel model)
	{
		student.Name = model.Name;
		student.Age = model.Age;
		student.Email = model.Email;
		student.Password = model.Password;
		student.ConfirmPassword = model.ConfirmPassword;
		student.DepartmentId = model.DepartmentId;
		student.IsDeleted = model.IsDeleted;
		student.LastUpdatedOn = DateTime.Now;

		_context.SaveChanges();
	}
}
