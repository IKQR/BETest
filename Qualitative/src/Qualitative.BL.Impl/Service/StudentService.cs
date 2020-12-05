using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Qualitative.BL.Abstract.IMapper;
using Qualitative.BL.Abstract.IService;
using Qualitative.DAL.Abstract.IRepository;
using Qualitative.DAL.Entities;
using Qualitative.Models.Entities;
using Qualitative.Models.Result;
using Qualitative.Models.Student;

namespace Qualitative.BL.Impl.Service
{
    public class StudentService : IStudentService
    {
        private readonly ILogger<StudentService> _logger;
        private readonly IStudentRepository _studentRepository;
        private readonly IGeneralMapper<Student, StudentModel> _generalMapper;

        public StudentService(
            ILogger<StudentService> logger,
            IStudentRepository studentRepository,
            IGeneralMapper<Student, StudentModel> generalMapper)
        {
            _logger = logger;
            _studentRepository = studentRepository;
            _generalMapper = generalMapper;
        }

        public async Task<long> Create(StudentModel model)
        {
            try
            {
                Student entity = await _studentRepository.Create(_generalMapper.MapBack(model));

                return entity.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception while creating student");
                throw;
            }
        }

        public async Task<List<StudentModel>> GetAll()
        {
            try
            {
                List<Student> entities = await _studentRepository.GetAll();

                return entities.Select(_generalMapper.Map).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception while getting all students");
                throw;
            }
        }

        public async Task<Result<StudentModel>> GetById(Int64 id)
        {
            try
            {
                Student entity = await _studentRepository.GetById(id);

                if (entity == null)
                {
                    return new Result<StudentModel>
                    {
                        Success = false,
                        ErrorType = ErrorType.NotFound,
                    };
                }

                return new Result<StudentModel>
                {
                    Success = true,
                    Data = _generalMapper.Map(entity),
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception while getting student by id = {id}");
                throw;
            }
        }

        public async Task<Result> Update(long id, StudentModel model)
        {
            try
            {
                Student entity = await _studentRepository.GetById(id);

                if (entity == null)
                {
                    return new Result<StudentModel>
                    {
                        Success = false,
                        ErrorType = ErrorType.NotFound,
                    };
                }

                entity = _generalMapper.MapUpdate(model, entity);
                entity.Id = id;

                await _studentRepository.Update(entity);

                return new Result<StudentModel>
                {
                    Success = true,
                    Data = _generalMapper.Map(entity),
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception while updating student by id = {id}");
                throw;
            }
        }

        public async Task<Result> Delete(long id)
        {
            try
            {
                Student entity = await _studentRepository.GetById(id);

                if (entity == null)
                {
                    return new Result<StudentModel>
                    {
                        Success = false,
                        ErrorType = ErrorType.NotFound,
                    };
                }

                await _studentRepository.Delete(entity);

                return new Result<StudentModel>
                {
                    Success = true,
                    Data = _generalMapper.Map(entity),
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception while deleting student by id = {id}");
                throw;
            }
        }
    }
}
