using BlazorShopHRM.Shared.Domain;


namespace BlazorShopHRM.Api.Repositories.Interfaces
{
    public interface IPayrollRepository
    {
        IEnumerable<Payroll> GetAllPayrolls();
        Payroll GetPayrollById(int payrollId);
        IEnumerable<Payroll> GetPayrollsByEmployeeId(int employeeId);
        Payroll AddPayroll(Payroll payroll);
        Payroll UpdatePayroll(Payroll payroll);
        void DeletePayroll(int payrollId);
    }
}
