using School2.API.Domain;
namespace School2.API.Repository
{
    public interface ICourseRepository
    {
        void AddCourse(Course course);
    
        List<Course> GetAllCourses();
        
        Course GetCourseById(int id);
        
        void DeleteCourse(int id);
    }
}
