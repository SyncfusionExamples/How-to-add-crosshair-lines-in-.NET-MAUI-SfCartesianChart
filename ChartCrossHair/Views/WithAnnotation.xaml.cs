namespace ChartCrossHair;

public partial class WithAnnotation : ContentPage
{
	public WithAnnotation()
	{
		InitializeComponent();
	}

    private void CrossHairInteractiveBehavior_TouchMoveEvent(object sender, UsingAnnotations.TouchMoveEventArgs e)
    {
        bool inSeriesBounds = chart.SeriesBounds.Contains(e.PointX, e.PointY);

        // Show or hide annotations based on whether the touch is within the series bounds
        Horizontal.IsVisible = inSeriesBounds;
        Vertical.IsVisible = inSeriesBounds;

        // Show or hide axis labels based on whether the touch is within the series bounds
        Horizontal.ShowAxisLabel = inSeriesBounds;
        Vertical.ShowAxisLabel = inSeriesBounds;

        // If the touch is within the chart area, update the position of the annotations
        if (inSeriesBounds)
        {
            var x = chart.PointToValue(xAxis, e.PointX, e.PointY); // Get the X-axis value at the touch point
            var y = chart.PointToValue(yAxis, e.PointX, e.PointY); // Get the Y-axis value at the touch point

            // Update the annotations' positions based on the touch coordinates
            Horizontal.Y1 = y;
            Vertical.X1 = x;
        }
    }

}