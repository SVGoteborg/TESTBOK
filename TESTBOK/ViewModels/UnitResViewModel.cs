﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TESTBOK.Models;

namespace TESTBOK.ViewModels
{
    public class UnitResViewModel
    {

        public int Id { get; set; }
        public string UnitName { get; set; }
        public string ResName { get; set; }
        public Unit Unit { get; set; }
        public IEnumerable<Unit> UnitsList { get; set; }
        public Resource Resource { get; set; }

        
    }
}
