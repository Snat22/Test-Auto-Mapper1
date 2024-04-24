using System.Data.Common;
using System.Net;
using AutoMapper;
using Domain.DTOs.CourseDtos;
using Domain.Models;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.CourseServices;

public class CourseService(DataContext context, IMapper mapper) : ICourseService
{
#region AddCourse
    public async Task<Response<string>> AddCourse(AddCourseDto add)
    {
        try
        {
            var  existing = await context.Courses.FirstOrDefaultAsync(e=>e.CreatedAt==add.CreatedAt);
            if(existing != null)return new Response<string>(HttpStatusCode.BadRequest,"Course Already exist!");

            var mapped = mapper.Map<Course>(existing);
            
            await context.Courses.AddAsync(mapped);
            await context.SaveChangesAsync();
            return new Response<string>(HttpStatusCode.OK,"Added Succesfully!");
        }
        catch (System.Exception e)
        {
        return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

#endregion

#region GetCourseById
        public async Task<Response<GetCourseDto>> GetCourseById(int id)
        {
        try
        {
            var course = await context.Courses.FirstOrDefaultAsync(e=>e.Id==id);
            if(course == null) return new Response<GetCourseDto>(HttpStatusCode.BadRequest,"Not Found!");

            var mapped = mapper.Map<GetCourseDto>(course);  
            return new Response<GetCourseDto>(mapped);

        }
        catch (System.Exception e)
        {
            return new Response<GetCourseDto>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

#endregion
#region GetCourses
        public async Task<Response<List<GetCourseDto>>> GetCourses()
    {
        try
        {
            
            var course = await context.Courses.ToListAsync();
            var mapped = mapper.Map<List<GetCourseDto>>(course);
            return new Response<List<GetCourseDto>>(mapped);
        }
        catch (System.Exception e)
        {
            return new Response<List<GetCourseDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

#endregion
    
    #region UpdateCourse
        public async Task<Response<string>> UpdateCourse(UpdateCourseDto update)
    {
        try
        {
            var mapped = mapper.Map<Course>(update);
            context.Courses.Update(mapped);

            var res = await context.SaveChangesAsync();
            if (res == 0) return new Response<string>(HttpStatusCode.NotFound,"Not Found!");
            return new Response<string>(HttpStatusCode.OK,"YET Updated!");
        }
        catch (System.Exception e)
        {
        return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }
    #endregion

    #region DeleteCourse
        public async Task<Response<bool>> DeleteCourse(int id)
    {
        try
        {
           var existing = await context.Courses.Where(e=>e.Id==id).ExecuteDeleteAsync();
           if (existing == 0) return new Response<bool>(HttpStatusCode.BadRequest,"Not Found!");

           return new Response<bool>(HttpStatusCode.Accepted,true);
        }
        catch (System.Exception e)
        {
            
            return new Response<bool>(HttpStatusCode.InternalServerError,e.Message);
        }
    }
    #endregion

}
