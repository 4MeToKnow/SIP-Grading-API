﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIP_Grading_API.Models
{
    public class student
    {
        public int studid { get; set; }
        public string name { get; set; }
        public string dip { get; set; }
        public string matricno { get; set; }
        public string mschemeassigned { get; set; }
    }
}