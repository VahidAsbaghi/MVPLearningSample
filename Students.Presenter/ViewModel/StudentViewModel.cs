using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Presenter.ViewModel
{
    public class StudentViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName => Name + " " + LastName;
        public string StudentNumber { get; set; }
        public string Mobile { get; set; }
    }
}
