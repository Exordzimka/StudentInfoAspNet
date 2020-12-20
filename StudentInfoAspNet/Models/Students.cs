using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentInfoAspNet.Models
{
    public partial class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public int GroupId { get; set; }
        
        public double AverageScore { get; set; }

        [Required]
        public virtual Groups Group { get; set; }
    }
}
