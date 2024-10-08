﻿using ShopWeb.Models.Domain;

namespace ShopWeb.Repositories
{
    public interface IProductCommentRepository
    {
        Task<ProductComment> AddAsync(ProductComment productComment);
        Task<IEnumerable<ProductComment>> GetAllAsync(Guid productId,int? page, int? pageSize);
        Task<int> CountAllCommentsByIdAsync(Guid productId);
    }
}
