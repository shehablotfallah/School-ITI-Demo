namespace Demo02.Models;

public class BaseModel
{
	[Display(Name = "Is Delete?")]
	public bool IsDeleted { get; set; }
	public bool IsAvailable { get; set; }
	[Display(Name = "Created On")]
	public DateTime CreatedOn { get; set; }
	[Display(Name = "Last Updated On")]
	public DateTime? LastUpdatedOn { get; set; }
}
