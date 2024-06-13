using BlazorShopHRM.Shared.Domain;


namespace BlazorShopHRM.App.Services.Interfaces
{
    public interface ILeaveDataService
    {
        Task<IEnumerable<Leave>> GetAllLeaves();
        Task<Leave> GetLeaveDetails(int leaveId);
        Task<IEnumerable<Leave>> GetLeavesByEmployeeId(int employeeId);
        Task<Leave> AddLeave(Leave leave);
        Task UpdateLeave(Leave leave);
        Task DeleteLeave(int leaveId);
    }
}
