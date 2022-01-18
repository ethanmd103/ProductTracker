using ProductTracker.Data;
using ProductTracker.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTracker.Services
{
    public class ProductService
    {
        private readonly Guid _UserId;

        public ProductService(Guid userId)
        {
            _UserId = userId;
        }

        //Create instance of product
        public bool CreateProduct(ProductCreate Model)
        {
            Product product = new Product()
            {
                OwnerID = _UserId,
                Name = Model.Name,
                Category = Model.Category,
                MSRP = Model.MSRP
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(product);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ProductListItem> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Products
                    .Where(e => e.OwnerID == _UserId)
                    .Select(
                        e =>
                        new ProductListItem
                        {
                            ProductID = e.ProductID,
                            Name = e.Name,
                            Category = e.Category,
                            MSRP = e.MSRP
                        });
                return query.ToArray();
            }
        }
    }
}