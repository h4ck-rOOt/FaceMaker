using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace FaceMaker.Data
{
	public class Parts
	{
		public List<string> Files;

		public int TotalPartsNum;

		public int CurrentNo;

		public AttributeStruct Attribute;

		public Bitmap BaseBitmap;

		public Bitmap WorkBitmap;

		public string partsName;

		public int colorParentPartsID;

		public int positionParentPartsID;

		public Parts()
		{
			this.TotalPartsNum = 0;
			this.CurrentNo = 0;
			this.Attribute = new AttributeStruct();
			this.BaseBitmap = new Bitmap(Const.ImageSize.Width, Const.ImageSize.Height, PixelFormat.Format32bppArgb);
			this.WorkBitmap = new Bitmap(Const.ImageSize.Width, Const.ImageSize.Height, PixelFormat.Format32bppArgb);
		}

		public Parts(string partsName, int colorID, int positionID) : this()
		{
			this.partsName = partsName;
			string path = Path.Combine(Const.partsDir, partsName);
			this.Files = new List<string>(Directory.GetFiles(path, "*.png"));
			if (this.Files.Count == 0)
			{
				return;
			}
			this.TotalPartsNum = this.Files.Count;
			this.colorParentPartsID = colorID;
			this.positionParentPartsID = positionID;
		}
	}
}
