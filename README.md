# How to add crosshair in .NET-MAUI SfCartesianChart and its customization

In this article, we will demonstrate how to add a crosshair to the [.NET MAUI Chart (SfCartesianChart)](https://www.syncfusion.com/maui-controls/maui-cartesian-charts) and how to customize it for better data analysis. 

A [crosshair ](https://help.syncfusion.com/maui/cartesian-charts/crosshair) helps users to identify exact data values by displaying vertical and horizontal lines at the interaction point. On mobile devices, long‑press the chart to display the crosshair and drag to adjust its position. On desktop, simply move the cursor over the chart area to view the crosshair.

The following steps explain how to add a crosshair to the Cartesian chart.
##### Step 1: Configure the SfCartesianChart
Begin by setting up the Syncfusion® .NET MAUI SfCartesianChart in your application. If this is your first time using the chart, refer to the Syncfusion [ Getting Started documentation](https://help.syncfusion.com/maui/cartesian-charts/getting-started) to configure the chart with the necessary data, axes, and basic elements.

##### Step 2: Enable the Crosshair
To enable the crosshair in the chart, create an instance of [ChartCrosshairBehavior](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartCrosshairBehavior.html#Syncfusion_Maui_Charts_ChartCrosshairBehavior__ctor) and assign it to the [CrosshairBehavior ](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCartesianChart.html#Syncfusion_Maui_Charts_SfCartesianChart_CrosshairBehavior) property of the SfCartesianChart. This activates the crosshair overlay, allowing users to view precise values when interacting with the chart.

**[XAML]**
 ```xml
<chart:SfCartesianChart>
    ...
    <chart:SfCartesianChart.CrosshairBehavior>
        <chart:ChartCrosshairBehavior/>
    </chart:SfCartesianChart.CrosshairBehavior>
    ...
</chart:SfCartesianChart> 
 ```

**[C#]**
 ```csharp
SfCartesianChart chart = new SfCartesianChart();
...
ChartCrosshairBehavior crosshair = new ChartCrosshairBehavior();
chart.CrosshairBehavior = crosshair;
...
this.Content = chart; 
 ```


##### Step 3: Show Crosshair Axis Labels
To display axis labels when the crosshair is active, set the [ShowTrackballLabel](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartAxis.html#Syncfusion_Maui_Charts_ChartAxis_ShowTrackballLabel) property of the corresponding axis to true. By default, the ChartAxis.ShowTrackballLabel property is set to **false**. Enabling this option allows users to clearly view the exact axis values at the crosshair position.

**[XAML]**
 ```xml
<chart:SfCartesianChart>
    ...
    <chart:SfCartesianChart.CrosshairBehavior>
        <chart:ChartCrosshairBehavior/>
    </chart:SfCartesianChart.CrosshairBehavior> 
   
    <chart:SfCartesianChart.XAxes>
        <chart:CategoryAxis ShowTrackballLabel="True"/>
    </chart:SfCartesianChart.XAxes>

    <chart:SfCartesianChart.YAxes>
        <chart:NumericalAxis ShowTrackballLabel="True"/>
    </chart:SfCartesianChart.YAxes>
    ...
</chart:SfCartesianChart> 
 ```

**[C#]**
 ```csharp
SfCartesianChart chart = new SfCartesianChart();
...
ChartCrosshairBehavior crosshair = new ChartCrosshairBehavior();
chart.CrosshairBehavior = crosshair;

CategoryAxis chartXAxis = new CategoryAxis()
{
    ShowTrackballLabel = true
};

NumericalAxis chartYAxis = new NumericalAxis()
{
    ShowTrackballLabel = true
};
chart.XAxes.Add(chartXAxis);
chart.YAxes.Add(chartYAxis);
...
this.Content = chart; 
 ```

##### Output
The following screenshot illustrates how the crosshair appears on the Cartesian chart, helping users easily identify precise data values and corresponding axis labels at the selected interaction point.

 ![Crosshair](https://support.syncfusion.com/kb/agent/attachment/article/15639/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjYyMjcwIiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.Rm9fqmZEqzAoBz1b26KT0eqPhMBVSJbl_710CG9uhAc)

##### Step 4: Customize Crosshair Lines
When ChartCrosshairBehavior is added, vertical and horizontal lines are shown by default. We can customize them using the **VerticalLineStyle** and **HorizontalLineStyle** properties. Key properties include:

**Stroke** – Crosshair line color
**StrokeWidth** – Crosshair line thickness
**StrokeDashArray** – Crosshair dashed line pattern
 
**[XAML]**
 ```xml
<chart:SfCartesianChart>
    . . .
    <chart:SfCartesianChart.CrosshairBehavior>
        <chart:ChartCrosshairBehavior>
            <chart:ChartCrosshairBehavior.HorizontalLineStyle>
                 <chart:ChartLineStyle 
                    Stroke="Red" 
                    StrokeWidth="2"
                    StrokeDashArray="2,2"/>
            </chart:ChartCrosshairBehavior.HorizontalLineStyle>
            <chart:ChartCrosshairBehavior.VerticalLineStyle>
                 <chart:ChartLineStyle 
                    Stroke="Blue" 
                    StrokeWidth="2"
                    StrokeDashArray="5,3"/>
            </chart:ChartCrosshairBehavior.VerticalLineStyle>
        </chart:ChartCrosshairBehavior>
    </chart:SfCartesianChart.CrosshairBehavior>
    ...
</chart:SfCartesianChart> 
 ```

**[C#]**
 ```csharp
SfCartesianChart chart = new SfCartesianChart();
...
ChartCrosshairBehavior crosshair = new ChartCrosshairBehavior();
chart.CrosshairBehavior = crosshair;

DoubleCollection doubleCollection1 = new DoubleCollection();
doubleCollection1.Add(2);
doubleCollection1.Add(2);

ChartLineStyle horizontalLineStyle = new ChartLineStyle()
{
    Stroke = Colors.Red,
    StrokeWidth = 2,
    StrokeDashArray = doubleCollection1
};

crosshair.HorizontalLineStyle = horizontalLineStyle;

DoubleCollection doubleCollection2 = new DoubleCollection();
doubleCollection2.Add(5);
doubleCollection2.Add(3);

ChartLineStyle verticalLineStyle = new ChartLineStyle()
{
    Stroke = Colors.Blue,
    StrokeWidth = 2,
    StrokeDashArray = doubleCollection2
};
crosshair.VerticalLineStyle = verticalLineStyle;
...
this.Content = chart; 
 ```

##### Step 5: Customize Crosshair Axis Labels
We can customize the appearance of crosshair axis labels using the **LabelStyle** property.

**[XAML]**
 ```xml
<chart:SfCartesianChart>
    ...
    <chart:CategoryAxis>
        <chart:CategoryAxis.TrackballLabelStyle>
            <chart:ChartAxisLabelStyle Background="LightBlue"   
                                       FontSize="15" 
                                       CornerRadius="5"
                                       StrokeWidth="2" 
                                       Stroke="Gray"/>
        </chart:CategoryAxis.TrackballLabelStyle>
    </chart:CategoryAxis>
    ...
</chart:SfCartesianChart> 
 ```

**[C#]**
 ```csharp
SfCartesianChart chart = new SfCartesianChart();
. . .
ChartCrosshairBehavior crosshair = new ChartCrosshairBehavior();
chart.CrosshairBehavior = crosshair;

CategoryAxis categoryAxis = new CategoryAxis();
ChartAxisLabelStyle axisLabelStyle = new ChartAxisLabelStyle()
{
    Background = Colors.LightBlue,
    FontSize = 15,
    CornerRadius = 5,
    StrokeWidth = 2,
    Stroke = Colors.Gray
};
categoryAxis.TrackballLabelStyle = axisLabelStyle;
. . .
this.Content = chart; 
 ```

##### Output
The following screenshot demonstrates the result of the axis label and line customization applied to the crosshair in the Cartesian chart.

 ![Crosshair customization](https://support.syncfusion.com/kb/agent/attachment/article/15639/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjYyMjY5Iiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.axyg0Rljb4yFPb-KHsS5gmasa181Pu3xpdCsPa3J9ek)
 
## Troubleshooting
If you are facing a path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

For a step-by-step procedure, refer to the [How to add crosshair lines in the .NET MAUI Chart(SfCartesianChart)? KB article](https://support.syncfusion.com/kb/article/15639/how-to-add-crosshair-lines-in-the-net-maui-chart-sfcartesianchart).