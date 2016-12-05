﻿using CSSSatyr.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace CSSSatyr.Extends
{
    public static partial class CommonLib
    {
        private static Dictionary<ImageFormat, ImageType> _imageTypes = new Dictionary<ImageFormat, ImageType>();
        private static ImageCodecInfo[] _codecInfo = ImageCodecInfo.GetImageEncoders();

        static CommonLib()
        {
            InitLanguage();

            _imageTypes[ImageFormat.Bmp] = new ImageType() { Format = ImageFormat.Bmp, MimeType = "Image/Bmp" };
            _imageTypes[ImageFormat.Jpeg] = new ImageType() { Format = ImageFormat.Jpeg, MimeType = "Image/Jpeg" };
            _imageTypes[ImageFormat.Gif] = new ImageType() { Format = ImageFormat.Gif, MimeType = "Image/Gif" };
            _imageTypes[ImageFormat.Png] = new ImageType() { Format = ImageFormat.Png, MimeType = "Image/Png" };
            _imageTypes[ImageFormat.Icon] = new ImageType() { Format = ImageFormat.Icon, MimeType = "Image/X-Icon" };

        }

        /// <summary>
        /// 根据 mimeType 或图片解码信息
        /// </summary>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        public static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            if (String.IsNullOrEmpty(mimeType))
                return null;

            foreach (ImageCodecInfo ici in _codecInfo)
            {
                if (String.Compare(ici.MimeType, mimeType, false) == 0)
                    return ici;
            }
            return null;
        }

        public static ImageCodecInfo GetCodecInfo(ImageFormat imageFormat)
        {
            ImageType it = GetImageType(imageFormat);
            return GetCodecInfo(it?.MimeType);
        }

        /// <summary>
        /// 获取图片格式
        /// </summary>
        /// <param name="imageFormat"></param>
        /// <returns></returns>
        public static ImageType GetImageType(ImageFormat imageFormat) {
            if (_imageTypes.ContainsKey(imageFormat))
                return _imageTypes[imageFormat];
            return null;
        }

        /// <summary>
        /// 创建矩形笔刷
        /// </summary>
        /// <param name="gridSizeNumW">宽</param>
        /// <param name="gridSizeNumH">高</param>
        /// <returns></returns>
        public static TextureBrush DrawRectangle(int gridSizeNumW, int gridSizeNumH)
        {
            return DrawRectangle(-1, -1, gridSizeNumW, gridSizeNumH);
        }

        /// <summary>
        /// 创建矩形笔刷
        /// </summary>
        /// <param name="x">起点X坐标</param>
        /// <param name="y">起点Y坐标</param>
        /// <param name="gridSizeNumW">宽</param>
        /// <param name="gridSizeNumH">高</param>
        /// <returns></returns>
        public static TextureBrush DrawRectangle(int x, int y, int gridSizeNumW, int gridSizeNumH)
        {
            Bitmap bit = new Bitmap(gridSizeNumW, gridSizeNumH);
            Graphics g = Graphics.FromImage(bit);
            g.Clear(Color.White);
            g.DrawRectangle(Pens.Silver, new Rectangle(-1, -1, gridSizeNumW, gridSizeNumH));
            g.Dispose();
            TextureBrush textureBrush = new TextureBrush(bit);
            textureBrush.TranslateTransform(x, y);

            return textureBrush;
        }

        /// <summary>
        /// 计算自动对齐的X、Y值
        /// </summary>
        /// <param name="x_y">x or y</param>
        /// <returns></returns>
        public static int GetSpaceNum(int x_y)
        {
            int r = Convert.ToInt32((int)(x_y / Global.AutoAlignSpaceNum)) * Global.AutoAlignSpaceNum;
            return r;
        }

    }
}
