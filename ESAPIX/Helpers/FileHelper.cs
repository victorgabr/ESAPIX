﻿#region

using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

#endregion

namespace ESAPIX.Helpers
{
    public class FileHelper
    {
        /// <summary>
        ///     Provides a file chooser
        /// </summary>
        /// <returns>the path to the file chosen or null for no file selected</returns>
        public static string ChooseFile()
        {
            var dlg = new OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Protocol (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            var result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                var filename = dlg.FileName;
                return filename;
            }
            return null;
        }

        /// <summary>
        ///     Provides a file folder chooser
        /// </summary>
        /// <returns>the path to the folder chosen or null for no folder selected</returns>
        public static string ChooseFolder()
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                return dialog.SelectedPath;
            return null;
        }

        public static void LaunchFile(string path)
        {
            try
            {
                Process.Start("Explorer.exe", $"/e, /root, \"{path}\"");
            }
            catch (Exception ae)
            {
                SaveFile(path);
            }
        }

        public static void LaunchPDFInBrowser(string pdfPath)
        {
            //Launch PDF In Browswer
            var pdfWindow = new Window();
            var browser = new WebBrowser();
            browser.Navigate(new Uri(pdfPath));
            pdfWindow.Content = browser;

            pdfWindow.ShowDialog();
            browser.Dispose();
        }

        public static void SaveFile(string originalFilePath)
        {
            var dlg = new SaveFileDialog();
            var ext = Path.GetExtension(originalFilePath);
            var fileName = Path.GetFileNameWithoutExtension(originalFilePath);
            dlg.FileName = fileName; // Default file name
            dlg.DefaultExt = ext; // Default file extension

            // Show open file dialog box
            var result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                var filename = dlg.FileName;
                File.Copy(originalFilePath, filename);
            }
        }

        /// <summary>
        ///     Removes all illegal characters from a file path so it can be saved
        /// </summary>
        /// <param name="fileName">the desired filename contaminated with illegal characters</param>
        /// <returns>the appropriate filename decontaminated</returns>
        public static string RemoveIllegalCharacters(string fileName)
        {
            var regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            var r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            fileName = r.Replace(fileName, "");
            return fileName;
        }
    }
}