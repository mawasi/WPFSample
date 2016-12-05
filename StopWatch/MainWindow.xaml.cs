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


/*
 参考URL
WPF4.5入門 その40 「Popup、ToolTip、TextBox、Image、MediaElementコントロール」
http://blog.okazuki.jp/entry/2014/08/16/221447

WPFでタスクトレイにアイコンを表示する
http://csfun.blog49.fc2.com/blog-entry-93.html

タスクトレイにアイコンとバルーンを表示する
https://codezine.jp/article/detail/421

XAML+C#でWPF NotifyIconを使ってオリジナル通知アイコンを表示する
http://qiita.com/Oichan/items/68a5fd339e12193b3ca4
*/

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

		/// <summary>
		/// タスクトレイ通知アイコン
		/// Solution ExplorerのReferencesからadd ReferenceでSystem.WIndows.Formsしてやる
		/// </summary>
		System.Windows.Forms.NotifyIcon		mNotifyIcon;

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

			mNotifyIcon = new System.Windows.Forms.NotifyIcon();
			mNotifyIcon.Text = "Timer";
			mNotifyIcon.Icon =  new System.Drawing.Icon("Watch.ico");
			mNotifyIcon.Visible = true;
			mNotifyIcon.BalloonTipText = "タイマーが終了しました";
			mNotifyIcon.BalloonTipTitle = "Timer";
			mNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;


		}


		void DispTime(object sender,EventArgs e)
		{
			// senderはDispatcherTimer
			var timer = sender as System.Windows.Threading.DispatcherTimer;

			TimeBar.Text = DateTime.Now.ToString("HH:mm:ss");//.ffff");

		}

		/// <summary>
		/// タイマー用ボタンクリック時イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TimerButton_Click(object sender,RoutedEventArgs e)
		{
			Button button = sender as Button;
			TimerDataViewModel vm = button.DataContext as TimerDataViewModel;

			vm.TimerOn = (vm.TimerOn ? false : true);

			// タイマー設定
			mTimer.Tick += TimeOverEvent;
			int hour = HourList.SelectedIndex;
			int minutes = MinutesList.SelectedIndex;
			mTimer.Interval = new TimeSpan(0, hour, minutes, 0);
			mTimer.Start();
		}


		/// <summary>
		/// タイマー終了時イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TimeOverEvent(object sender, EventArgs e)
		{
			TimerDataViewModel vm = TimerButton.DataContext as TimerDataViewModel;

			vm.TimerOn = false;
			mTimer.Stop();
	//		MessageBox.Show("Time Over", "Timer Notify");
			mNotifyIcon.ShowBalloonTip(1000);
		}

		/// <summary>
		/// アプリ終了時イベント(ウィンドウ終了時イベント)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ClosingWindow(object sender, CancelEventArgs e)
		{
			// ちゃんと明示的にDisposeしてやらないとタスクバーに残る
			mNotifyIcon.Dispose();
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
				HourList.Add(i + " Hour");
			}
			for(int i = 0; i < 60; i++) {
				MinutesList.Add(i + " Min");
			}
		}
    }
}
