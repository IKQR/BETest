using System;
using Qualitative.DAL.Abstract.IRepository.Base;
using Qualitative.DAL.Entities;

namespace Qualitative.DAL.Abstract.IRepository
{
    public interface IStudentRepository : IBaseRepository<Int64, Student>
    {
        
    }
}
