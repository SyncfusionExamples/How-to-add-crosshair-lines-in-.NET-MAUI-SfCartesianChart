using Syncfusion.Maui.Toolkit.Charts;
using Font = Microsoft.Maui.Graphics.Font;

namespace ChartCrossHair.UsingGraphicsView
{
    public class CrossHairBehavior : GraphicsView, IDrawable
    {
        private bool isTouchActive = false;
        private string? CrossHairXValue;
        private string? CrossHairYValue;
        private string? CrossHairPointValue;
        private PointF CrossHairX1;
        private PointF CrossHairX2;
        private PointF CrossHairY1;
        private PointF CrossHairY2;

        public static readonly BindableProperty ShowCrossHairProperty = BindableProperty.Create(nameof(ShowCrossHair), typeof(bool), typeof(CrossHairBehavior), false, BindingMode.Default, null);

        public bool ShowCrossHair
        {
            get { return (bool)GetValue(ShowCrossHairProperty); }
            set { SetValue(ShowCrossHairProperty, value); }
        }

        public CrossHairBehavior()
        {
            Drawable = this;
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if (ShowCrossHair && isTouchActive)
            {
                canvas.StrokeColor = Colors.Red;
                canvas.DrawLine(CrossHairX1, CrossHairX2);
                canvas.DrawLine(CrossHairY1, CrossHairY2);

                canvas.FontColor = Colors.Black;
                canvas.Font = Font.DefaultBold;
                canvas.DrawString(CrossHairPointValue, CrossHairX1.X + 2, CrossHairY1.Y - 5, HorizontalAlignment.Left);
                canvas.DrawString(CrossHairXValue, CrossHairX1.X + 2, CrossHairX2.Y - 5, HorizontalAlignment.Left);
                canvas.DrawString(CrossHairYValue, CrossHairY1.X + 2, CrossHairY1.Y - 5, HorizontalAlignment.Left);
            }
        }

        public void OnTouchMove(ChartBase chart, float pointX, float pointY)
        {
            isTouchActive = true;
            CalculateCrossHairPoints(chart, pointX, pointY);
            Invalidate();
        }

        public void OnTouchUp(ChartBase chart, float pointX, float pointY)
        {
            isTouchActive = false;
            Invalidate();
        }

        private void CalculateCrossHairPoints(ChartBase chart, float pointX, float pointY)
        {
            if (chart is SfCartesianChart cartesianChart)
            {
                bool isCrossHairArea = cartesianChart.SeriesBounds.Contains(pointX, pointY);

                if (isCrossHairArea)
                {
                    double x = cartesianChart.PointToValue(cartesianChart.XAxes[0], pointX, pointY);
                    double y = cartesianChart.PointToValue(cartesianChart.YAxes[0], pointX, pointY);

                    float crossHairX = cartesianChart.XAxes[0].ValueToPoint(x);
                    float crossHairY = cartesianChart.YAxes[0].ValueToPoint(y);

                    CrossHairXValue = cartesianChart.XAxes[0].PointToValue(crossHairX, crossHairY).ToString("0.00");
                    CrossHairYValue = cartesianChart.YAxes[0].PointToValue(crossHairX, crossHairY).ToString("0.00");

                    CrossHairPointValue = CrossHairXValue + ", " + CrossHairYValue;

                    float crossHairLeft = cartesianChart.XAxes[0].ValueToPoint(cartesianChart.XAxes[0].VisibleMinimum);
                    float crossHairRight = cartesianChart.XAxes[0].ValueToPoint(cartesianChart.XAxes[0].VisibleMaximum);
                    float crossHairTop = cartesianChart.YAxes[0].ValueToPoint(cartesianChart.YAxes[0].VisibleMaximum);
                    float crossHairBottom = cartesianChart.YAxes[0].ValueToPoint(cartesianChart.YAxes[0].VisibleMinimum);

                    CrossHairX1 = new PointF(crossHairX, crossHairTop);
                    CrossHairX2 = new PointF(crossHairX, crossHairBottom);
                    CrossHairY1 = new PointF(crossHairLeft, crossHairY);
                    CrossHairY2 = new PointF(crossHairRight, crossHairY);
                }
                else
                {
                    Reset();
                }
            }
        }

        private void Reset()
        {
            CrossHairX1 = CrossHairX2 = CrossHairY1 = CrossHairY2 = new PointF(0, 0);
        }
    }
}
