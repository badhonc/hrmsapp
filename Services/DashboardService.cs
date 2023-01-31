using DAL;
using HRMSApp.Interfaces;
using HRMSApp.Models;
using System.Data;
using System.Data.Common;

namespace HRMSApp.Services
{
    public class DashboardService : IDashboardService
    {
        DbConnection dbConnection = new DbConnection();
        public async Task<IEnumerable<Menu>> GetAllMenuItem()
        {
            List<Menu> menuList = new List<Menu>();
            DataTable dt = dbConnection.GetDataTableWithoutParameter("select * from menus");
            foreach (DataRow dr in dt.Rows)
            {
                menuList.Add(new Menu(){
                    Id = Convert.ToInt64(dr["id"]),
                    MenuId = Convert.ToInt32(dr["menu_id"]),
                    ParentId = Convert.ToInt32(dr["parent_menu_id"]),
                    DisplayName = dr["display_name"].ToString(),
                    AreaName = dr["area_name"].ToString(),
                    ControllerName = dr["controller_name"].ToString(),
                    ActionName = dr["action_name"].ToString(),
                    Icon = dr["icon_name"].ToString()
                });
            }
            dt.Rows.Clear();
            return await Task.Run(() => menuList.ToList());
        }
    }
}
