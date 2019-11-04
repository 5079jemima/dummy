using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace fGrid11 {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            vm = new MyViewModel();
            DataContext = vm;

        }
        MyViewModel vm;



        private void Button_Click_1(object sender, RoutedEventArgs e) {
            gridControl1.SelectAll();
        }


    }

    public class MyViewModel {
        public MyViewModel() {
            CreateList();
        }
        public ObservableCollection<Person> ListPerson { get; set; }
        //   public ObservableCollection<SomeClass> ListSomeClass { get; set; }
        void CreateList() {
            ListPerson = new ObservableCollection<Person>();
            for (int i = 0; i < 10; i++) {
                Person p = new Person(i);
                ListPerson.Add(p);
            }

            //ListSomeClass = new ObservableCollection<SomeClass>();
            //for (int i = 0; i < 200; i += 10)
            //    ListSomeClass.Add(new SomeClass(i));
        }
    }

    public class Person {
        public Person(int i) {
            FirstName = "FirstName" + i;
            LastName = "LastName" + i;
            Age = i * 10;
            Group = i % 2 == 0;
            //SomeClasses = new ObservableCollection<SomeClass>();
            //for (int j = 0; j < 5; j++) {
            //    SomeClasses.Add(new SomeClass(j));
            //}
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool Group { get; set; }
        // public ObservableCollection<SomeClass> SomeClasses { get; set; }
    }

    public class SomeClass {
        public SomeClass(int j) {
            Id = j;
            Name = "Name" + j.ToString();
        }
        public string Name { get; set; }
        public int Id { get; set; }
    }

    public class custConverter : MarkupExtension, IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            EditGridCellData cd = value as EditGridCellData;
            //Debugger.Break();
            Debug.Print(value.ToString());
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return value;
        }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }
}
