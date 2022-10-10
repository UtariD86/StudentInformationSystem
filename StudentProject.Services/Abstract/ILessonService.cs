using StudentProject.Entities.DTOs;
using StudentProject.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Services.Abstract
{
    public interface ILessonService
    {
        Task<IDataResult<LessonDto>> Get(int lessonid);

        Task<IDataResult<LessonListDto>> GetAll();

        Task<IDataResult<LessonListDto>> GetAllByNonDeleted();

        Task<IDataResult<LessonListDto>> GetAllByNonDeletedAndActive();

        Task<IDataResult<LessonDto>> Create(LessonAddDto lessonAddDto, string createdByName);

        Task<IDataResult<LessonDto>> Update(LessonUpdateDto lessonUpdateDto, string modifiedByName);

        Task<IDataResult<LessonDto>> Delete(int lessonid, string modifiedByName);

        Task<IResult> HardDelete(int lessonid);
    }
}
