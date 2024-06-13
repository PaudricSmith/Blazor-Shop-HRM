using BlazorShopHRM.Shared.Domain;


namespace BlazorShopHRM.Api.Repositories.Interfaces
{
    public interface ILeaveRepository
    {
        IEnumerable<Leave> GetAllLeaves();
        Leave GetLeaveById(int leaveId);
        IEnumerable<Leave> GetLeavesByEmployeeId(int employeeId);
        Leave AddLeave(Leave leave);
        Leave UpdateLeave(Leave leave);
        void DeleteLeave(int leaveId);
    }
}
