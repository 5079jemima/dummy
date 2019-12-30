using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using DevExpress.Data;

namespace DXGridSample {
    public partial class MainWindow: Window {
        ObservableCollection<Person> Persons;
        public MainWindow() {
            InitializeComponent();
            Persons = new ObservableCollection<Person>();
            for(int i = 0; i < 100; i++)
                Persons.Add(new Person { Id = i, Name = "Name" + i, Bool = i % 2 == 0 });
            grid.ItemsSource = Persons;
        }
    }

    public class ViewModel {
        public void CustomSummary() {
            Debugger.Break();
        }
    }
    public class Person {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Bool { get; set; }
    }
    public class Conv: MarkupExtension, IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }
}