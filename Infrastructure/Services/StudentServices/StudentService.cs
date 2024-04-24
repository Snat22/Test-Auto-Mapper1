using System.Net;
using AutoMapper;
using Domain.DTOs.AddStudentDtos;
using Domain.DTOs.StudentDtos;
using Domain.Models;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.StudentServices;

public class StudentService(DataContext context,IMapper mapper):IStudentService
{
    #region AddStudent
    public async Task<Response<string>> AddStudent(AddStudentDto add)
    {
        try
        {
            var  existing = await context.Students.FirstOrDefaultAsync(e=>e.Email==add.Email);
            if(existing != null)return new Response<string>(HttpStatusCode.BadRequest,"Student Already exist!");

            var mapped = mapper.Map<Student>(existing);
            
            await context.Students.AddAsync(mapped);
            await context.SaveChangesAsync();
            return new Response<string>(HttpStatusCode.OK,"Added Succesfully!");
        }
        catch (System.Exception e)
        {
        return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

#endregion

#region GetStudentById
        public async Task<Response<GetStudentDto>> GetStudentById(int id)
        {
        try
        {
            var Student = await context.Students.FirstOrDefaultAsync(e=>e.Id==id);
            if(Student == null) return new Response<GetStudentDto>(HttpStatusCode.BadRequest,"Not Found!");

            var mapped = mapper.Map<GetStudentDto>(Student);  
            return new Response<GetStudentDto>(mapped);

        }
        catch (System.Exception e)
        {
            return new Response<GetStudentDto>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

#endregion
#region GetStudents
        public async Task<Response<List<GetStudentDto>>> GetStudents()
    {
        try
        {
            
            var Student = await context.Students.ToListAsync();
            var mapped = mapper.Map<List<GetStudentDto>>(Student);
            return new Response<List<GetStudentDto>>(mapped);
        }
        catch (System.Exception e)
        {
            return new Response<List<GetStudentDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

#endregion
    
    #region UpdateStudent
        public async Task<Response<string>> UpdateStudent(UpdateStudentDto update)
    {
        try
        {
            var mapped = mapper.Map<Student>(update);
            context.Students.Update(mapped);

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

    #region DeleteStudent
        public async Task<Response<bool>> DeleteStudent(int id)
    {
        try
        {
           var existing = await context.Students.Where(e=>e.Id==id).ExecuteDeleteAsync();
           if (existing == 0) return new Response<bool>(HttpStatusCode.BadRequest,"Not Found!");

           return new Response<bool>(HttpStatusCode.Accepted,true);
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
    #endregion

}
