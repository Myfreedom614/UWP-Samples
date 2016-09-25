' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

Imports WinRTXamlToolkit.Controls.DataVisualization.Charting
''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddHandler Me.Loaded, AddressOf MainPage_Loaded
    End Sub

    Private Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs)
        LoadChartContents()
    End Sub

    Private Sub LoadChartContents()
        Dim rand As New Random()
        Dim financialStuffList As New List(Of FinancialStuff)()
        financialStuffList.Add(New FinancialStuff() With {
                               .Name = "MSFT",
                               .Amount = rand.[Next](0, 200)
                               })
        financialStuffList.Add(New FinancialStuff() With {
                               .Name = "AAPL",
                               .Amount = rand.[Next](0, 200)
                               })
        financialStuffList.Add(New FinancialStuff() With {
                               .Name = "GOOG",
                               .Amount = rand.[Next](0, 200)
                               })
        financialStuffList.Add(New FinancialStuff() With {
                               .Name = "BBRY",
                               .Amount = rand.[Next](0, 200)
                               })
        TryCast(PieChart.Series(0), PieSeries).ItemsSource = financialStuffList
        TryCast(ColumnChart.Series(0), ColumnSeries).ItemsSource = financialStuffList
        TryCast(LineChart.Series(0), LineSeries).ItemsSource = financialStuffList
        TryCast(BarChart.Series(0), BarSeries).ItemsSource = financialStuffList
        TryCast(BubbleChart.Series(0), BubbleSeries).ItemsSource = financialStuffList
    End Sub

    Private Sub ButtonRefresh_Click(sender As Object, e As RoutedEventArgs)
        LoadChartContents()
    End Sub
End Class
