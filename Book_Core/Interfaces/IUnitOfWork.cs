using System.Threading.Tasks;

namespace Book_Core.Interfaces
{
    public interface IUnitOfWork
    {
        IAuthRepository AuthRepository { get; }
        ICartRepository CartRepository { get; }
        IInvoiceRepository InvoiceRepository { get; }
        IiteamsRepository ItemsRepository { get; } 
        Task<int> SaveAsync(); 
    }
}
