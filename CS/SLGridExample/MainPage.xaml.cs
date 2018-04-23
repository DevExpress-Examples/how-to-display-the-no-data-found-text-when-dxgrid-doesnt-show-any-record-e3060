// Developer Express Code Central Example:
// How to display a line when the DXGrid doesn't include any record
// 
// This sample shows how to display a line within the grid's view if it does not
// contain any rows.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E3060

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
            grid.View.SetValue(VisibleRowsCountHelper.HasVisibleRowsProperty, e.NewItemsSource != null);
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            ((PersonsViewModel)grid.DataContext).RemovePerson(grid.View.FocusedRow);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            grid.ItemsSource = null;
        }


    }
}
