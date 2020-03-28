using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Students.View
{
    public static class TextboxExtensions
    {
        /// <exception cref="Exception">
        ///               <paramref name="propertyName" /> is neither a valid property of a control nor an empty string (""). </exception>
        public static void Bind(this TextBox textBox,object dataSource,string propertyName)
        {
            var binding =
                new Binding("Text", dataSource, propertyName) {ControlUpdateMode = ControlUpdateMode.OnPropertyChanged};
            textBox.DataBindings.Clear();
            textBox.DataBindings.Add(binding);
        }
    }
}
