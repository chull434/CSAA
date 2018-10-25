using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Client.Views
{
    /// <summary>
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : Window
    {
        public HomeScreen()
        {
            
        
            InitializeComponent();
            List<Project> projectlist = new List<Project>();

            //ToDo populate with user projects from database

            projectlist.Add(new Project() { Title = "Project A", Completion = 20 });
            projectlist.Add(new Project() { Title = "Project B", Completion = 80 });
            projectlist.Add(new Project() { Title = "Project C", Completion = 55 });

            lb_ProjectList.ItemsSource = projectlist;

            List<Task> assignedTasks = new List<Task>();

            assignedTasks.Add(new Task() { Title = "Task 1", Project = "Project A" });
            assignedTasks.Add(new Task() { Title = "Task 2", Project = "Project A" });
            assignedTasks.Add(new Task() { Title = "Task 3", Project = "Project A" });

            lb_AssignedTasks.ItemsSource = assignedTasks;
        }
    }

    public class Project
    {
        public string Title { get; set; }
        public int Completion { get; set; }
    }

    
    public class Task
    {
        public string Title { get; set; }
        public string Project { get; set; }
    }
}
