using BlazorShopHRM.Shared.Domain;


namespace BlazorShopHRM.App.Services.Interfaces
{
    public interface IPayrollDataService
    {
        Task<IEnumerable<Payroll>> GetAllPayrolls();
        Task<Payroll> GetPayrollById(int payrollId);
        Task<IEnumerable<Payroll>> GetPayrollsByEmployeeId(int employeeId);
        Task<Payroll> AddPayroll(Payroll payroll);
        Task UpdatePayroll(int payrollId, Payroll payroll);
        Task DeletePayroll(int payrollId);
    }
}
