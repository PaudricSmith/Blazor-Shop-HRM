using BlazorShopHRM.Shared.Domain;


namespace BlazorShopHRM.Api.Repositories.Interfaces
{
    public interface IPerformanceReviewRepository
    {
        IEnumerable<PerformanceReview> GetAllPerformanceReviews();
        PerformanceReview GetPerformanceReviewById(int performanceReviewId);
        IEnumerable<PerformanceReview> GetPerformanceReviewsByEmployeeId(int employeeId);
        PerformanceReview AddPerformanceReview(PerformanceReview performanceReview);
        PerformanceReview UpdatePerformanceReview(PerformanceReview performanceReview);
        void DeletePerformanceReview(int performanceReviewId);
    }
}
