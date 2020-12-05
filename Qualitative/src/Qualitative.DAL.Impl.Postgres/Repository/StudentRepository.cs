using System;
using Qualitative.DAL.Abstract.IRepository;
using Qualitative.DAL.Entities;
using Qualitative.DAL.Impl.Postgres.Repository.Base;

namespace Qualitative.DAL.Impl.Postgres.Repository
{
    public class StudentRepository : BaseRepository<Int64, Student>, IStudentRepository
    {
        public StudentRepository(QualitativeDbContext context) 
            : base(context)
        {

        }
    }
}
