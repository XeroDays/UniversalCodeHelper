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
using System.Xml;

namespace UniversalCodeHelper.Forms
{
    public partial class YoloTxtXmlConverter : Form
    {
        public YoloTxtXmlConverter()
        {
            InitializeComponent();
        }

        private void YoloTxtXmlConverter_Load(object sender, EventArgs e)
        {

        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select the folder containing YOLO label files";
                folderDialog.ShowNewFolderButton = false;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtLabelsBrowse.Text = folderDialog.SelectedPath;
                    int ss = Directory.GetFiles(txtLabelsBrowse.Text, "*.txt").Length;
                    lblTotalFiles.Text = "Total files: " + ss;
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private string FindImageFile(string imageFolder, string filename)
        {
            // Define supported image extensions
            string[] supportedExtensions = { ".jpg", ".jpeg", ".png", ".bmp" };

            // Get all image files in the image folder
            var imageFiles = Directory.GetFiles(imageFolder)
                                    .Where(file => supportedExtensions.Contains(Path.GetExtension(file).ToLower()));

            // Look for any image file that matches our filename (regardless of extension)
            var matchingImage = imageFiles.FirstOrDefault(file =>
                Path.GetFileNameWithoutExtension(file).Equals(filename, StringComparison.OrdinalIgnoreCase));

            return matchingImage;
        }
        private string FindImageFile(string filename)
        {
            // Define supported image extensions
            string[] supportedExtensions = { ".jpg", ".jpeg", ".png", ".bmp" };

            // Get all image files in the image folder
            var imageFiles = Directory.GetFiles(txtImageBrowse.Text)  .Where(file => supportedExtensions.Contains(Path.GetExtension(file).ToLower()));

            // Look for any image file that matches our filename (regardless of extension)
            var matchingImage = imageFiles.FirstOrDefault(file =>
                Path.GetFileNameWithoutExtension(file).Equals(filename, StringComparison.OrdinalIgnoreCase));

            return matchingImage;
        }

        private void ConvertToXml(string outputFolder ,string txtFilePath)
        {
            try
            {
                string filename = Path.GetFileNameWithoutExtension(txtFilePath);

                // Find corresponding image file
                string imagePath = FindImageFile(filename);

                if (string.IsNullOrEmpty(imagePath))
                {
                    MessageBox.Show($"Image not found for label: {filename}", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get actual image dimensions
                int img_width, img_height;
                using (Image img = Image.FromFile(imagePath))
                {
                    img_width = img.Width;
                    img_height = img.Height;
                }

                // Create XML file path in the selected output directory
                string xmlFilePath = Path.Combine(outputFolder, filename + ".xml");

                XmlDocument doc = new XmlDocument();
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(xmlDeclaration);

                // Create root annotation element
                XmlElement annotation = doc.CreateElement("annotation");
                doc.AppendChild(annotation);

                // Add database element (optional)
                XmlElement database = doc.CreateElement("database");
                database.InnerText = "Unknown";
                annotation.AppendChild(database);

                // Add basic image information
                XmlElement folder = doc.CreateElement("folder");
                folder.InnerText = Path.GetDirectoryName(imagePath);
                annotation.AppendChild(folder);

                XmlElement filenameElement = doc.CreateElement("filename");
                filenameElement.InnerText = Path.GetFileName(imagePath);
                annotation.AppendChild(filenameElement);

                XmlElement path = doc.CreateElement("path");
                path.InnerText = imagePath;
                annotation.AppendChild(path);

                // Add source information
                XmlElement source = doc.CreateElement("source");
                XmlElement sourceDatabase = doc.CreateElement("database");
                sourceDatabase.InnerText = "Unknown";
                source.AppendChild(sourceDatabase);
                annotation.AppendChild(source);

                // Add size information
                XmlElement size = doc.CreateElement("size");
                annotation.AppendChild(size);

                XmlElement widthElem = doc.CreateElement("width");
                widthElem.InnerText = img_width.ToString();
                size.AppendChild(widthElem);

                XmlElement heightElem = doc.CreateElement("height");
                heightElem.InnerText = img_height.ToString();
                size.AppendChild(heightElem);

                XmlElement depthElem = doc.CreateElement("depth");
                depthElem.InnerText = "3";  // Assuming RGB images
                size.AppendChild(depthElem);

                // Add segmented element
                XmlElement segmented = doc.CreateElement("segmented");
                segmented.InnerText = "0";
                annotation.AppendChild(segmented);

                // Read and process each line from the text file
                string[] lines = File.ReadAllLines(txtFilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length >= 5)
                    {
                        XmlElement object_elem = doc.CreateElement("object");
                        annotation.AppendChild(object_elem);

                        // Add name (class)
                        XmlElement name = doc.CreateElement("name");
                        name.InnerText = parts[0];
                        object_elem.AppendChild(name);

                        // Add pose
                        XmlElement pose = doc.CreateElement("pose");
                        pose.InnerText = "Unspecified";
                        object_elem.AppendChild(pose);

                        // Add truncated
                        XmlElement truncated = doc.CreateElement("truncated");
                        truncated.InnerText = "0";
                        object_elem.AppendChild(truncated);

                        // Add difficult
                        XmlElement difficult = doc.CreateElement("difficult");
                        difficult.InnerText = "0";
                        object_elem.AppendChild(difficult);

                        // Add bounding box
                        XmlElement bndbox = doc.CreateElement("bndbox");
                        object_elem.AppendChild(bndbox);

                        try
                        {
                            // Convert YOLO format to XML format
                            float x_center = float.Parse(parts[1], System.Globalization.CultureInfo.InvariantCulture);
                            float y_center = float.Parse(parts[2], System.Globalization.CultureInfo.InvariantCulture);
                            float width = float.Parse(parts[3], System.Globalization.CultureInfo.InvariantCulture);
                            float height = float.Parse(parts[4], System.Globalization.CultureInfo.InvariantCulture);

                            // Convert normalized coordinates to pixel coordinates
                            int xmin = Math.Max(0, (int)((x_center - width / 2) * img_width));
                            int ymin = Math.Max(0, (int)((y_center - height / 2) * img_height));
                            int xmax = Math.Min(img_width, (int)((x_center + width / 2) * img_width));
                            int ymax = Math.Min(img_height, (int)((y_center + height / 2) * img_height));

                            XmlElement xminElement = doc.CreateElement("xmin");
                            xminElement.InnerText = xmin.ToString();
                            bndbox.AppendChild(xminElement);

                            XmlElement yminElement = doc.CreateElement("ymin");
                            yminElement.InnerText = ymin.ToString();
                            bndbox.AppendChild(yminElement);

                            XmlElement xmaxElement = doc.CreateElement("xmax");
                            xmaxElement.InnerText = xmax.ToString();
                            bndbox.AppendChild(xmaxElement);

                            XmlElement ymaxElement = doc.CreateElement("ymax");
                            ymaxElement.InnerText = ymax.ToString();
                            bndbox.AppendChild(ymaxElement);
                        }
                        catch (FormatException ex)
                        {
                            MessageBox.Show($"Error parsing coordinates in file {filename}: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                // Save the XML file to the selected output directory
                doc.Save(xmlFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing file: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 

        private void btnBrowseImages_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select the folder containing YOLO images files";
                folderDialog.ShowNewFolderButton = false;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtImageBrowse.Text = folderDialog.SelectedPath;
                    int ss = Directory.GetFiles(txtImageBrowse.Text, "*.*").Length;
                    lblTotalImages.Text = "Total images: " + ss;
                }
            }
        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            string labelFolder = txtLabelsBrowse.Text;
            string imageFolder = txtImageBrowse.Text;
            if (string.IsNullOrEmpty(labelFolder) || string.IsNullOrEmpty(imageFolder))
            {
                MessageBox.Show("Please select both label and image folders.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 



            using (FolderBrowserDialog outputDialog = new FolderBrowserDialog())
            {
                outputDialog.Description = "Select destination folder for XML files";
                if (outputDialog.ShowDialog() == DialogResult.OK)
                {
                    string outputFolder = outputDialog.SelectedPath;
                    try
                    {
                        btnStart.Enabled = false;
                        string[] txtFiles = Directory.GetFiles(labelFolder, "*.txt");
                        int totalFiles = txtFiles.Length;
                        int processedFiles = 0;

                        foreach (string txtFile in txtFiles)
                        {
                            ConvertToXml(outputFolder,txtFile);
                            processedFiles++;
                            // You could add a progress bar here to show conversion progress
                        }

                        MessageBox.Show($"Conversion completed successfully!\nProcessed {processedFiles} files.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnStart.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error during conversion: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnStart.Enabled = true;
                    }
                }
            }
        }
    }
}
