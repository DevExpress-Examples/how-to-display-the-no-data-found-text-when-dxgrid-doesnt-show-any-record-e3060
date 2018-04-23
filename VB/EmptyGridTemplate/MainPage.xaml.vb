Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Collections.ObjectModel

Namespace EmptyGridTemplate
	Partial Public Class MainPage
		Inherits UserControl

		Public Shared ReadOnly IsGridEmptyProperty As DependencyProperty = DependencyProperty.RegisterAttached("IsGridEmpty", GetType(Boolean), GetType(MainPage), New PropertyMetadata(False))

		Public Shared Function GetIsGridEmpty(ByVal dependencyObject As DependencyObject) As Boolean
			Return CBool(dependencyObject.GetValue(IsGridEmptyProperty))
		End Function
		Public Shared Sub SetIsGridEmpty(ByVal dependencyObject As DependencyObject, ByVal value As Boolean)
			dependencyObject.SetValue(IsGridEmptyProperty, value)
		End Sub

		Private data As ObservableCollection(Of TestData)

		Public Sub New()
			InitializeComponent()

			data = New ObservableCollection(Of TestData)()
			For i As Integer = 0 To 4
				data.Add(New TestData() With {.Text = "Row" & i, .Number = i, .Group = i Mod 5})
			Next i

		   grid.DataSource = data
		End Sub

		Private Sub grid_LayoutUpdated(ByVal sender As Object, ByVal e As EventArgs)
			MainPage.SetIsGridEmpty(grid, grid.VisibleRowCount = 0)
		End Sub

		Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			data.Clear()
		End Sub
	End Class

	Public Class TestData
		Private privateText As String
		Public Property Text() As String
			Get
				Return privateText
			End Get
			Set(ByVal value As String)
				privateText = value
			End Set
		End Property
		Private privateNumber As Integer
		Public Property Number() As Integer
			Get
				Return privateNumber
			End Get
			Set(ByVal value As Integer)
				privateNumber = value
			End Set
		End Property
		Private privateGroup As Integer
		Public Property Group() As Integer
			Get
				Return privateGroup
			End Get
			Set(ByVal value As Integer)
				privateGroup = value
			End Set
		End Property
	End Class
End Namespace
