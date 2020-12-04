using OnlineFood.Database;
using OnlineFood.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineFood.Infrastructure.Services
{
    public class CategoryService
    {
        private readonly OnlineFoodContext _onlineFoodContext;
        public CategoryService(OnlineFoodContext onlineFoodContext)
        {
            _onlineFoodContext = onlineFoodContext;
        }
        public Category GetCategory(int categoryId)
        {
            var category = _onlineFoodContext.Categories.SingleOrDefault(x=>x.Id== categoryId);
            if (category == null)
            {
                throw new ArgumentException($"Category:{categoryId} does not exists");
            }
            return category;
        }
       
    }
}
