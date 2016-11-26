using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Media.Imaging;

namespace PictureVIewer
{
	/// <summary>
	/// ピクチャデータビューモデル
	/// ViewにModelの変更を伝えて更新してもらうためにINotifyPropertyChangedを継承
	/// </summary>
	public class PictureDataViewModel// : System.ComponentModel.INotifyPropertyChanged
	{
		// Viewへ変更を伝えるためのハンドル
//		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// ピクチャデータ
		/// </summary>
		public class PictureData
		{
			public BitmapImage image = null;

			/// <summary>
			/// コンストラクタ
			/// </summary>
			public PictureData()
			{
				image = new BitmapImage();
				image.BeginInit();
				image.UriSource = new Uri(@"C:\data\program\prototype\PictureVIewer\dva.png");
				image.EndInit();
			}
		}

		PictureData data = null;//new PictureData();

		//プロパティ
		public BitmapImage image {
			get{ return data.image; }
			set{
				data.image = value;
//				OnPropertyChanged("image");
			}
		}


		// フォーム上のイメージコントロール
		System.Windows.Controls.Image ImageControl = null;


		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="image"></param>
		public PictureDataViewModel(System.Windows.Controls.Image control)
		{
			data = new PictureData();
			ImageControl = control;
		}


#if false
		protected void OnPropertyChanged(string name)
		{
			var handler = PropertyChanged;
			if (null != handler)
			{
				handler(this, new System.ComponentModel.PropertyChangedEventArgs(name));
			}
		}
#endif
	}


}
