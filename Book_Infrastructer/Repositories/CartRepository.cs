using Book_Core.DTO_s;
using Book_Core.Interfaces;
using Book_Core.Models;
using Book_Infrastructer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Infrastructer.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext appDbContext;

        public CartRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<string> AddBulkQuantityToCartAsync(CartIteamDTO DTO, int userId)
        {
            var iteams = await appDbContext.Iteams.FindAsync(DTO.IteamCode);
            var stores = await appDbContext.Stores.FindAsync(DTO.StoreId); 

            if (iteams == null || stores == null) 
            {
                return "Item or store is not found";
            }

            var existingIteam = await appDbContext.ShoppingCartIteams
                .FirstOrDefaultAsync(x => x.Cus_Id == userId && x.Iteam_Id == DTO.IteamCode && x.Store_Id == DTO.StoreId);

            if (existingIteam != null)
            {
                existingIteam.Quantity = DTO.Quentity;
                existingIteam.Unit_Id = DTO.UnitCode;
                existingIteam.Store_Id = DTO.StoreId;
                existingIteam.UpdatedAt = DateTime.Now;
            }
            else
            {
                var shoppingCartIteam = new ShoppingCartIteams
                {
                    Cus_Id = userId,
                    Iteam_Id = DTO.IteamCode,
                    Quantity = DTO.Quentity,
                    Unit_Id = DTO.UnitCode,
                    Store_Id = DTO.StoreId,
                    UpdatedAt = null,
                    CreatedAt = DateTime.Now
                };
                await appDbContext.ShoppingCartIteams.AddAsync(shoppingCartIteam);
            }

            await appDbContext.SaveChangesAsync();
            return "Item added to cart successfully";
        }

        public Task<string> AddBulkQuantityToCartAsync(CartIteamDTO cartIteamDTO, int? userId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> AddOneQuantityToCartAsync(CartIteamDTO cartIteamDTO, int? userId)
        {
            var iteams = await appDbContext.Iteams.FindAsync(cartIteamDTO.IteamCode);
            var store = await appDbContext.Stores.FindAsync(cartIteamDTO.StoreId);

            if (iteams == null || store == null)
            {
                return "Item or store is not found";
            }

            var existingIteam = await appDbContext.ShoppingCartIteams
                .FirstOrDefaultAsync(c => c.Cus_Id == userId && c.Iteam_Id == cartIteamDTO.IteamCode && c.Store_Id == cartIteamDTO.StoreId); 

            if (existingIteam != null)
            {
                existingIteam.Quantity -= 1; 
                existingIteam.UpdatedAt = DateTime.Now;
            }
            else
            {
                var shoppingCartIteam = new ShoppingCartIteams
                {
                    Cus_Id = (int)userId,
                    Iteam_Id = cartIteamDTO.IteamCode,
                    Store_Id = cartIteamDTO.StoreId,
                    Quantity = 1,
                    CreatedAt = DateTime.Now,
                    Unit_Id = cartIteamDTO.UnitCode
                };
                await appDbContext.ShoppingCartIteams.AddAsync(shoppingCartIteam);
            }

            await appDbContext.SaveChangesAsync();
            return "Item added to cart successfully";
        }

        public async Task<IEnumerable<UserCartIteamsDTO>> getAllIteamsFromCart(int? customerId)
        {
            var cartIteam=await appDbContext.ShoppingCartIteams.Where(x=>x.Cus_Id==customerId)
                .Include(x=>x.Iteams).
                Include(x=>x.Iteams.IteamsUnites).
                ThenInclude(x=>x.Units).
                ToListAsync();

            var itemDto = cartIteam.Select(x => new UserCartIteamsDTO
            {
                name = x.Iteams.Name,
                price = x.Iteams.Price,
                Quentity=x.Quantity,
                IteamUnit = x.Iteams.IteamsUnites.Where(unit => unit.Unit_Id == x.Unit_Id && x.Iteam_Id==unit.Iteam_Id).Select(unit => unit.Units.Name).FirstOrDefault()
            }).ToList();
            return itemDto;
        }
    }
}
