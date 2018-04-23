' Developer Express Code Central Example:
' How to display a line when the DXGrid doesn't include any record
' 
' This sample shows how to display a line within the grid's view if it does not
' contain any rows.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E3060


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
			grid.View.SetValue(VisibleRowsCountHelper.HasVisibleRowsProperty, e.NewItemsSource IsNot Nothing)
		End Sub

		Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            CType(grid.DataContext, PersonsViewModel).RemovePerson(grid.SelectedItem)
		End Sub

		Private Sub Button_Click_1(ByVal sender As Object, ByVal e As RoutedEventArgs)
			grid.ItemsSource = Nothing
		End Sub


	End Class
End Namespace
