using BlazorShopHRM.Shared.Domain;


namespace BlazorShopHRM.Api.Repositories.Interfaces
{
    public interface IJobCategoryRepository
    {
        IEnumerable<JobCategory> GetAllJobCategories();
        JobCategory GetJobCategoryById(int jobCategoryId);
    }
}
