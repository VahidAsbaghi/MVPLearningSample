using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Model.Model;
using Students.Presenter.ViewModel;

namespace Students.Presenter
{
    public interface IViewMainPresenter:IPresenter<IViewMain>
    {
        bool AddStudent(StudentViewModel student);
        void AddScore(StudentScoreViewModel studentScore);
    }
}
