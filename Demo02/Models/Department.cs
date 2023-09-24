namespace Demo02.Models;

public class Department : BaseModel
{
    [Display(Name = "ID")]
    public int Id { get; set; }
    [MaxLength(20), Display(Name = "Department")]
    public string Name { get; set; } = null!;
    public ICollection<Student> Students { get; set; } = new HashSet<Student>();
}
