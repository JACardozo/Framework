using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Project
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public int ItemsCount { get; set; }
        public int? Icon { get; set; }
        public int ItemType { get; set; }
        public long? ParentId { get; set; }
        public bool? Collapsed { get; set; }
        public int? ItemOrder { get; set; }
        public List<Project> Children { get; set; }
        public bool? IsProjectShared { get; set; }
        public string ProjectShareOwnerName { get; set; }
        public string ProjectShareOwnerEmail { get; set; }
        public bool IsShareApproved { get; set; }
        public bool IsOwnProject { get; set; }
    }
}
