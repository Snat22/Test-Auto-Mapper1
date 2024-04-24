using System.Net;
using AutoMapper;
using Domain.DTOs.GroupDtos;
using Domain.Models;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.GroupServices;

public class GroupService(DataContext context,IMapper mapper):IGroupService
{
    #region AddGroup
    public async Task<Response<string>> AddGroup(AddGroupDto add)
    {
        try
        {
            var  existing = await context.Groups.FirstOrDefaultAsync(e=>e.GroupName==add.GroupName);
            if(existing != null)return new Response<string>(HttpStatusCode.BadRequest,"Group Already exist!");

            var mapped = mapper.Map<Group>(existing);
            
            await context.Groups.AddAsync(mapped);
            await context.SaveChangesAsync();
            return new Response<string>(HttpStatusCode.OK,"Added Succesfully!");
        }
        catch (System.Exception e)
        {
        return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

#endregion

#region GetGroupById
        public async Task<Response<GetGroupDto>> GetGroupById(int id)
        {
        try
        {
            var Group = await context.Groups.FirstOrDefaultAsync(e=>e.Id==id);
            if(Group == null) return new Response<GetGroupDto>(HttpStatusCode.BadRequest,"Not Found!");

            var mapped = mapper.Map<GetGroupDto>(Group);  
            return new Response<GetGroupDto>(mapped);

        }
        catch (System.Exception e)
        {
            return new Response<GetGroupDto>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

#endregion
#region GetGroups
        public async Task<Response<List<GetGroupDto>>> GetGroups()
    {
        try
        {
            
            var Group = await context.Groups.ToListAsync();
            var mapped = mapper.Map<List<GetGroupDto>>(Group);
            return new Response<List<GetGroupDto>>(mapped);
        }
        catch (System.Exception e)
        {
            return new Response<List<GetGroupDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

#endregion
    
    #region UpdateGroup
        public async Task<Response<string>> UpdateGroup(UpdateGroupDto update)
    {
        try
        {
            var mapped = mapper.Map<Group>(update);
            context.Groups.Update(mapped);

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

    #region DeleteGroup
        public async Task<Response<bool>> DeleteGroup(int id)
    {
        try
        {
           var existing = await context.Groups.Where(e=>e.Id==id).ExecuteDeleteAsync();
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
