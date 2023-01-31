using System.ComponentModel.DataAnnotations.Schema;

namespace HRMSApp.Models
{
    public class Menu
    {
        public long Id { get; set; }
        public long MenuId { get; set; }
        public long ParentId { get; set; }
        public string? DisplayName { get; set; }
        public string? AreaName { get; set; }
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
        public string? Icon { get; set; }

        [NotMapped]
        public bool HasChild { get; set; } = false;
    }
}
