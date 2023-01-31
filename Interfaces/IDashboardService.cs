using HRMSApp.Models;

namespace HRMSApp.Interfaces
{
    public interface IDashboardService
    {
        Task<IEnumerable<Menu>> GetAllMenuItem();
    }
}
