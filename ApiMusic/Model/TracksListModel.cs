﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMusic.Model
{
    public class TracksListModel
    {
        public Countries[] countries { get; set; }
        public class Countries
        {
            public string name { get; set; }
            public string listid { get; set; }
            public Cities[] cities { get; set; }
        }
        public class Cities
        {
            public string name { get; set; }
            public string listid { get; set; }
        }
    }
}
