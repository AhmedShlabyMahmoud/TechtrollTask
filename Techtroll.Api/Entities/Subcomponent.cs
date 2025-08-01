﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechtrollTask.Domain.Entities
{
    public class Subcomponent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public string CustomNotes { get; set; }
        public int Count { get; set; }

        public double DetailLength { get; set; }
        public double DetailWidth { get; set; }
        public double DetailThickness { get; set; }

        public double CuttingLength { get; set; }
        public double CuttingWidth { get; set; }
        public double CuttingThickness { get; set; }

        public double FinalLength { get; set; }
        public double FinalWidth { get; set; }
        public double FinalThickness { get; set; }

        public string VeneerInner { get; set; }
        public string VeneerOuter { get; set; }

        public int ComponentId { get; set; }
        public Component Component { get; set; }
    }

}
