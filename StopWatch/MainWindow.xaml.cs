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
		/// <summary>
		/// 設定した時間後に通知する用のタイマー
		/// </summary>
		System.Windows.Threading.DispatcherTimer mTimer = new System.Windows.Threading.DispatcherTimer();

		public MainWindow()
		{
			InitializeComponent();

			System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

			timer.Tick += DispTime;
			timer.Interval = new TimeSpan(0, 0, 0, 1);	// 一秒おきにデリゲート実行
			timer.Start();

			HourList.ItemsSource = new int[]{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
			HourList.SelectedIndex = 0;
			string[] minutes = new string[60];
			for(int i = 0; i < minutes.Length; i++) {
				minutes[i] = i + " Min";
			}
			MinutesList.ItemsSource = minutes;
			MinutesList.SelectedIndex = 0;
		}


		void DispTime(object sender,EventArgs e)
		{
			// senderはDispatcherTimer
			var timer = sender as System.Windows.Threading.DispatcherTimer;

			TimeBar.Text = DateTime.Now.ToString("HH:mm:ss");//.ffff");

		}

	}


	public class TimerSwitch
	{
		/// <summary>
		/// スイッチがOnか
		/// </summary>
		public bool On;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public TimerSwitch()
		{

		}
	}
}
