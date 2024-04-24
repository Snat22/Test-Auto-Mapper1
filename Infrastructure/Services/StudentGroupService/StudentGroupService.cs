using System.Net;
using AutoMapper;
using Domain.DTOs.StudentGroupDto;
using Domain.Models;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.StudentGroupService;

public class StudentGroupService(DataContext context,IMapper mapper):IStudentGroupService
{
    
    #region AddStudentGroup
    public async Task<Response<string>> AddStudentGroup(AddStudentGroupDtos add)
    {
        try
        {
            var  existing = await context.StudentGroups.FirstOrDefaultAsync(e=>e.StudentId==add.StudentId);
            if(existing != null)return new Response<string>(HttpStatusCode.BadRequest,"StudentGroup Already exist!");

            var mapped = mapper.Map<StudentGroup>(existing);
            
            await context.StudentGroups.AddAsync(mapped);
            await context.SaveChangesAsync();
            return new Response<string>(HttpStatusCode.OK,"Added Succesfully!");
        }
        catch (System.Exception e)
        {
        return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

#endregion

#region GetStudentGroupById
        public async Task<Response<GetStudentGroupDto>> GetStudentGroupById(int Id)
        {
        try
        {
            var StudentGroup = await context.StudentGroups.FirstOrDefaultAsync(e=>e.Id==Id);
            if(StudentGroup == null) return new Response<GetStudentGroupDto>(HttpStatusCode.BadRequest,"Not Found!");

            var mapped = mapper.Map<GetStudentGroupDto>(StudentGroup);  
            return new Response<GetStudentGroupDto>(mapped);

        }
        catch (System.Exception e)
        {
            return new Response<GetStudentGroupDto>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

#endregion
#region GetStudentGroups
        public async Task<Response<List<GetStudentGroupDto>>> GetStudentGroups()
    {
        try
        {
            
            var StudentGroup = await context.StudentGroups.ToListAsync();
            var mapped = mapper.Map<List<GetStudentGroupDto>>(StudentGroup);
            return new Response<List<GetStudentGroupDto>>(mapped);
        }
        catch (System.Exception e)
        {
            return new Response<List<GetStudentGroupDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

#endregion
    
    #region UpdateStudentGroup
        public async Task<Response<string>> UpdateStudentGroup(UpdateStudentGroupDto update)
    {
        try
        {
            var mapped = mapper.Map<StudentGroup>(update);
            context.StudentGroups.Update(mapped);

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

    #region DeleteStudentGroup
        public async Task<Response<bool>> DeleteStudentGroup(int id)
    {
        try
        {
           var existing = await context.StudentGroups.Where(e=>e.Id==id).ExecuteDeleteAsync();
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
