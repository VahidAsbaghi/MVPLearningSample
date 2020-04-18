using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Model.Model;
using Students.Presenter.ViewModel;

namespace Students.Presenter
{
    public interface IViewMain:IView<IViewMainPresenter>
    {
        List<StudentViewModel> Students { get; set; }
        IEnumerable<Course> Courses { get; set; }
    }
}
