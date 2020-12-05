using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Qualitative.Models.Result;
using Qualitative.Models.Student;

namespace Qualitative.BL.Abstract.IService
{
    public interface IStudentService
    {
        //CREATE
        public Task<Int64> Create(StudentModel model);

        //READ
        public Task<List<StudentModel>> GetAll();
        public Task<Result<StudentModel>> GetById(Int64 id);

        //UPDATE
        public Task<Result> Update(Int64 id, StudentModel model);

        //DELETE
        public Task<Result> Delete(Int64 id);
    }
}
