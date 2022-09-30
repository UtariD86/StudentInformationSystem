using StudentProject.Entities.DTOs;
using StudentProject.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Services.Abstract
{
    public interface IStudentService
    {
        Task<IDataResult<StudentDto>> Get(int studentid);

        Task<IDataResult<StudentListDto>> GetAll();

        Task<IDataResult<StudentListDto>> GetAllByNonDeleted();

        Task<IDataResult<StudentListDto>> GetAllByNonDeletedAndActive();

        Task<IDataResult<StudentDto>> Create(StudentAddDto studentAddDto, string createdByName);

        Task<IDataResult<StudentDto>> Update(StudentUpdateDto studentUpdateDto, string modifiedByName);

        Task<IDataResult<StudentDto>> Delete(int studentid, string modifiedByName);

        Task<IResult> HardDelete(int studentid);
    }
}
