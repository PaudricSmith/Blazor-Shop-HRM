using BlazorShopHRM.Shared.Domain;


namespace BlazorShopHRM.App.Services.Interfaces
{
    public interface IJobCategoryDataService
    {
        Task<IEnumerable<JobCategory>> GetAllJobCategories();
        Task<JobCategory> GetJobCategoryById(int jobCategoryId);
    }
}