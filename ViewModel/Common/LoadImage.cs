using Aspose.Imaging;
using Aspose.Imaging.Cloud.Sdk.Api;
using Aspose.Imaging.Cloud.Sdk.Model;
using Aspose.Imaging.Cloud.Sdk.Model.Requests;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.Sources;
using AutoService.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace AutoService.ViewModel.Common
{
    public class LoadImage : ILoadImage
    {
        private readonly string _customerFolder;
        public LoadImage()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            _customerFolder = settings["customerFolder"].Value;
        }

        public string SaveImage(string filePath, string entityName,params Guid[] ids)
        {
            byte[] data;
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                data = new byte[file.Length];
                file.Read(data, 0, data.Length);
            }

            var imageName = filePath.Substring(filePath.LastIndexOf(@"\"));

            string folder = "";

            switch (entityName)
            {
                case nameof(Customer):
                    folder = _customerFolder + $@"\{ids[0]}";
                    break;
                case nameof(Car):
                    folder = _customerFolder + $@"\{ids[0]}" + $@"\{ids[1]}";
                    break;
            }

            DirectoryInfo info = new DirectoryInfo(folder);

            if (!info.Exists)
            {
                info.Create();
            }

            var pathToAdd = info.FullName + imageName;

            //DeleteBackgroundLocal(filePath, pathToAdd);

            using (FileStream file = new FileStream(pathToAdd, FileMode.Create))
            {
                file.Write(data, 0, data.Length);
            }

            return pathToAdd;
        }

        public string OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы изображений (*.bmp, *.jpg, *.jpeg, *.png)|*.bmp;*.jpg;*.jpeg;*.png";
            bool? result = openFileDialog.ShowDialog();
            var file_path = openFileDialog.FileName;
            return file_path;
        }

        public void DeleteBackgroundLocal(string filePath, string pathToAdd)
        {
            MaskingResult results;
            RasterImage image = (RasterImage)Image.Load(filePath);

            // To use Graph Cut with auto calculated strokes, AutoMaskingGraphCutOptions is used.
            AutoMaskingGraphCutOptions options = new AutoMaskingGraphCutOptions
            {
                // Indicating that a new calculation of the default strokes should be performed during the image decomposition.
                CalculateDefaultStrokes = true,
                // Setting post-process feathering radius based on the image size.
                FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions =
                                                                new PngOptions()
                                                                {
                                                                    ColorType = PngColorType.TruecolorWithAlpha,
                                                                    Source = new FileCreateSource("tempFile")
                                                                },
                BackgroundReplacementColor = Color.Transparent
            };

            results = new ImageMasking(image).Decompose(options);

            using (RasterImage resultImage = (RasterImage)results[1].GetImage())
            {
                resultImage.Save(pathToAdd, new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha });
            }

            image.Dispose();
        }
    }
}
