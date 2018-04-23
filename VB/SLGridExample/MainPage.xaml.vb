Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Controls
Imports System.Windows

Namespace SLGridExample
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub grid_PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs)
			If e.PropertyName = "VisibleRowCount" Then
				grid.View.SetValue(VisibleRowsCountHelper.HasVisibleRowsProperty, grid.VisibleRowCount <> 0)
			End If
		End Sub

		Private Sub grid_ItemsSourceChanged(ByVal sender As Object, ByVal e As DevExpress.Xpf.Grid.ItemsSourceChangedEventArgs)
			grid.View.SetValue(VisibleRowsCountHelper.HasVisibleRowsProperty, e.NewDataSource IsNot Nothing)
		End Sub

		Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			CType(grid.DataContext, PersonsViewModel).RemovePerson(grid.View.FocusedRow)
		End Sub

		Private Sub Button_Click_1(ByVal sender As Object, ByVal e As RoutedEventArgs)
			grid.ItemsSource = Nothing
		End Sub


	End Class
End Namespace
