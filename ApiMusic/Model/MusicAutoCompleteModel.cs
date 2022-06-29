using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMusic.Model
{
    public class MusicAutoCompleteModel
    {
        public List<Hints> hints { get; set; }
    }
        public class Hints
        {
            public string Term { get; set; }
        }
    
}
