using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class User
    {
        public string ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string TimeZone { get; set; }
        public bool IsProUser { get; set; }
        public int DefaultProjectId { get; set; }
        public bool AddItemMoreExpanded { get; set; }
        public bool EditDueDateMoreExpanded { get; set; }
        public int ListSortType { get; set; }
        public int FirstDayOfWeek { get; set; }
        public double NewTaskDueDate { get; set; }
        public string TimeZoneId { get; set; }
    }
}
