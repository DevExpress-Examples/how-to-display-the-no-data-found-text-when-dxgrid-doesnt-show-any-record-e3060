<!-- default file list -->
*Files to look at*:

* [MainPage.xaml](./CS/SLGridExample/MainPage.xaml) (VB: [MainPage.xaml](./VB/SLGridExample/MainPage.xaml))
* [MainPage.xaml.cs](./CS/SLGridExample/MainPage.xaml.cs) (VB: [MainPage.xaml.vb](./VB/SLGridExample/MainPage.xaml.vb))
* [VisibleRowsCountHelper.cs](./CS/SLGridExample/VisibleRowsCountHelper.cs) (VB: [VisibleRowsCountHelper.vb](./VB/SLGridExample/VisibleRowsCountHelper.vb))
<!-- default file list end -->
# How to display the "No data found" text when DXGrid doesn't show any record


<p>This sample shows how to display a custom text line within the grid's view if it does not display any rows.</p>


<h3>Description</h3>

<p>It is necessary to create the custom Boolean HasVisibleRows attached property and update its value when the grid&#39;s VisibleRowCount or ItemsSource properties changed. </p><p>Then, override the TableView&#39;s scroll viewer template and place the text block within it. It&#39;s Visibility property should be bound to the view&#39;s HasVisibleRows attached property:</p><code lang='xml'>&lt;TextBlock Name="EmptyGridMessage" Grid.Row="3" HorizontalAlignment="Center" VerticalAlignment="Center"
            Foreground="Gray" &lt;newline/&gt;
            Text="{Binding Path=(dxg:GridControl.CurrentView).(local:VisibleRowsCountHelper.EmptyGridMessage), RelativeSource={RelativeSource TemplatedParent}}"
            Visibility="{Binding Path=(dxg:GridControl.CurrentView).(local:VisibleRowsCountHelper.HasVisibleRows), RelativeSource={RelativeSource TemplatedParent}, Converter={StaticResource BooleanToVisibilityConverterInverted}}"
            /&gt;
</code><p>Note that it is also necessary to override all dependent resources too since there are no dynamic resources in Silverlight.</p>

<br/>


