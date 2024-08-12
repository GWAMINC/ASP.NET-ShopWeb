using Microsoft.EntityFrameworkCore;
using ShopWeb.Data;
using ShopWeb.Models.Domain;

namespace ShopWeb.Repositories
{
    
    public class ProductCommentRepository : IProductCommentRepository
    {
        private readonly ShopWebDbContext shopWebDbContext;

        public ProductCommentRepository(ShopWebDbContext shopWebDbContext)
        {
            this.shopWebDbContext = shopWebDbContext;
        }
        public async Task<ProductComment> AddAsync(ProductComment productComment)
        {
            await shopWebDbContext.ProductComment.AddAsync(productComment);
            await shopWebDbContext.SaveChangesAsync();
            return productComment;
        }


        public async Task<IEnumerable<ProductComment>> GetAllAsync(Guid productId, int? page, int? pageSize)
        {
            var query = shopWebDbContext.ProductComment
                .Where(x => x.ProductId == productId)
                .OrderByDescending(x => x.TimeAdd);

            if (page.HasValue && pageSize.HasValue)
            {
                return await query
                    .Skip((page.Value - 1) * pageSize.Value)
                    .Take(pageSize.Value)
                    .ToListAsync();
            }

            return await query.ToListAsync();
        }



        public async Task<int> CountAllCommentsByIdAsync(Guid productId)
        {
            return await shopWebDbContext.ProductComment.Where(x => x.ProductId == productId).CountAsync();
        }
    }
}
