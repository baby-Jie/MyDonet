using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfTest.Models;

namespace WpfTest.Views
{
    /// <summary>
    /// Interaction logic for ListBoxPaging.xaml
    /// </summary>
    public partial class ListBoxPaging : Window
    {
        private List<Student> _students = new List<Student>();
        public ListBoxPaging()
        {
            InitializeComponent();

            #region student data

            _students.Add(new Student() { Name = "smx", Id = 1, Score = 88 });
            _students.Add(new Student() { Name = "xyj", Id = 2, Score = 99 });
            _students.Add(new Student() { Name = "xpz", Id = 3, Score = 66 });
            _students.Add(new Student() { Name = "xth", Id = 4, Score = 55 });
            _students.Add(new Student() { Name = "wx", Id = 5, Score = 77 });
            _students.Add(new Student() { Name = "wg", Id = 6, Score = 44 });
            _students.Add(new Student() { Name = "hhr", Id = 7, Score = 33 });
            _students.Add(new Student() { Name = "smx", Id = 8, Score = 88 });
            _students.Add(new Student() { Name = "xyj", Id = 9, Score = 99 });
            _students.Add(new Student() { Name = "xpz", Id = 10, Score = 66 });
            _students.Add(new Student() { Name = "xth", Id = 11, Score = 55 });
            _students.Add(new Student() { Name = "wx", Id = 12, Score = 77 });
            _students.Add(new Student() { Name = "wg", Id = 13, Score = 44 });
            _students.Add(new Student() { Name = "hhr", Id = 14, Score = 33 });
            _students.Add(new Student() { Name = "hhr", Id = 15, Score = 33 });
            _students.Add(new Student() { Name = "hhr", Id = 16, Score = 33 });
            _students.Add(new Student() { Name = "hhr", Id = 17, Score = 33 });
            _students.Add(new Student() { Name = "hhr", Id = 18, Score = 33 });
            _students.Add(new Student() { Name = "hhr", Id = 19, Score = 33 });

            #endregion

            StuListbox.ItemsSource = _students;
        }

        private void PrePageButton_Click(object sender, RoutedEventArgs e)
        {
            PrePage();
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            NextPage();
        }

        private void NextPage()
        {
            ScrollViewer scrollViewer = StuListbox.Template.FindName("PART_ScrollViewer", StuListbox) as ScrollViewer;
            if (scrollViewer == null) return;

            //ScrollBar scrollbar = scrollViewer.Template.FindName("PART_HorizontalScrollBar", scrollViewer) as ScrollBar;
            //if (scrollbar == null) return;

            //var command = ScrollBar.PageRightCommand;
            //command.Execute(null, scrollbar);

            scrollViewer.PageRight();
        }

        private void PrePage()
        {
            ScrollViewer scrollViewer = StuListbox.Template.FindName("PART_ScrollViewer", StuListbox) as ScrollViewer;
            if (scrollViewer == null) return;
            //ScrollBar scrollbar = scrollViewer.Template.FindName("PART_HorizontalScrollBar", scrollViewer) as ScrollBar;
            //if (scrollbar == null) return;

            //var command = ScrollBar.PageLeftCommand;
            //command.Execute(null, scrollbar);


             scrollViewer.PageLeft();
        }

        private void ShowHoOffsetButton_Click(object sender, RoutedEventArgs e)
        {
            ScrollViewer scrollViewer = StuListbox.Template.FindName("PART_ScrollViewer", StuListbox) as ScrollViewer;
            MessageBox.Show(scrollViewer.HorizontalOffset.ToString());
        }

        private void GoOffsetButton_Click(object sender, RoutedEventArgs e)
        {
            int offset = int.Parse(HoOffsetTextBox.Text.Trim());
            ScrollViewer scrollViewer = StuListbox.Template.FindName("PART_ScrollViewer", StuListbox) as ScrollViewer;
            scrollViewer.ScrollToHorizontalOffset(offset);
        }
    }

   


}




