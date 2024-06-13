using BlazorShopHRM.Api.Data;
using BlazorShopHRM.Api.Repositories.Interfaces;
using BlazorShopHRM.Shared.Domain;


namespace BlazorShopHRM.Api.Repositories
{
    public class PerformanceReviewRepository : IPerformanceReviewRepository
    {
        private readonly AppDbContext _appDbContext;


        public PerformanceReviewRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<PerformanceReview> GetAllPerformanceReviews()
        {
            return _appDbContext.PerformanceReviews;
        }

        public PerformanceReview GetPerformanceReviewById(int performanceReviewId)
        {
            return _appDbContext.PerformanceReviews.FirstOrDefault(pr => pr.PerformanceReviewId == performanceReviewId);
        }

        public IEnumerable<PerformanceReview> GetPerformanceReviewsByEmployeeId(int employeeId)
        {
            return _appDbContext.PerformanceReviews.Where(pr => pr.EmployeeId == employeeId).ToList();
        }

        public PerformanceReview AddPerformanceReview(PerformanceReview performanceReview)
        {
            var addedEntity = _appDbContext.PerformanceReviews.Add(performanceReview);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public PerformanceReview UpdatePerformanceReview(PerformanceReview performanceReview)
        {
            var foundPerformanceReview = _appDbContext.PerformanceReviews.FirstOrDefault(pr => pr.PerformanceReviewId == performanceReview.PerformanceReviewId);

            if (foundPerformanceReview != null)
            {
                foundPerformanceReview.ReviewDate = performanceReview.ReviewDate;
                foundPerformanceReview.Comments = performanceReview.Comments;
                foundPerformanceReview.Score = performanceReview.Score;

                _appDbContext.SaveChanges();

                return foundPerformanceReview;
            }

            return null;
        }

        public void DeletePerformanceReview(int performanceReviewId)
        {
            var foundPerformanceReview = _appDbContext.PerformanceReviews.FirstOrDefault(pr => pr.PerformanceReviewId == performanceReviewId);
            if (foundPerformanceReview == null) return;

            _appDbContext.PerformanceReviews.Remove(foundPerformanceReview);
            _appDbContext.SaveChanges();
        }
    }
}
