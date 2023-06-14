using Application.Dependencies.Base;
using Domain.Entites.TermManagment;


namespace Application.Dependencies.TermManagment
{
    public interface ITermCourseRepository : IBaseRepository<string, TermCourse>
    {
        Task<bool> DeleteTermCourse(string Id);

    }
}
