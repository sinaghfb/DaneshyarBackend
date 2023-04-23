using Application.Dependencies.Base;
using Domain.Entites.BaseInfo;
using Domain.Entites.CourseManagment;

namespace Application.Dependencies.CourseManagmanet
{
    public interface ICourseRepository : IBaseRepository<string, Course>
    {
        public void UpdateCourse(Course person);
        public Task<bool> DeleteCourse(string CourseId);
    }
}
