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

/// <summary>
/// ペイントツールプロトタイプ
/// 参考URL
/// http://blog.wdnet.jp/tech/archives/104
/// </summary>

namespace PaintTool
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow:Window
	{
		public MainWindow()
		{
			InitializeComponent();
//			InputBinding
		}

		/// <summary>
		/// ペンボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void penbutton_Click(object sender,RoutedEventArgs e)
		{
			inkCanvas.EditingMode = InkCanvasEditingMode.Ink;
		}

		/// <summary>
		/// 消しゴムボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void erasebutton_Click(object sender,RoutedEventArgs e)
		{
			inkCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
		}

		/// <summary>
		/// クリアボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void clearbutton_Click(object sender,RoutedEventArgs e)
		{
			inkCanvas.Strokes.Clear();
		}

		/// <summary>
		/// セーブボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void savebutton_Click(object sender, RoutedEventArgs e)
		{
//			var savepicker = System.Windows
		}
	}

}
