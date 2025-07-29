using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechtrollTask.Application.DTOs
{
    public class ComponentDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public List<SubcomponentDto> Subcomponents { get; set; }
    }
}
