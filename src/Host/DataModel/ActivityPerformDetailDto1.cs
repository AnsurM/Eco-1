﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Host.DataModel
{
    public class ActivityPerformDetailDto1
    {
        public int ActivityId { get; set; }
        [Required]
        [StringLength(250)]
        public string ActivityName { get; set; }
        public int ActivityTypeId { get; set; }
        public string Type { get; set; }
        public int StationActivityId { get; set; }
        public List<string> Observation { get; set; }
        public List<string> Images { get; set; }
        public bool IsPerform { get; set; }
        public string Perform { get; set; }
    }
}
