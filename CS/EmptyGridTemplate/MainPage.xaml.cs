using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace EmptyGridTemplate {
    public partial class MainPage : UserControl {

        public static readonly DependencyProperty IsGridEmptyProperty = DependencyProperty.RegisterAttached("IsGridEmpty", typeof(bool), typeof(MainPage), new PropertyMetadata(false));

        public static bool GetIsGridEmpty(DependencyObject dependencyObject) {
            return (bool)dependencyObject.GetValue(IsGridEmptyProperty);
        }
        public static void SetIsGridEmpty(DependencyObject dependencyObject, bool value) {
            dependencyObject.SetValue(IsGridEmptyProperty, value);
        }

        ObservableCollection<TestData> data;

        public MainPage() {
            InitializeComponent();

            data = new ObservableCollection<TestData>();
            for (int i = 0; i < 5; i++)
                data.Add(new TestData() {
                    Text = "Row" + i, Number = i, Group = i % 5
                });

           grid.DataSource = data;
        }

        void grid_LayoutUpdated(object sender, EventArgs e) {
            MainPage.SetIsGridEmpty(grid, grid.VisibleRowCount == 0);
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            data.Clear();
        }
    }

    public class TestData {
        public string Text {
            get;
            set;
        }
        public int Number {
            get;
            set;
        }
        public int Group {
            get;
            set;
        }
    }
}
