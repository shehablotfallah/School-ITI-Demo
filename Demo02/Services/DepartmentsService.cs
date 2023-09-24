using Microsoft.EntityFrameworkCore;

namespace Demo02.Services;

public class DepartmentsService : IDepartmentsService
{
    private readonly ApplicationDbContext _context;

    public DepartmentsService(ApplicationDbContext context)
    {
        _context = context;
    }


    public IEnumerable<Department> GetAllDepartments() => _context.Departments.AsNoTracking().ToList();

    public Department? GetDepartmentById(int id) => _context.Departments.SingleOrDefault(d => d.Id == id);
    public Department? GetDepartmentByName(string name) => _context.Departments.SingleOrDefault(d => d.Name == name);

    public void Create(DepartmentFormViewModel model)
    {
        Department department = new()
        {
            Name = model.Name,
            CreatedOn = DateTime.Now,
        };
        _context.Add(department);
        _context.SaveChanges();
    }

    public void ToggleStatus(Department department)
    {
        department.IsDeleted = !department.IsDeleted;
        department.LastUpdatedOn = DateTime.Now;

        _context.SaveChanges();
    }

    public DepartmentFormViewModel GetUpdate(Department department)
    {
        DepartmentFormViewModel viewModel = new()
        {
            Id = department.Id,
            Name = department.Name,
            IsDeleted = department.IsDeleted,
        };
        return viewModel;
    }

    public void Update(Department department, DepartmentFormViewModel model)
    {
        department.Name = model.Name;
        department.IsDeleted = model.IsDeleted;
        department.LastUpdatedOn = DateTime.Now;
        _context.SaveChanges();
    }

    public IEnumerable<SelectListItem> GetSelectList()
    {
        return _context.Departments
            .Where(d => !d.IsDeleted)
            .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
            .OrderBy(d => d.Text)
            .AsNoTracking()
            .ToList();
    }

    public IEnumerable<SelectListItem> GetSelectListWithDeleted()
    {
        return _context.Departments
            .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
            .OrderBy(d => d.Text)
            .AsNoTracking()
            .ToList();
    }
}
