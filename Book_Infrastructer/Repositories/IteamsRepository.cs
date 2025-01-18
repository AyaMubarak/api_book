using Book_Core.DTO_s;
using Book_Core.Interfaces;
using Book_Core.Mapping_Profiles;
using Book_Core.Models;
using Book_Infrastructer.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Infrastructer.Repositories
{
    public class IteamsRepository : IiteamsRepository
    {
        private readonly AppDbContext appDbContext;

        public IteamsRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        //public async Task<IEnumerable<IteamDTO>> GetIteamsAsync()
        //{
        //    var iteams = await appDbContext.Iteams
        //        .Include(x => x.IteamsUnites)
        //        .Select(x => new IteamDTO
        //        {
        //            Id = x.Id,
        //            Name = x.Name,
        //            IteamsUnit = x.IteamsUnites.Select(unit => unit.Units.Name).ToList(),
        //            Stores=x.InvIteamStores.Select(store=>store.Stores.Name).ToList(),
        //        })
        //        .ToListAsync();

        //    return iteams;
        //}  
        public async Task<PagedResponse<IteamDTO>> GetIteamsAsync(int page_index,int page_size)
        {
            var config = Mapping_Profiles.Config;
            var iteams=  appDbContext.Iteams.ProjectToType<IteamDTO>(config).AsQueryable();
            var result =await PaginationAsync(iteams, page_index, page_size);
            return result;
        }

        public async Task<PagedResponse<IteamDTO>> PaginationAsync(IQueryable<IteamDTO> query, int page_index, int page_size)
        {
            var total_iteams=await query.CountAsync();
            var items = await query.Skip((page_index - 1) * page_size).Take(page_size).ToListAsync();
            var result= new PagedResponse<IteamDTO> { 
                total_items = total_iteams,
                iteams = items,
                page_index = page_index,
                page_size = page_size

            };
            return result;
        }
    }
}
