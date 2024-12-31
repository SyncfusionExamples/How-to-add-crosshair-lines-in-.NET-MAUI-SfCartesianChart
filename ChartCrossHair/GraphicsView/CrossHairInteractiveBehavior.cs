using Syncfusion.Maui.Toolkit.Charts;

namespace ChartCrossHair.UsingGraphicsView
{
    public class CrossHairInteractiveBehavior : ChartInteractiveBehavior
    {
        protected override void OnTouchMove(ChartBase chart, float pointX, float pointY)
        {
            if (chart is SfCartesianChart cartesianChart && cartesianChart.PlotAreaBackgroundView is CrossHairBehavior crossHairBehavior)
            {
                crossHairBehavior.OnTouchMove(cartesianChart, pointX, pointY);
            }
        }

        protected override void OnTouchUp(ChartBase chart, float pointX, float pointY)
        {
            if (chart is SfCartesianChart cartesianChart && cartesianChart.PlotAreaBackgroundView is CrossHairBehavior crossHairBehavior)
            {
                crossHairBehavior.OnTouchUp(cartesianChart, pointX, pointY);
            }
        }
    }
}
