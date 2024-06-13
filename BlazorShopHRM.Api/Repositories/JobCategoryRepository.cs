using BlazorShopHRM.Api.Data;
using BlazorShopHRM.Api.Repositories.Interfaces;
using BlazorShopHRM.Shared.Domain;

namespace BlazorShopHRM.Api.Repositories
{
    public class JobCategoryRepository: IJobCategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public JobCategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<JobCategory> GetAllJobCategories()
        {
            return _appDbContext.JobCategories;
        }

        public JobCategory GetJobCategoryById(int jobCategoryId)
        {
            return _appDbContext.JobCategories.FirstOrDefault(c => c.JobCategoryId == jobCategoryId);
        }
    }
}
