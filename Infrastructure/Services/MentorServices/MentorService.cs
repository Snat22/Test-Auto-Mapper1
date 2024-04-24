using System.Net;
using AutoMapper;
using Domain.DTOs.MentorDtos;
using Domain.Models;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.MentorServices;

public class MentorService(DataContext context,IMapper mapper):IMentorService
{
    #region AddMentor
    public async Task<Response<string>> AddMentor(AddMentorDto add)
    {
        try
        {
            var  existing = await context.Mentors.FirstOrDefaultAsync(e=>e.Email==add.Email);
            if(existing != null)return new Response<string>(HttpStatusCode.BadRequest,"Mentor Already exist!");

            var mapped = mapper.Map<Mentor>(existing);
            
            await context.Mentors.AddAsync(mapped);
            await context.SaveChangesAsync();
            return new Response<string>(HttpStatusCode.OK,"Added Succesfully!");
        }
        catch (System.Exception e)
        {
        return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

#endregion

#region GetMentorById
        public async Task<Response<GetMentorDto>> GetMentorById(int id)
        {
        try
        {
            var Mentor = await context.Mentors.FirstOrDefaultAsync(e=>e.Id==id);
            if(Mentor == null) return new Response<GetMentorDto>(HttpStatusCode.BadRequest,"Not Found!");

            var mapped = mapper.Map<GetMentorDto>(Mentor);  
            return new Response<GetMentorDto>(mapped);

        }
        catch (System.Exception e)
        {
            return new Response<GetMentorDto>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

#endregion
#region GetMentors
        public async Task<Response<List<GetMentorDto>>> GetMentors()
    {
        try
        {
            
            var Mentor = await context.Mentors.ToListAsync();
            var mapped = mapper.Map<List<GetMentorDto>>(Mentor);
            return new Response<List<GetMentorDto>>(mapped);
        }
        catch (System.Exception e)
        {
            return new Response<List<GetMentorDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

#endregion
    
    #region UpdateMentor
        public async Task<Response<string>> UpdateMentor(UpdateMentorDto update)
    {
        try
        {
            var mapped = mapper.Map<Mentor>(update);
            context.Mentors.Update(mapped);

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

    #region DeleteMentor
        public async Task<Response<bool>> DeleteMentor(int id)
    {
        try
        {
           var existing = await context.Mentors.Where(e=>e.Id==id).ExecuteDeleteAsync();
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
