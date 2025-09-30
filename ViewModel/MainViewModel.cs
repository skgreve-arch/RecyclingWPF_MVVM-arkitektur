using System;
using System.IO;
using System.Windows;

namespace RecyclingWPF_MVVM_arkitektur.ViewModel
{
    public class MainViewModel
    {
        private readonly string _destinationFolder = @"C:\DATA\unknown";

        public MainViewModel()
        {
            // Ensure the destination folder exists
            if (!Directory.Exists(_destinationFolder))
                Directory.CreateDirectory(_destinationFolder);
        }

        public void CopyFiles(string[] files)
        {
            foreach (var file in files)
            {
                try
                {
                    if (IsImageFile(file))
                    {
                        string destFile = Path.Combine(_destinationFolder, Path.GetFileName(file));
                        File.Copy(file, destFile, true); // overwrite if exists
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error copying file {file}: {ex.Message}");
                }
            }

            MessageBox.Show("Files copied successfully!");
        }

        private bool IsImageFile(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLower();
            return ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp" || ext == ".gif" || ext == ".tiff";
        }
    }
}
