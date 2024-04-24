using System.Net;
using AutoMapper;
using Domain.DTOs.MentorGroupDtos;
using Domain.Models;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.MentorGroupService;

public class MentorGroupService(DataContext context,IMapper mapper):IMentorGroupService
{
    #region AddMentorGroup
    public async Task<Response<string>> AddMentorGroup(AddMentorGroupsDto add)
    {
        try
        {
            var  existing = await context.MentorGroups.FirstOrDefaultAsync(e=>e.MentorId==add.MentorId);
            if(existing != null)return new Response<string>(HttpStatusCode.BadRequest,"MentorGroup Already exist!");

            var mapped = mapper.Map<MentorGroup>(existing);
            
            await context.MentorGroups.AddAsync(mapped);
            await context.SaveChangesAsync();
            return new Response<string>(HttpStatusCode.OK,"Added Succesfully!");
        }
        catch (System.Exception e)
        {
        return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

#endregion

#region GetMentorGroupById
        public async Task<Response<GetMentorGroupDto>> GetMentorGroupById(int Id)
        {
        try
        {
            var MentorGroup = await context.MentorGroups.FirstOrDefaultAsync(e=>e.Id==Id);
            if(MentorGroup == null) return new Response<GetMentorGroupDto>(HttpStatusCode.BadRequest,"Not Found!");

            var mapped = mapper.Map<GetMentorGroupDto>(MentorGroup);  
            return new Response<GetMentorGroupDto>(mapped);

        }
        catch (System.Exception e)
        {
            return new Response<GetMentorGroupDto>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

#endregion
#region GetMentorGroups
        public async Task<Response<List<GetMentorGroupDto>>> GetMentorGroups()
    {
        try
        {
            
            var MentorGroup = await context.MentorGroups.ToListAsync();
            var mapped = mapper.Map<List<GetMentorGroupDto>>(MentorGroup);
            return new Response<List<GetMentorGroupDto>>(mapped);
        }
        catch (System.Exception e)
        {
            return new Response<List<GetMentorGroupDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

#endregion
    
    #region UpdateMentorGroup
        public async Task<Response<string>> UpdateMentroGroup(UpdateMentorGroupDto update)
    {
        try
        {
            var mapped = mapper.Map<MentorGroup>(update);
            context.MentorGroups.Update(mapped);

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

    #region DeleteMentorGroup
        public async Task<Response<bool>> DeleteMentorGroup(int id)
    {
        try
        {
           var existing = await context.MentorGroups.Where(e=>e.Id==id).ExecuteDeleteAsync();
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
