using School2.API.Domain;

namespace School2.API.Repository
{
    public interface IEnrollmentRepository
    {
        void AddEnrollment(Enrollment enrollment);
        List<Enrollment>GetAllEnrollments();

        Enrollment GetEnrollmentById(int id);
        void DeletableEnrollment(int id);

    }
}
