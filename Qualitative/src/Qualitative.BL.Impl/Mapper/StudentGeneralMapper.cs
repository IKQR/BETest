using Qualitative.BL.Abstract.IMapper;
using Qualitative.DAL.Entities;
using Qualitative.Models.Student;

namespace Qualitative.BL.Impl.Mapper
{
    public class StudentGeneralMapper : IGeneralMapper<Student, StudentModel>
    {
        public StudentModel Map(Student entity)
        {
            return new StudentModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
            };
        }

        public Student MapBack(StudentModel model)
        {
            return new Student
            {
                Name = model.Name,
                Surname = model.Surname,
            };
        }

        public Student MapUpdate(StudentModel model, Student entity)
        {
            entity.Name = model.Name;
            entity.Surname = model.Surname;

            return entity;
        }
    }
}
