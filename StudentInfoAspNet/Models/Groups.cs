using System;
using System.Collections.Generic;

namespace StudentInfoAspNet.Models
{
    public partial class Groups
    {
        public Groups()
        {
            Students = new HashSet<Students>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string CuratorFamily { get; set; }
        public string TitleDirection { get; set; }
        
        public double AverageScore { get; set; }

        public virtual ICollection<Students> Students { get; set; }
    }
}
