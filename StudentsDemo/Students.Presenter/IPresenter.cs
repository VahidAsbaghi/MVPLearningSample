using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Presenter
{
    public interface IPresenter<TView>
    {
        TView View { get;}
        void Run();
    }
}
