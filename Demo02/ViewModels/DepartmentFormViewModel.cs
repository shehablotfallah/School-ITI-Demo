using Demo02.Consts;

namespace Demo02.ViewModels;

public class DepartmentFormViewModel
{
    [Display(Name = "ID")]
    public int Id { get; set; }

    [MaxLength(20), Display(Name = "Department"),
        Remote("AllowDepartment", null!, AdditionalFields = "Id", ErrorMessage = Errors.Duplicated)]
    public string Name { get; set; } = null!;

    [Display(Name = "Is Delete?")]
    public bool IsDeleted { get; set; }
}
