using Book_Core.DTO_s;
using Book_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Core.Interfaces
{
    public interface IiteamsRepository
    {
        Task<PagedResponse<IteamDTO>>GetIteamsAsync(int page_index, int page_size);
        Task<PagedResponse<IteamDTO>>PaginationAsync(IQueryable<IteamDTO>query,int page_index,int pagesize);
    }
}
