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
    public class LessonManager : ILessonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public async Task<IDataResult<LessonDto>> Create(LessonAddDto lessonAddDto, string createdByName)
        {
            var lesson = _mapper.Map<Lesson>(lessonAddDto);
            lesson.CreatedByName = createdByName;
            lesson.ModifiedByName = createdByName;
            var addedLesson= await _unitOfWork.Lessons.AddAsync(lesson);
            await _unitOfWork.SaveAsync();
            return new DataResult<LessonDto>(new LessonDto
            {
                Lesson = addedLesson,
                ResultStatus = ResultStatus.Success,
                Message=$"{lessonAddDto.Name} named lesson successfully added."
            },ResultStatus.Success, $"{lessonAddDto.Name} adlı ders başarıyla eklendi.");
        }

        public async Task<IDataResult<LessonDto>> Delete(int lessonid, string modifiedByName)
        {
            var lesson = await _unitOfWork.Lessons.GetAsync(s => s.Id == lessonid);
            if (lesson != null)
            {
                lesson.IsDeleted = true;
                lesson.ModifiedByName = modifiedByName;
                lesson.ModifiedDate = DateTime.Now;
                var deletedLesson = await _unitOfWork.Lessons.UpdateAsync(lesson);
                await _unitOfWork.SaveAsync();
                return new DataResult<LessonDto>(new LessonDto
                {
                    Lesson = deletedLesson,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{deletedLesson} named lesson is successfully deleted!"
                }, ResultStatus.Success, $"{deletedLesson} adlı ders başarıyla silinmiştir");
            }
            return new DataResult<LessonDto>(new LessonDto
            {
                Lesson = null,
                ResultStatus = ResultStatus.Success,
                Message = "Lesson is not deleted!"
            }, ResultStatus.Error, "İşlem gerçekleştirilemedi");
        }

        public async Task<IDataResult<LessonDto>> Get(int lessonid)
        {
            var lesson = await _unitOfWork.Lessons.GetAsync(l => l.Id == lessonid);
            if (lesson != null)
            {
                return new DataResult<LessonDto>(new LessonDto
                {
                    ResultStatus = ResultStatus.Success,
                    Lesson = lesson
                },ResultStatus.Success);   
            }
            return new DataResult<LessonDto>(new LessonDto
            {
                ResultStatus = ResultStatus.Error,
                Lesson = null,
                Message = "Lesson is not founded!"
            }, ResultStatus.Success, "Böyle bir ders bulunamadı");
        }

        public async Task<IDataResult<LessonListDto>> GetAll()
        {
            var query = _unitOfWork.Lessons.GetAsQuaryable();
            var lessonList = query.ToList();
            //var lessons = await _unitOfWork.Lessons.GetAllAsync();
            if (lessonList.Count <-1)
            {
                return new DataResult<LessonListDto>(new LessonListDto
                {
                    ResultStatus= ResultStatus.Success,
                    Lessons = lessonList
                }, ResultStatus.Success);
            }
            return new DataResult<LessonListDto>(new LessonListDto
            {
                ResultStatus = ResultStatus.Error,
                Lessons = null,
                Message= "Lessons is not founded!"
            },ResultStatus.Success, "Dersler bulunamadı");
        }

        public async Task<IDataResult<LessonListDto>> GetAllByNonDeleted()
        {
            var query = _unitOfWork.Lessons.GetAsQuaryable();
            query = query.Where(l => !l.IsDeleted);
            var lessonList = query.ToList();
            //var lessons = await _unitOfWork.Lessons.GetAllAsync(l => l.IsDeleted == false);
            if (lessonList.Count >-1)
            {
                return new DataResult<LessonListDto>(new LessonListDto
                {
                    ResultStatus= ResultStatus.Success,
                    Lessons = lessonList
                }, ResultStatus.Success);
            }
            return new DataResult<LessonListDto>(new LessonListDto
            {
                ResultStatus = ResultStatus.Error,
                Lessons = null,
                Message = "Lessons is not founded!"
            },ResultStatus.Error, "Dersler bulunamadı");
        }

        public async Task<IDataResult<LessonListDto>> GetAllByNonDeletedAndActive()
        {
            var query = _unitOfWork.Lessons.GetAsQuaryable();
            query = query.Where(s => !s.IsDeleted && s.IsActive);
            var lessonList = query.ToList();
            //var lessons = await _unitOfWork.Lessons.GetAllAsync(l => l.IsDeleted == false && l.IsActive == true);
            if (lessonList.Count >- 1)
            {
                return new DataResult<LessonListDto>(new LessonListDto
                {
                    ResultStatus = ResultStatus.Success,
                    Lessons = lessonList
                }, ResultStatus.Success);
            }
            return new DataResult<LessonListDto>(new LessonListDto
            {
                ResultStatus = ResultStatus.Error,
                Lessons = null,
                Message = "Lessons is not founded!"
            }, ResultStatus.Error, "Dersler bulunamadı!");
        }

        public async Task<IResult> HardDelete(int lessonid)
        {
            var lesson = await _unitOfWork.Lessons.GetAsync(s => s.Id == lessonid);
            if (lesson != null)
            {
                await _unitOfWork.Lessons.DeleteAsync(lesson);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Lesson is hard deleted!");
            }
            return new Result(ResultStatus.Error, "Ders bulunamadı");
        }

        public async Task<IDataResult<LessonDto>> Update(LessonUpdateDto lessonUpdateDto, string modifiedByName)
        {
            var currentLesson = await _unitOfWork.Lessons.GetAsync(l => l.Id == lessonUpdateDto.Id);
            var lesson = _mapper.Map<LessonUpdateDto, Lesson>(lessonUpdateDto, currentLesson);
            lesson.ModifiedByName = modifiedByName;
            var updatedLesson = await _unitOfWork.Lessons.UpdateAsync(lesson);
            await _unitOfWork.SaveAsync();
            return new DataResult<LessonDto>(new LessonDto
            {
                Lesson = updatedLesson,
                ResultStatus = ResultStatus.Success,
                Message = $"{lessonUpdateDto} named lesson successfully updated!"
            }, ResultStatus.Success, $"{lessonUpdateDto.Name} adlı ders başarıyla güncellendi!");
        }
    }
}
