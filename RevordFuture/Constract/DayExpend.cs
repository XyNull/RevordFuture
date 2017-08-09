using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevordFuture.Constract
{
    public class DayExpend
    {
        public DateTime Day;
        public List<ExpendProject> Projects;

        public DayExpend()
        {
            Projects = new List<ExpendProject>();
        }
    }
}
