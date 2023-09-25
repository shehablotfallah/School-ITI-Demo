using Demo02.Consts;

namespace Demo02.ViewModels;

public class StudentFormViewModel
{
	[Display(Name = "ID")]
	public int Id { get; set; }

	[MaxLength(20)]
	[Display(Name = "Full Name")]
	public string Name { get; set; } = null!;

	[Range(20, 30)]
	public int Age { get; set; }

	[DataType(DataType.EmailAddress)]
	[RegularExpression(@"[A-Za-z0-9_]+@[A-Za-z]+.[A-Za-z]{2,4}"),
		Remote("AllowEmail", null!, AdditionalFields = "Id", ErrorMessage = Errors.Duplicated)]
	public string Email { get; set; } = null!;

	[DataType(DataType.Password)]
	[StringLength(25, MinimumLength = 8)]
	public string Password { get; set; } = null!;

	[DataType(DataType.Password)]
	[Display(Name = "Confirm Password"), Compare("Password")]
	public string ConfirmPassword { get; set; } = null!;

	[Display(Name = "Department")]
	public int DepartmentId { get; set; }
	public IEnumerable<SelectListItem> Departments { get; set; } = Enumerable.Empty<SelectListItem>();

	[Display(Name = "Is Delete?")]
	public bool IsDeleted { get; set; }
}
