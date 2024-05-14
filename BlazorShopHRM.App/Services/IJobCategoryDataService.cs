using BlazorShopHRM.Shared.Domain;

public interface IJobCategoryDataService
{
    Task<IEnumerable<JobCategory>> GetAllJobCategories();
    Task<JobCategory> GetJobCategoryById(int jobCategoryId);
}
