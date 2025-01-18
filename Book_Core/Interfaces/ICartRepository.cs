using Book_Core.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Core.Interfaces
{
    public interface ICartRepository
    {
      Task<string>  AddBulkQuantityToCartAsync(CartIteamDTO cartIteamDTO, int? userId);
       Task<string> AddOneQuantityToCartAsync(CartIteamDTO cartIteamDTO, int? userId);
       Task<IEnumerable<UserCartIteamsDTO>>getAllIteamsFromCart( int? customerId);
    }
}
