using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Model.Model;

namespace Students.Presenter
{
    public interface IViewMain:IView<IViewMainPresenter>
    {
        IEnumerable<Student> Students { get; set; }
        IEnumerable<Course> Courses { get; set; }
    }
}
