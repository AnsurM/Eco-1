﻿using Newtonsoft.Json;

namespace Host.DataModel
{
    public class DailyActivityPerformDetailDto
    {
        public bool IsPerform { get; set; }
        public string Perform { get; set; }
        public string ActivityName { get; set; }
    }
}
