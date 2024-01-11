using System.Diagnostics;
using System.Drawing.Imaging;
using System.Text;
using System.Text.RegularExpressions;

namespace PhotoOrganizerApp
{
    public partial class MainForm : Form
    {
        private const string PhotoOrganizerFolderName = "PhotoOrganizer";

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click_1(object sender, EventArgs e)
        {
            using FolderBrowserDialog folderBrowserDialog = new();
            // Set the initial selected path (if available) or the default folder.
            folderBrowserDialog.SelectedPath = !string.IsNullOrWhiteSpace(txtSourceFolder.Text)
                ? txtSourceFolder.Text
                : Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {
                txtSourceFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string sourcePath = txtSourceFolder.Text;
            string destinationPath = Path.Combine(sourcePath, PhotoOrganizerFolderName);

            progressBar.Value = 0;
            lblPercentage.Text = "0%";

            try
            {
                List<string> duplicateFiles = new();
                ProcessFiles(sourcePath, destinationPath, ref duplicateFiles);

                foreach (string file in duplicateFiles)
                {
                    txtOutput.AppendText($"File already exists: {file}\r\n");
                }

                txtOutput.AppendText($"Files successfully copied to: {destinationPath}\r\n");
                btnOpenDestination.Visible = true;
            }
            catch (Exception ex)
            {
                txtOutput.AppendText($"Error: {ex.Message}\r\n");
            }
        }

        private void btnOpenDestination_Click(object sender, EventArgs e)
        {
            try
            {
                string destinationPath = Path.Combine(txtSourceFolder.Text, "PhotoOrganizer");
                if (Directory.Exists(destinationPath))
                {
                    Process.Start("explorer.exe", destinationPath);
                }
                else
                {
                    MessageBox.Show("Destination folder does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Error opening destination folder: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcessFiles(string sourcePath, string destinationPath, ref List<string> duplicateFiles)
        {
            int filesCounter = 0;
            string[] pathList = Directory.GetFileSystemEntries(sourcePath, "*", SearchOption.AllDirectories);
            int totalFiles = pathList
                .Where(path => (File.GetAttributes(path) & (FileAttributes.Hidden | FileAttributes.Directory)) == 0)
                .ToArray()
                .Length;

            foreach (string fileOrDir in pathList)
            {
                if (File.Exists(fileOrDir))
                {
                    try
                    {
                        FileAttributes attributes = File.GetAttributes(fileOrDir);
                        if ((attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                        {
                            FileInfo fileInfo = new(fileOrDir);

                            DateTime takenTime = GetTakenDateFromFileInfo(fileInfo) ?? DateTime.Now;
                            DateTime creationTime = fileInfo.CreationTime;
                            DateTime lastWriteTime = fileInfo.LastWriteTime;

                            // Find the smallest date among the three
                            DateTime fileDate = GetSmallestDate(takenTime, creationTime, lastWriteTime);

                            string fullYear = fileDate.Year.ToString();
                            string year = fileDate.Year.ToString().Substring(2, 2);
                            string month = fileDate.Month.ToString().PadLeft(2, '0');
                            string day = fileDate.Day.ToString().PadLeft(2, '0');

                            string newPath = destinationPath;

                            if (checkBoxYear.Checked)
                            {
                                newPath = Path.Combine(newPath, fullYear);
                            }

                            if (checkBoxMonth.Checked)
                            {
                                newPath = Path.Combine(newPath, year + '.' + month);
                            }

                            if (checkBoxDay.Checked)
                            {
                                newPath = Path.Combine(newPath, year + '.' + month + '.' + day);
                            }

                            if (!Directory.Exists(newPath))
                            {
                                _ = Directory.CreateDirectory(newPath);
                            }

                            string fileName = Path.GetFileName(fileOrDir);
                            string newFilePath = Path.Combine(newPath, fileName);

                            try
                            {
                                File.Copy(fileOrDir, newFilePath, false);
                                filesCounter++;
                                txtOutput.AppendText($"{filesCounter}: {fileOrDir}\r\n");
                            }
                            catch (Exception ex) when (ex.Message.Contains("already exists")) // File already exists
                            {
                                duplicateFiles.Add(fileOrDir);
                            }
                            catch (Exception ex)
                            {
                                txtOutput.AppendText($"Error copying {fileOrDir}: {ex.Message}\r\n");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        txtOutput.AppendText($"Error processing {fileOrDir}: {ex.Message}\r\n");
                    }
                }

                progressBar.Value = (int)((double)filesCounter / (totalFiles - duplicateFiles.Count) * progressBar.Maximum);
                lblPercentage.Text = $"{progressBar.Value}%";
            }

            static DateTime? GetTakenDateFromFileInfo(FileInfo fileInfo)
            {
                Regex r = new(":");

                try
                {
                    using FileStream fs = fileInfo.OpenRead();
                    using Image image = Image.FromStream(fs, false, false);
                    PropertyItem propItem = image.GetPropertyItem(36867);
                    string dateTaken = r.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);
                    return DateTime.Parse(dateTaken);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return null;
                }
            }

            static DateTime GetSmallestDate(DateTime date1, DateTime date2, DateTime date3)
            {
                return DateTime.MinValue.AddTicks(
                    Math.Min(date1.Ticks, Math.Min(date2.Ticks, date3.Ticks))
                );
            }
        }
    }
}
