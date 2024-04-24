// using AutoMapper;
// using Domain.DTOs.GroupDtos;
// using Domain.Models;
// using Domain.Responses;
// using Infrastructure.Data;

// namespace Infrastructure.Services.Query;

// public class QueryService<T>(DataContext context)
// {
// public async Task<Response<T>> GetListGrCountGr()
// {
//     var query = (from g in context.Groups
//                 join stdGr in context.StudentGroups on g.Id equals stdGr.Id
//                 join std in context.Students on stdGr.Id equals std.Id
//                 let cont = context.Students.Count(s=>s.Id==stdGr.Id)
//                 select new
//                 {
//                     Gr = g,
//                     std = cont
//                 }
//     ).ToList();
// }
// }
