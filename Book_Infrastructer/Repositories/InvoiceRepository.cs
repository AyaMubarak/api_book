using Book_Core.DTO_s;
using Book_Core.Interfaces;
using Book_Core.Models;
using Book_Infrastructer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Infrastructer.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext appDbContext;

        public InvoiceRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<string> CreateInvoiceAsync(int customer_id)
        {
          var cartIteams=await appDbContext.ShoppingCartIteams.Include(c=>c.Iteams).Where(c=>c.Cus_Id==customer_id).ToListAsync();
            if(cartIteams==null || !cartIteams.Any())
            {
                return "no iteams in the cart to create invoice";
            }
            var unavaliableiteams = new List<string>();
            double TotalNetPrice = 0;
            foreach (var iteam in cartIteams)
            {
                var iteamstore = appDbContext.InvIteamStores.FirstOrDefault(i => i.Iteam_Id == iteam.Iteam_Id && i.Store_Id == iteam.Store_Id);
                if (iteamstore == null)
                {
                    unavaliableiteams.Add(iteam.Iteams.Name);
                    continue;
                }
                var avaliableQuentity=iteamstore.Balance-iteamstore.ReversedQuintity;
                if (iteam.Quantity > avaliableQuentity)
                {
                    unavaliableiteams.Add(iteam.Iteams.Name);
                    continue;
                }
            }
            var unavaliableiteamsCount=unavaliableiteams.Count();
            var numberOfCartIteams=cartIteams.Count();
            if (unavaliableiteamsCount==numberOfCartIteams)
            {
                return "All iteams in cart unavaliable(";
            }
                var invoice = new Invoice
            {
                Cus_Id = customer_id,
                CreatedAt = DateTime.Now,
                NetPrice = 0,
                Transaction_Type = 1,
                Payment_Type = 1,
                IsPosted = false,
                IsClosed = false,
                IsReviewed = false,

            };
            await appDbContext.Invoice.AddAsync(invoice);
            await appDbContext.SaveChangesAsync();
          
           
            foreach(var iteam  in cartIteams)
            {
                var iteamstore = appDbContext.InvIteamStores.FirstOrDefault(i => i.Iteam_Id == iteam.Iteam_Id && i.Store_Id == iteam.Store_Id);
                double unitprice=iteam.Iteams.Price;
                double IteamTotalPrice=iteam.Quantity+unitprice;
                TotalNetPrice += IteamTotalPrice;
                var invoiceDetail = new InvoiceDetails
                {
                    Invoice_Id = invoice.Id,
                    Iteam_Id = iteam.Iteam_Id,
                    Quantity = iteam.Quantity,
                    Factor = 1,
                    Price=(int)unitprice,
                    Unit_id=iteam.Unit_Id,
                    CreatedAt=iteam.CreatedAt,

                };
                appDbContext.InvoiceDetails.Add(invoiceDetail);
                iteamstore.ReversedQuintity += iteam.Quantity;
                appDbContext.InvIteamStores.Update(iteamstore);

            }
            invoice.NetPrice= TotalNetPrice;
            appDbContext.ShoppingCartIteams.RemoveRange(
                cartIteams.Where(i => !unavaliableiteams.Contains(i.Iteams.Name)));
            await appDbContext.SaveChangesAsync();
            if (unavaliableiteams.Any())
            {

                var unavaliableIteamsMessage = string.Join(", ", unavaliableiteams.Select(iteam =>
                {
                    var cartIteam = cartIteams.FirstOrDefault(i => i.Iteams.Name == iteam);
                    if (cartIteam != null)
                    {
                        var iteamStore = appDbContext.InvIteamStores.FirstOrDefault(i => i.Iteams.Id == cartIteam.Iteam_Id);
                        if (iteamStore != null)
                        {
                            double avaliableQuentity = iteamStore.Balance - iteamStore.ReversedQuintity;
                            return $"{iteam}(Avaliable Quentity={avaliableQuentity})";

                        }
                        

                        }
                    return iteam;
                    }
                
                

                ));
                return $" with ID:{invoice.Id} and total price :{TotalNetPrice},However the following iteams were unanvilable {unavaliableIteamsMessage}";
                    }
            return $" with ID:{invoice.Id} and total price :{TotalNetPrice}";
        }

        public async Task<InvoiceRecieptDTO> GetInvoiceReciept(int customer_id, int invoice_id)
        {
          var invoice=await appDbContext.Invoice.Include(i=>i.InvoiceDetails).ThenInclude(x=>x.Iteams).FirstOrDefaultAsync(i=>i.Cus_Id==customer_id&&i.Id==invoice_id);
            if (invoice == null)
            {
                return null;
            }
            double total_price = 0;
            foreach(var iteam in invoice.InvoiceDetails)
            {
                double iteam_price = iteam.Quantity * iteam.Price;
                total_price += iteam_price;
            }
            invoice.NetPrice = total_price;
            await appDbContext.SaveChangesAsync();
            var reciept = new InvoiceRecieptDTO
            {
                invoice_id = invoice_id,
                customer_id = invoice.Cus_Id,
                createsAt = invoice.CreatedAt,
                total_price = total_price,
                items = invoice.InvoiceDetails.Select(d => new InvoiceIteamDTO
                {
                    iteam_name = d.Iteams.Name,
                    quentity = d.Quantity,
                    unit_name = appDbContext.Units.FirstOrDefault(u => u.Id == d.Unit_id)?.Name ?? "unknown",
                    total_price = (d.Quantity * d.Price),
                    price_per_units = d.Price

                }).ToList()
            };
            return reciept;
        }
    }
}
