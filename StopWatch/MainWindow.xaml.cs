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


using System.ComponentModel;


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

			TimerDataViewModel timervm = new TimerDataViewModel();
			TimerButton.DataContext = timervm;
			HourList.DataContext = timervm;
			MinutesList.DataContext = timervm;
#if false
			HourList.ItemsSource = new int[]{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
			HourList.SelectedIndex = 0;
			string[] minutes = new string[60];
			for(int i = 0; i < minutes.Length; i++) {
				minutes[i] = i + " Min";
			}
			MinutesList.ItemsSource = minutes;
			MinutesList.SelectedIndex = 0;
#endif
		}


		void DispTime(object sender,EventArgs e)
		{
			// senderはDispatcherTimer
			var timer = sender as System.Windows.Threading.DispatcherTimer;

			TimeBar.Text = DateTime.Now.ToString("HH:mm:ss");//.ffff");

		}

		private void TimerButton_Click(object sender,RoutedEventArgs e)
		{
			Button button = sender as Button;
			TimerDataViewModel vm = button.DataContext as TimerDataViewModel;

			vm.TimerOn = (vm.TimerOn ? false : true);
		}
	}


	/// <summary>
	/// タイマーデータビューモデル
	/// </summary>
	public class TimerDataViewModel : INotifyPropertyChanged
	{
		/// <summary>
		/// INotifyPropertyChanged.PropertyChangedの実装
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// INotifyPropertyChanged.PropertyChangedイベントを発生させる
		/// </summary>
		/// <param name="propertyName"></param>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			if(PropertyChanged != null) {
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public TimerData Data = new TimerData();


		public List<string> HourList {
			get { return Data.HourList; }
			private set { Data.HourList = value; }
		}

		public List<string> MinutesList {
			get { return Data.MinutesList; }
			private set { Data.MinutesList = value; }
		}

		public string ButtoName {
			get { return (Data.TimerOn ? "TimerStop" : "TimerStart"); }
			private set { }
		}

		public bool TimerOn {
			get { return Data.TimerOn; }
			set {
				Data.TimerOn = value;
				// スイッチの切り替えでボタンに表示されるテキストを切り替えるようにイベント発生させる
				OnPropertyChanged("ButtoName");
			}
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public TimerDataViewModel()
		{
			
		}

	}

	/// <summary>
	/// タイマーデータオブジェクト
	/// </summary>
    public class TimerData
    {
		/// <summary>
		/// スイッチがOnか
		/// </summary>
		public bool TimerOn = false;

		/// <summary>
		/// 時間リスト
		/// </summary>
		public List<string> HourList = new List<string>();

		/// <summary>
		/// 分リスト
		/// </summary>
		public List<string> MinutesList = new List<string>();

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public TimerData()
		{
			for(int i = 0; i < 24; i++){
				HourList.Add(i + "Hour");
			}
			for(int i = 0; i < 60; i++) {
				MinutesList.Add(i + "Min");
			}
		}
    }
}
