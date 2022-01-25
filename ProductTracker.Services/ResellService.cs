using ProductTracker.Data;
using ProductTracker.Models.Resell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTracker.Services
{
    public class ResellService
    {
        private readonly Guid _UserId;
        public ResellService (Guid userId)
        {
            _UserId = userId; 
        }

        public bool CreateResell(ResellCreate model)
        {
            Resell resell = new Resell()
                {
                    SalePrice = model.SalePrice,
                    Customer = model.Customer,
                    Location = model.Location,
                    ResellDate = model.ResellDate
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Resells.Add(resell);
                return ctx.SaveChanges() == 1; 
            }
        }
        public IEnumerable<ResellListItem> GetResells()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Resells
                    .Where(e => e.OwnerID == _UserId)
                    .Select(
                        e =>
                        new ResellListItem
                        {
                            ResellId = e.ResellId,
                            SalePrice = e.SalePrice,
                            Customer = e.Customer,
                            Location = e.Location,
                            ResellDate = e.ResellDate
                        }
                   );
                return query.ToArray(); 
            }
        }
        public ResellDetail GetResellById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Resells
                    .Single(e => e.ResellId == id && e.OwnerID == _UserId);
                return
                    new ResellDetail
                    {
                        ResellId = entity.ResellId,
                        SalePrice = entity.SalePrice,
                        Customer = entity.Customer,
                        Location = entity.Location,
                        ResellDate = entity.ResellDate
                    };
            }
        }
        public bool UpdateResell(ResellEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Resells
                    .Single(e => e.ResellId == model.ResellId && e.OwnerID == _UserId);

                entity.SalePrice = model.SalePrice;
                entity.Customer = model.Customer;
                entity.Location = model.Location;
                entity.ResellDate = model.ResellDate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteResell(int ResellId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Resells
                    .Single(e => e.ResellId == ResellId && e.OwnerID == _UserId);

                ctx.Resells.Remove(entity);
                return ctx.SaveChanges() == 1; 
            }
        }
    }
}
