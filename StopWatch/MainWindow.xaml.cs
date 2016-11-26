using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StopWatch
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow:Window
	{
		public MainWindow()
		{
			InitializeComponent();

			System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

			timer.Tick += DispTime;
			timer.Interval = new TimeSpan(0, 0, 0, 0, 1);	// 一秒おきにデリゲート実行
			timer.Start();

///			testbutton
		}


		void DispTime(object sender,EventArgs e)
		{
			TimeBar.Text = DateTime.Now.ToString("HH:mm:ss.ffff");

		}
		
	}
}
