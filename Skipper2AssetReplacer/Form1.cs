using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skipper2AssetReplacer
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private string FilePath = string.Empty;
		private byte[] FileData;

		/// <summary>
		/// Allows the user to choose a Skipper and Skeeto 2 save file to load the values from.
		/// Reads each 4 byte chunk of data into the FileData array.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Open_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				//openFileDialog.InitialDirectory = "C:\\Users\\dndga\\AppData\\Local\\VirtualStore\\Program Files (x86)\\Skipper2";
				openFileDialog.InitialDirectory = "C:\\Program Files (x86)\\Skipper2\\";
				openFileDialog.Filter = "dat files (*.dat)|*.dat";
				openFileDialog.FilterIndex = 2;
				openFileDialog.RestoreDirectory = true;

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					FilePath = openFileDialog.FileName;
					FileData = File.ReadAllBytes(FilePath);
					GetImage(0);
				}
			} 
		}

		private void GetImage (int index)
		{
			imageByteIndex = GetPositionAfterMatch(FileData, bmpPattern, index);

			//Console.WriteLine(offset);

			FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
			byte[] bmpBytes = new byte[imageWidth * imageHeight + 5000];
			Console.WriteLine(imageWidth * imageHeight);
			fs.Position = imageByteIndex;
			fs.Read(bmpBytes, 0, bmpBytes.Length);
			fs.Close();
			using (var ms = new MemoryStream(bmpBytes))
			{
				pictureBox1.Image = new Bitmap(ms);
			}
		}

		public static Bitmap BytesToImage(byte[] bytes)
		{
			MemoryStream mStream = new MemoryStream();
			byte[] pData = bytes;
			mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
			Bitmap bm = new Bitmap(mStream, false);
			mStream.Dispose();
			return bm;
		}

		byte[] bmpPattern = new byte[] { 0x42, 0x4D, 0x36 };

		int GetPositionAfterMatch(byte[] data, byte[] pattern, int index)
		{
			Console.WriteLine(index);
			int matchIndex = 0;
			for (int i = 0; i < data.Length - 3; i++)
			{
				bool match = true;
				for (int k = 0; k < 3; k++)
				{
					// As soon as the pattern is broken, reset
					if (data[i + k] != pattern[k])
					{
						match = false;
					}
				}
				if (match)
				{
					if(matchIndex == index)
					{
						// Find width and height and set bytearray to (width * height + 1078)
						using (FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
						{
							byte[] widthBytes = new byte[2];
							byte[] heightBytes = new byte[2];
							
							fs.Position = i + 18;
							fs.Read(widthBytes, 0, 2);
							fs.Position = i + 22;
							fs.Read(heightBytes, 0, 2);
							fs.Position = i + 26;
							
							imageWidth = BitConverter.ToInt16(widthBytes, 0);
							imageHeight = BitConverter.ToInt16(heightBytes, 0);
							//Console.WriteLine("Width: " + BitConverter.ToInt16(widthBytes, 0));
							//Console.WriteLine("Height: " + BitConverter.ToInt16(heightBytes, 0));
						}
						return i;
					}
					matchIndex++;
				}
			}
			return 69;
		}

		int imageWidth = 0;
		int imageHeight = 0;
		int imageByteIndex = 0;

		/// <summary>
		/// Deals with endianness by flipping the order of bytes
		/// </summary>
		private int ReverseBytes(UInt32 value)
		{
			return (int)((value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 | (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24);
		}

		int imageIndex = 0;

		private void btnLeft_Click(object sender, EventArgs e)
		{
			if (imageIndex == 0) return;
			imageIndex--;
			GetImage(imageIndex);
		}

		private void btnRight_Click(object sender, EventArgs e)
		{
			imageIndex++;
			GetImage(imageIndex);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.InitialDirectory = "C:\\";
				openFileDialog.Filter = "bmp files (*.bmp)|*.bmp";
				openFileDialog.FilterIndex = 2;
				openFileDialog.RestoreDirectory = true;

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					byte[] ImageData = File.ReadAllBytes(openFileDialog.FileName);
					int targetByteSize = imageWidth * imageHeight + 1078;
					using(FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
					{
						byte[] bitsperpixel = new byte[2];
						fs.Position = 28;
						fs.Read(bitsperpixel, 0, 2);
						Console.WriteLine(BitConverter.ToInt16(bitsperpixel, 0));
						if (BitConverter.ToInt16(bitsperpixel, 0) != 8)
						{
							MessageBox.Show("Replacement image must have 8 bits per pixel (256 colors)");
							return;
						}
					}
					if(ImageData.Length != targetByteSize)
					{
						DialogResult dialogResult = MessageBox.Show(string.Format("Image is not same size, are you sure you want to do this?\n{0}/{1} ({2} byte difference)", ImageData.Length, targetByteSize, targetByteSize - ImageData.Length), "File Size Mismatch", MessageBoxButtons.YesNo);
						if (dialogResult == DialogResult.Yes)
						{
							ReplaceBytes(ImageData);
						}
					} else
					{
						ReplaceBytes(ImageData);
					}
					
				}
			}
		}

		private void ReplaceBytes (byte[] ImageData)
		{
			string newPath = FilePath.Replace(".dat", "_2.dat");
			File.WriteAllBytes(newPath, FileData);
			// Find width and height and set bytearray to (width * height + 1078)
			using (FileStream fs = new FileStream(newPath, FileMode.Open, FileAccess.Write))
			{
				fs.Position = imageByteIndex;
				fs.Write(ImageData, 0, ImageData.Length);
				MessageBox.Show("Done");
			}
		}

		private void Goto_Click(object sender, EventArgs e)
		{
			imageIndex = (int)numIndex.Value;
			GetImage(imageIndex);
		}
	}
}
