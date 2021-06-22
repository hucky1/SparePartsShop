using SparePartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsShop.Services.Data
{
    public class ReviewsRepository
    {
        private AppDBContext _context;
        public ReviewsRepository(AppDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Reviews> GetReviews()
        {
            var items = _context.Reviews;
            return items;
        }
        public void Delete(int id)
        {
            _context.Reviews.Remove(_context.Reviews.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
        }
        public void Add (Reviews reviews)
        {
            _context.Reviews.Add(reviews);
            _context.SaveChanges();
        }

    }
}
