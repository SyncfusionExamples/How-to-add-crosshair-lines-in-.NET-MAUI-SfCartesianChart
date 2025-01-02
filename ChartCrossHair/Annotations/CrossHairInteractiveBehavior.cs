using Syncfusion.Maui.Toolkit.Charts;

namespace ChartCrossHair.UsingAnnotations
{
    public class CrossHairInteractiveBehavior : ChartInteractiveBehavior
    {
        public delegate void TouchMoveEventHandler(object sender, TouchMoveEventArgs e);

        // Define an event based on the delegate
        public event TouchMoveEventHandler TouchMoveEvent;

        public CrossHairInteractiveBehavior()
        {
            TouchMoveEvent += CrossHairInteractiveBehavior_TouchMoveEvent;
        }

        private void CrossHairInteractiveBehavior_TouchMoveEvent(object sender, TouchMoveEventArgs e)
        {
        }

        protected override void OnTouchMove(ChartBase chart, float pointX, float pointY)
        {
            base.OnTouchMove(chart, pointX, pointY);
            TouchMoveEvent?.Invoke(this, new TouchMoveEventArgs(pointX, pointY));
        }
    }

    public class TouchMoveEventArgs : EventArgs
    {
        public float PointX { get; }
        public float PointY { get; }

        public TouchMoveEventArgs(float pointX, float pointY)
        {
            PointX = pointX;
            PointY = pointY;
        }
    }
}
