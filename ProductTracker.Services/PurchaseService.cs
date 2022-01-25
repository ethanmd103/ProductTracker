using ProductTracker.Data;
using ProductTracker.Models.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTracker.Services
{
    public class PurchaseService
    {
        private readonly Guid _UserId;

        public PurchaseService(Guid userId)
        {
            _UserId = userId;
        }
        
        public bool CreatePurchase(PurchaseCreate model)
        {
            Purchase purchase = new Purchase()
                {
                    OwnerID = _UserId,
                    ItemName = model.ItemName,
                    PurchasePrice = model.PurchasePrice,
                    StoreBoughtFrom = model.StoreBoughtFrom,
                    Condition = model.Condition,
                    PurchaseDate = model.PurchaseDate
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Purchases.Add(purchase);
                return ctx.SaveChanges() == 1; 
            }
        }
        public IEnumerable<PurchaseListItem> GetPurchases()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Purchases
                    .Where(e => e.OwnerID == _UserId)
                    .Select(
                        e =>
                        new PurchaseListItem
                        {
                            PurchaseId = e.PurchaseId,
                            ItemName = e.ItemName,
                            PurchasePrice = e.PurchasePrice,
                            StoreBoughtFrom = e.StoreBoughtFrom,
                            Condition = e.Condition,
                            PurchaseDate = e.PurchaseDate,
                        }
                        ).ToList().OrderBy(e => e.ItemName);
                return query.OrderBy(e => e.ItemName);
            }
        }
        public PurchaseDetail GetPurchaseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Purchases
                    .Single(e => e.PurchaseId == id && e.OwnerID == _UserId);
                return
                    new PurchaseDetail
                    {
                        PurchaseId = entity.PurchaseId,
                        ItemName = entity.ItemName,
                        PurchasePrice = entity.PurchasePrice,
                        StoreBoughtFrom = entity.StoreBoughtFrom,
                        Condition = entity.Condition,
                        PurchaseDate = entity.PurchaseDate
                    };
            }
        }

        public bool UpdatePurchase(PurchaseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Purchases
                    .Single(e => e.PurchaseId == model.PurchaseId && e.OwnerID == _UserId);

                entity.PurchaseId = model.PurchaseId;
                entity.ItemName = model.ItemName;
                entity.PurchasePrice = model.PurchasePrice;
                entity.StoreBoughtFrom = model.StoreBoughtFrom;
                entity.Condition = model.Condition;
                entity.PurchaseDate = model.PurchaseDate;

                return ctx.SaveChanges() == 1;
                    
            }
        }

        public bool DeletePurchase(int PurchaseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Purchases
                    .Single(e => e.PurchaseId == PurchaseId && e.OwnerID == _UserId);

                ctx.Purchases.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
