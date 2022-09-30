using AutoMapper;
using StudentProject.Data.Abstract;
using StudentProject.Entities.Concrete;
using StudentProject.Entities.DTOs;
using StudentProject.Services.Abstract;
using StudentProject.Shared.Utilities.Results.Abstract;
using StudentProject.Shared.Utilities.Results.ComplexTypes;
using StudentProject.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Services.Concrete
{
    public class StudentManager : IStudentService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public async Task<IDataResult<StudentDto>> Create(StudentAddDto studentAddDto, string createdByName)
        {
            var student = _mapper.Map<Student>(studentAddDto);
            student.CreatedByName = createdByName;
            student.ModifiedByName = createdByName;
            var addedStudent = await _unitOfWork.Students.AddAsync(student);
            await _unitOfWork.SaveAsync();

            return new DataResult<StudentDto>(new StudentDto
            {
                Student = addedStudent,
                ResultStatus = ResultStatus.Success,
                Message = $"{studentAddDto.Name} named student successfully added!"
            }, ResultStatus.Success, $"{studentAddDto.Name} adlı öğrenci başarıyla eklendi!");
        }

        public async Task<IDataResult<StudentDto>> Delete(int studentid, string modifiedByName)
        {
            var student = await _unitOfWork.Students.GetAsync(s => s.Id == studentid);
            if (student != null)
            {
                student.IsDeleted = true;
                student.ModifiedByName = modifiedByName;
                student.ModifiedDate = DateTime.Now;
                var deletedStudent = await _unitOfWork.Students.UpdateAsync(student);
                await _unitOfWork.SaveAsync();
                return new DataResult<StudentDto>(new StudentDto
                {
                    Student = deletedStudent,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{deletedStudent} named student is successfully deleted!"
                },ResultStatus.Success, $"{deletedStudent} adlı öğrenci başarıyla silinmiştir");
            }
            return new DataResult<StudentDto>(new StudentDto
            {
                Student = null,
                ResultStatus = ResultStatus.Success,
                Message = "Student is not deleted!"
            }, ResultStatus.Error, "İşlem gerçekleştirilemedi");
        }

        public async Task<IDataResult<StudentDto>> Get(int studentid)
        {
            var student = await _unitOfWork.Students.GetAsync(s => s.Id == studentid);
            if (student != null)
            {
                return new DataResult<StudentDto>( new StudentDto
                {
                    ResultStatus = ResultStatus.Success,
                    Student = student,
                }, ResultStatus.Success);
            }
            return new DataResult<StudentDto>(new StudentDto
            {

                Student = null,
                ResultStatus = ResultStatus.Error,
                Message = "Student is not founded"

            }, ResultStatus.Success, "Böyle bir öğrenci bulunamadı");
        }

        public async Task<IDataResult<StudentListDto>> GetAll()
        {

            var students = await _unitOfWork.Students.GetAllAsync();
            if (students.Count > -1)
            {
                return new DataResult<StudentListDto>(new StudentListDto
                {
                    ResultStatus = ResultStatus.Success,
                    Students = students,
                }, ResultStatus.Success);
            }
            return new DataResult<StudentListDto>(new StudentListDto
            {

                Students = null,
                ResultStatus = ResultStatus.Error,
                Message = "Students is not founded"

            }, ResultStatus.Success, "Öğrenciler bulunamadı");
        }

        public async Task<IDataResult<StudentListDto>> GetAllByNonDeleted()
        {
            var students = await _unitOfWork.Students.GetAllAsync(s => !s.IsDeleted);
            if (students.Count > -1)
            {
                return new DataResult<StudentListDto>(new StudentListDto
                {
                    ResultStatus = ResultStatus.Success,
                    Students = students,
                }, ResultStatus.Success);
            }
            return new DataResult<StudentListDto>(new StudentListDto
            {

                Students = null,
                ResultStatus = ResultStatus.Error,
                Message = "Students is not founded"

            }, ResultStatus.Success, "Öğrenciler bulunamadı");
        }

        public async Task<IDataResult<StudentListDto>> GetAllByNonDeletedAndActive()
        {
            var students = await _unitOfWork.Students.GetAllAsync(s => s.IsActive && !s.IsDeleted);
            if (students.Count > -1)
            {
                return new DataResult<StudentListDto>(new StudentListDto
                {
                    ResultStatus = ResultStatus.Success,
                    Students = students,
                }, ResultStatus.Success);
            }
            return new DataResult<StudentListDto>(new StudentListDto
            {

                Students = null,
                ResultStatus = ResultStatus.Error,
                Message = "Students is not founded"

            }, ResultStatus.Success, "Öğrenciler bulunamadı");
        }

        public async Task<IResult> HardDelete(int studentid)
        {
            var student = await _unitOfWork.Students.GetAsync(s => s.Id == studentid);
            if (student != null)
            {
                await _unitOfWork.Students.DeleteAsync(student);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Tamamen silindi!");
            }
            return new Result(ResultStatus.Error, "Öğrenci bulunamadı");
        }

        public async Task<IDataResult<StudentDto>> Update(StudentUpdateDto studentUpdateDto, string modifiedByName)
        {
            var currentStudent = await _unitOfWork.Students.GetAsync(s => s.Id == studentUpdateDto.Id);
            var student = _mapper.Map<StudentUpdateDto, Student>(studentUpdateDto, currentStudent);
            student.ModifiedByName = modifiedByName;
            var updatedStudent = await _unitOfWork.Students.UpdateAsync(student);
            await _unitOfWork.SaveAsync();
            return new DataResult<StudentDto>(new StudentDto
            {
                Student = updatedStudent,
                ResultStatus = ResultStatus.Success,
                Message = $"{studentUpdateDto} named student successfully updated!"
            }, ResultStatus.Success, $"{studentUpdateDto.Name} adlı öğrenci başarıyla güncellendi!");
        }
    }
}
