using BlazorShopHRM.Shared.Domain;


namespace BlazorShopHRM.App.Services.Interfaces
{
    public interface IPerformanceReviewDataService
    {
        Task<IEnumerable<PerformanceReview>> GetAllPerformanceReviews();
        Task<PerformanceReview> GetPerformanceReviewDetails(int performanceReviewId);
        Task<IEnumerable<PerformanceReview>> GetPerformanceReviewsByEmployeeId(int employeeId);
        Task<PerformanceReview> AddPerformanceReview(PerformanceReview performanceReview);
        Task UpdatePerformanceReview(PerformanceReview performanceReview);
        Task DeletePerformanceReview(int performanceReviewId);
    }
}
