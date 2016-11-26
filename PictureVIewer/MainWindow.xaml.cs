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

namespace PictureVIewer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow:Window
	{

	//	PictureDataViewModel PictDataViewModel = null;

		public MainWindow()
		{
			InitializeComponent();
//			PictDataViewModel = new PictureDataViewModel(PictImage);
//			PictImage.DataContext = PictDataViewModel;
		}

		/// <summary>
		/// ピクチャコントロールへのドラッグイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void PictImage_PreviewDragOver(object sender, System.Windows.DragEventArgs e)
		{
			Console.WriteLine("PreviewDragOver test");

			if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
				e.Effects = DragDropEffects.Copy;
			else
				e.Effects = DragDropEffects.None;
			e.Handled = true;
		}

		/// <summary>
		///  ピクチャコントロールへのドロップイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void PictImage_Drop(object sender, System.Windows.DragEventArgs e)
		{
			Console.WriteLine("Drop test");

	//		PictureDataViewModel vm = PictImage.DataContext as PictureDataViewModel;

			string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];

			// 一つ目しか処理しない
			if(files != null) {
				PictCanvas.Children.Clear();
				Image pictimage = new Image();
				BitmapImage image = new BitmapImage();
				image.BeginInit();
				image.UriSource = new Uri(files[0]);
				image.EndInit();
				pictimage.Source = image;
				PictCanvas.Children.Add(pictimage);
	//			vm.image = image;
			}
		}

		/// <summary>
		/// イメージコントロールを削除するテスト
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Test_Button_Click(object sender,RoutedEventArgs e)
		{
	//		PictImage
//			GridPanel.Children.Remove(PictImage);
		}
	}
}
