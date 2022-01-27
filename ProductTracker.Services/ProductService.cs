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
                MSRP = Model.MSRP,
                
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
                            ProductId = e.ProductId,
                            Name = e.Name,
                            Category = e.Category,
                            MSRP = e.MSRP
                        });
                
                return query.ToArray();
            }
        }
        public ProductDetail GetProductById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Products
                    .Single(e => e.ProductId == id & e.OwnerID == _UserId);
                return
                    new ProductDetail
                    {
                        ProductId = entity.ProductId,
                        Name = entity.Name,
                        Category = entity.Category,
                        MSRP = entity.MSRP
                    };
            }
        }
        public bool UpdateProduct (ProductEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Products
                    .Single(e => e.ProductId == model.ProductId && e.OwnerID == _UserId);

                entity.ProductId = model.ProductId;
                entity.Name = model.Name;
                entity.Category = model.Category;
                entity.MSRP = model.MSRP;
               
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProduct (int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Products
                    .Single(e => e.ProductId == productId && e.OwnerID == _UserId);

                ctx.Products.Remove(entity);
                return ctx.SaveChanges() == 1; 
            }
        }
    }
}