﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Viikko_1_tehtävä.Models
{
    public partial class Topic
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? TimeToMaster { get; set; }
        public int? TimeSpent { get; set; }
        public string Source { get; set; }
        public DateTime? StartLearningDate { get; set; }
        public bool? InProgress { get; set; }
    }
}
