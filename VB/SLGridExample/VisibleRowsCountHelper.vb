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
Imports System.Windows
Imports DevExpress.Data.Browsing
Imports DevExpress.Xpf.Grid

Namespace SLGridExample
	Public Class VisibleRowsCountHelper

		Public Shared ReadOnly HasVisibleRowsProperty As DependencyProperty = DependencyProperty.RegisterAttached("HasVisibleRows", GetType(Boolean), GetType(VisibleRowsCountHelper), New PropertyMetadata(False))

		Public Shared Function GetHasVisibleRows(ByVal obj As DependencyObject) As Boolean
			Return CBool(obj.GetValue(HasVisibleRowsProperty))
		End Function

		Public Shared Sub SetHasVisibleRows(ByVal obj As DependencyObject, ByVal value As Boolean)
			obj.SetValue(HasVisibleRowsProperty, value)
		End Sub

		Public Shared ReadOnly EmptyGridMessageProperty As DependencyProperty = DependencyProperty.RegisterAttached("EmptyGridMessage", GetType(String), GetType(VisibleRowsCountHelper), New PropertyMetadata(""))

		Public Shared Function GetEmptyGridMessage(ByVal obj As DependencyObject) As String
			Return CStr(obj.GetValue(EmptyGridMessageProperty))
		End Function

		Public Shared Sub SetEmptyGridMessage(ByVal obj As DependencyObject, ByVal value As String)
			obj.SetValue(EmptyGridMessageProperty, value)
		End Sub
	End Class
End Namespace
