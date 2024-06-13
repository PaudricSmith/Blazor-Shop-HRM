using BlazorShopHRM.Api.Data;
using BlazorShopHRM.Api.Repositories.Interfaces;
using BlazorShopHRM.Shared.Domain;
using Microsoft.EntityFrameworkCore;


namespace BlazorShopHRM.Api.Repositories
{
    public class PayrollRepository : IPayrollRepository
    {
        private readonly AppDbContext _appDbContext;


        public PayrollRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Payroll> GetAllPayrolls()
        {
            return _appDbContext.Payrolls.Include(p => p.Employee)
                .ThenInclude(e => e.JobCategory)
                .OrderBy(p => p.Month)
                .ToList();
        }

        public Payroll GetPayrollById(int payrollId)
        {
            return _appDbContext.Payrolls
                .Include(p => p.Employee)
                .ThenInclude(e => e.JobCategory)
                .FirstOrDefault(p => p.PayrollId == payrollId);
        }

        public IEnumerable<Payroll> GetPayrollsByEmployeeId(int employeeId)
        {
            return _appDbContext.Payrolls.Where(p => p.EmployeeId == employeeId).ToList();
        }

        public Payroll AddPayroll(Payroll payroll)
        {
            var addedEntity = _appDbContext.Payrolls.Add(payroll);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public Payroll UpdatePayroll(Payroll payroll)
        {
            var foundPayroll = _appDbContext.Payrolls.FirstOrDefault(p => p.PayrollId == payroll.PayrollId);

            if (foundPayroll != null)
            {
                foundPayroll.Month = payroll.Month;
                foundPayroll.Amount = payroll.Amount;

                try
                {
                    _appDbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    // Log the error
                    throw new ApplicationException("Error updating payroll in the database", ex);
                }

                return foundPayroll;
            }

            return null;
        }

        public void DeletePayroll(int payrollId)
        {
            var foundPayroll = _appDbContext.Payrolls.FirstOrDefault(p => p.PayrollId == payrollId);
            if (foundPayroll == null) return;

            _appDbContext.Payrolls.Remove(foundPayroll);
            _appDbContext.SaveChanges();
        }
    }
}
