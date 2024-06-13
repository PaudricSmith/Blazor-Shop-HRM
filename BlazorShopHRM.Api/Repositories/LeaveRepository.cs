using BlazorShopHRM.Api.Data;
using BlazorShopHRM.Api.Repositories.Interfaces;
using BlazorShopHRM.Shared.Domain;
using Microsoft.EntityFrameworkCore;


namespace BlazorShopHRM.Api.Repositories
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly AppDbContext _appDbContext;


        public LeaveRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Leave> GetAllLeaves()
        {
            return _appDbContext.Leaves.Include(l => l.Employee);
        }

        public Leave GetLeaveById(int leaveId)
        {
            return _appDbContext.Leaves.FirstOrDefault(l => l.LeaveId == leaveId);
        }

        public IEnumerable<Leave> GetLeavesByEmployeeId(int employeeId)
        {
            return _appDbContext.Leaves.Where(l => l.EmployeeId == employeeId).ToList();
        }

        public Leave AddLeave(Leave leave)
        {
            var addedEntity = _appDbContext.Leaves.Add(leave);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public Leave UpdateLeave(Leave leave)
        {
            var foundLeave = _appDbContext.Leaves.FirstOrDefault(l => l.LeaveId == leave.LeaveId);

            if (foundLeave != null)
            {
                foundLeave.StartDate = leave.StartDate;
                foundLeave.EndDate = leave.EndDate;
                foundLeave.LeaveType = leave.LeaveType;
                foundLeave.Reason = leave.Reason;

                _appDbContext.SaveChanges();

                return foundLeave;
            }

            return null;
        }

        public void DeleteLeave(int leaveId)
        {
            var foundLeave = _appDbContext.Leaves.FirstOrDefault(l => l.LeaveId == leaveId);
            if (foundLeave == null) return;

            _appDbContext.Leaves.Remove(foundLeave);
            _appDbContext.SaveChanges();
        }
    }
}
