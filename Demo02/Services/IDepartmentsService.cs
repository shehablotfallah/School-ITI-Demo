namespace Demo02.Services;

public interface IDepartmentsService
{
    IEnumerable<Department> GetAllDepartments();

    Department? GetDepartmentById(int id);
    Department? GetDepartmentByName(string name);

    void Create(DepartmentFormViewModel model);

    void ToggleStatus(Department department);

    DepartmentFormViewModel GetUpdate(Department department);

    void Update(Department department, DepartmentFormViewModel model);

    IEnumerable<SelectListItem> GetSelectList();

    IEnumerable<SelectListItem> GetSelectListWithDeleted();
}
