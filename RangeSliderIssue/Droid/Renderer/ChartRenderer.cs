// ChartRenderer.cs
//
//  Author:
//       Nisha <NThakur6@slb.com>
//
//  Copyright (c) 2017 Nisha
using System;
using System.Collections.Generic;
using Com.Telerik.Widget.Chart.Engine.Databinding;
using Com.Telerik.Widget.Chart.Visualization.PieChart;
using RangeSliderIssue;
using RangeSliderIssue.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomChartView), typeof(ChartRenderer))]
namespace RangeSliderIssue.Droid
{
	public class ChartRenderer: ViewRenderer
	{
		CustomChartView view;
		Java.Util.ArrayList monthResults;

		protected override void OnElementChanged(ElementChangedEventArgs<View> e)
		{
			base.OnElementChanged(e);

			view = this.Element as CustomChartView;

			if (view != null)
			{
				//InitData();
				//view.HeightRequest = 200;
				//view.WidthRequest = 200;


				drawPieChart();
			}

		}

		private void drawPieChart()
		{
			InitData();
			RadPieChartView pieView = new RadPieChartView(Android.App.Application.Context);

			//pieView.SetMinimumWidth(200);
			//pieView.SetMinimumHeight(200);


			DoughnutSeries donutSeries = new DoughnutSeries();
			donutSeries.ValueBinding = new MonthResultDataBinding("Result");
			donutSeries.Data = (Java.Lang.IIterable)this.monthResults;
			donutSeries.InnerRadiusFactor = 0.85f;
			pieView.Series.Add(donutSeries);



			SliceStyle style1 = new SliceStyle();
			//style1.FillColor = Android.Graphics.Color.ParseColor("#66000000");
			style1.FillColor = Android.Graphics.Color.Green;




			SliceStyle style2 = new SliceStyle();
			style2.FillColor = Android.Graphics.Color.Brown;

			SliceStyle style3 = new SliceStyle();
			style3.FillColor = Android.Graphics.Color.Red;

			List<SliceStyle> styles = new List<SliceStyle>();
			styles.Add(style1);
			styles.Add(style2);
			styles.Add(style3);
			donutSeries.SliceStyles = styles;

			this.SetNativeControl(pieView);

		}


		private void InitData()
		{
			monthResults = new Java.Util.ArrayList();
			monthResults.Add(new MonthResult("Jan", 12));
			monthResults.Add(new MonthResult("Feb", 5));
			monthResults.Add(new MonthResult("Mar", 10));
		}

		public class MonthResult : Java.Lang.Object
		{

			public String Month { get; set; }
			public double Result { get; set; }

			public MonthResult(String month, double result)
			{
				this.Month = month;
				this.Result = result;
			}
		}

		class MonthResultDataBinding : DataPointBinding
		{

			private string propertyName;

			public MonthResultDataBinding(string propertyName)
			{
				this.propertyName = propertyName;
			}

			public override Java.Lang.Object GetValue(Java.Lang.Object p0)
			{
				if (propertyName == "Month")
				{
					return ((MonthResult)(p0)).Month;
				}
				return ((MonthResult)(p0)).Result;
			}
		}
	}
}
