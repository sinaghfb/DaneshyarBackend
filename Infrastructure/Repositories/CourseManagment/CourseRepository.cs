using Application.Dependencies.CourseManagmanet;
using Domain.Entites.CourseManagment;
using Domain.Enums;
using Infrastructure.Contexts.CourseManagment;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CourseManagment
{
    internal class CourseRepository: BaseRepository<string, Course>, ICourseRepository
    {
        private readonly CourseContext _courseManagmentContext;
        public CourseRepository(CourseContext courseManagmentContext) : base(courseManagmentContext)
        {
            _courseManagmentContext = courseManagmentContext;
        }

        public async Task<bool> DeleteCourse(string CourseId)
        {
            var foundedCourses = await _courseManagmentContext.Courses.FirstOrDefaultAsync(x => x.Id == CourseId);
            if (foundedCourses != null)
            {
                foundedCourses.State = ObjectStateEnum.Deleted;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UpdateCourse(Course person)
        {
            this._courseManagmentContext.Courses.Update(person);
        }
    }
}
