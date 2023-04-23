using Application.Dependencies.Base;
using Domain.Entites.CourseManagment;

namespace Application.Dependencies.CourseManagmanet
{
    public interface IPreRequiredRepository : IBaseRepository<string, PreRequired>
    {
        public Task<bool> DeletePreRequired(string Id);

    }
}
