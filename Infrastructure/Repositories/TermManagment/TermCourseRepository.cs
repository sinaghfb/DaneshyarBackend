using Application.Dependencies.TermManagment;
using Domain.Entites.TermManagment;
using Domain.Enums;
using Infrastructure.Contexts.TermManagment;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.TermManagment
{
    public class TermCourseRepository:BaseRepository<string,TermCourse>, ITermCourseRepository
    {
        private readonly TermCourseContext _termCourseContext;
        public TermCourseRepository(TermCourseContext termCourseContext) : base(termCourseContext)
        {
            _termCourseContext = termCourseContext;
        }
        public async Task<bool> DeleteTermCourse(string Id)
        {
            var foundedRole = await _termCourseContext.TermCourses.FirstOrDefaultAsync(x => x.Id == Id);
            if (foundedRole != null)
            {
                foundedRole.State = ObjectStateEnum.Deleted;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
