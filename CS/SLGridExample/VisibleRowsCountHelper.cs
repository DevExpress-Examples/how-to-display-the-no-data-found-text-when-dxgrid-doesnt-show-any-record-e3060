using System;
using System.Windows;
using DevExpress.Data.Browsing;
using DevExpress.Xpf.Grid;

namespace SLGridExample {
    public class VisibleRowsCountHelper {

        public static readonly DependencyProperty HasVisibleRowsProperty =
            DependencyProperty.RegisterAttached("HasVisibleRows", typeof(bool), typeof(VisibleRowsCountHelper), new PropertyMetadata(false));

        public static bool GetHasVisibleRows(DependencyObject obj) {
            return (bool)obj.GetValue(HasVisibleRowsProperty);
        }

        public static void SetHasVisibleRows(DependencyObject obj, bool value) {
            obj.SetValue(HasVisibleRowsProperty, value);
        }

        public static readonly DependencyProperty EmptyGridMessageProperty =
            DependencyProperty.RegisterAttached("EmptyGridMessage", typeof(string), typeof(VisibleRowsCountHelper), new PropertyMetadata(""));

        public static string GetEmptyGridMessage(DependencyObject obj) {
            return (string)obj.GetValue(EmptyGridMessageProperty);
        }

        public static void SetEmptyGridMessage(DependencyObject obj, string value) {
            obj.SetValue(EmptyGridMessageProperty, value);
        }
    }
}
