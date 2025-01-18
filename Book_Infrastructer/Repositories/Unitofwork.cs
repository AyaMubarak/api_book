using Book_Core.Interfaces;
using Book_Core.Models;
using Book_Infrastructer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Book_Infrastructer.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
      
    
        private readonly AppDbContext appDbContext;

        public IAuthRepository AuthRepository { get; }
        public ICartRepository CartRepository { get; }
        public IInvoiceRepository InvoiceRepository { get; }
        public IiteamsRepository ItemsRepository { get; } 

        public UnitOfWork(
            AppDbContext appDbContext,
            UserManager<Users> userManager,
            SignInManager<Users> signInManager,
            IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            AuthRepository = new AuthRepository(userManager, signInManager, configuration);
            CartRepository = new CartRepository(appDbContext);
            InvoiceRepository = new InvoiceRepository(appDbContext);
            ItemsRepository = new IteamsRepository(appDbContext);
        }

        public async Task<int> SaveAsync()
        {
            return await appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
         appDbContext.Dispose();
        }
    }
}
