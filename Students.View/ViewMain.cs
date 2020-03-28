using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Students.Model.Model;
using Students.Presenter;
using Students.Presenter.ViewModel;

namespace Students.View
{
    public partial class ViewMain : Form, IViewMain
    {
        public ViewMain()
        {
            InitializeComponent();

        }
        private readonly BindingSource _studentsBindingSource = new BindingSource();
        private readonly BindingSource _coursesBindingSource = new BindingSource();
        public IViewMainPresenter Presenter { get; set; }

        /// <exception cref="Exception">
        ///               <paramref name="propertyName" /> is neither a valid property of a control nor an empty string (""). </exception>
        public void Run()
        {
            NewStudentBinding();

            cmBoxCources.DataSource = _coursesBindingSource;
            cmBoxCources.DisplayMember = "Name";
            cmBoxCources.ValueMember = "Name";

            listBox1.DataSource = _studentsBindingSource;
            listBox1.DisplayMember = "FullName";
            listBox1.ValueMember = "Id";

            StudentScore = new StudentScoreViewModel();
            Binding studentCourseBinding = new Binding("Text", StudentScore, "Score") { ControlUpdateMode = ControlUpdateMode.OnPropertyChanged};
            txtScore.DataBindings.Add(studentCourseBinding);

            
            Binding courseBinding = new Binding("Text", StudentScore, "CourseName") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged };
            cmBoxCources.DataBindings.Add(courseBinding);

            Binding studentBinding = new Binding("SelectedValue", StudentScore, "StudentId") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged };
            listBox1.DataBindings.Add(studentBinding);

            Application.Run(this);
        }

        public IEnumerable<Course> Courses
        {
            get { return _coursesBindingSource.List.Cast<Course>(); }
            set { _coursesBindingSource.DataSource = value.ToList(); }
        }

        public IEnumerable<Student> Students
        {
            get { return _studentsBindingSource.List.Cast<Student>(); }
            set
            {
                _studentsBindingSource.DataSource = value.ToList();
            }
        }

        public StudentScoreViewModel StudentScore { get; set; }
        public Student Student { get; set; }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Presenter.AddStudent(Student);
            _studentsBindingSource.Add(Student);
            NewStudentBinding();
        }


        private void NewStudentBinding()
        {
            Student = new Student();
            txtName.Bind(Student, "Name");
            txtLastName.Bind(Student, "LastName");
            txtMobile.Bind(Student, "Mobile");
            txtStudentNumber.Bind(Student, "StudentNumber");
        }

        private void btnAddScore_Click(object sender, EventArgs e)
        {
            Presenter.AddScore(StudentScore);
        }
    }
}
