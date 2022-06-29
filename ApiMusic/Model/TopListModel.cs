﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMusic.Model
{
    public class TopListModel
    {
        public /*Track[]*/List<__track> tracks { get; set; }

    }
    public class __track
    {
        public string key { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public __share share { get; set; }

    }

    public class __share
    {
        public string subject { get; set; }

        public string href { get; set; }
        public string image { get; set; }

        public string html { get; set; }

    }




}
