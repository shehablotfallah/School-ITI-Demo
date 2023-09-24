namespace Demo02.Services;

public interface IStudentsService
{
    IEnumerable<Student> GetAllStudents();

    Student? GetStudentById(int id);
    Student? GetStudentByEmail(string email);

    void Create(StudentFormViewModel model);

    void ToggleStatus(Student student);

    StudentFormViewModel GetUpdate(Student student);

    void Update(Student student,StudentFormViewModel model);
    
}
