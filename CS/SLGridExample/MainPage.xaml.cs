using System;
using System.Windows.Controls;
using System.Windows;

namespace SLGridExample {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
        }

        private void grid_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            if (e.PropertyName == "VisibleRowCount") {
                grid.View.SetValue(VisibleRowsCountHelper.HasVisibleRowsProperty, grid.VisibleRowCount != 0);
            }
        }

        private void grid_ItemsSourceChanged(object sender, DevExpress.Xpf.Grid.ItemsSourceChangedEventArgs e) {
            grid.View.SetValue(VisibleRowsCountHelper.HasVisibleRowsProperty, e.NewDataSource != null);
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            ((PersonsViewModel)grid.DataContext).RemovePerson(grid.View.FocusedRow);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            grid.ItemsSource = null;
        }


    }
}
