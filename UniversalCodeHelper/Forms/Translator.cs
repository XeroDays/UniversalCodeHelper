using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversalCodeHelper.Helpers;

namespace UniversalCodeHelper.Forms
{
    public partial class Translator : Form
    {

        List<string> sentences = new List<string>();
        HashSet<string> allFields = new HashSet<string>(); // To collect all unique fields
        
        BackgroundWorker backgroundWorker = new BackgroundWorker();


        public Translator()
        {
            InitializeComponent();
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;

        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                btnLocalization.Enabled = true;
                btnLocalization.Text = "Submit";
                //set button color to 192, 255, 192
                btnLocalization.BackColor = Color.FromArgb(192, 255, 192);
                txtFrom.Text = e.Result.ToString();
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string jsonText = txtFrom.Text;
            string keyLang = txtLanguageCode.Text;
            using (JsonDocument doc = JsonDocument.Parse(jsonText))
            {
                foreach (JsonElement element in doc.RootElement.EnumerateArray())
                {
                    if (element.TryGetProperty(keyLang, out JsonElement enElement))
                    {
                        sentences.Add(enElement.GetString());
                    }

                    foreach (JsonProperty property in element.EnumerateObject())
                    {
                        allFields.Add(property.Name);
                    }
                }
            }

            TranslateApiController translateApiController = new TranslateApiController();
            List<dynamic> translationModels = new List<dynamic>();

            foreach (string sentence in sentences)
            {
                dynamic translationModel = new ExpandoObject();
                foreach (var field in allFields)
                {
                    if (field == keyLang)
                    {
                        ((IDictionary<string, object>)translationModel)[field] = sentence;
                        continue;
                    }
                    TranslationResponse translationResponse = translateApiController.TranslateAsync(sentence, field).Result;

                    ((IDictionary<string, object>)translationModel)[field] = translationResponse.Translation.First();
                }
                translationModels.Add(translationModel);
            }

            string jsonResult = JsonConvert.SerializeObject(translationModels, Formatting.Indented);

            sentences.Clear();
            allFields.Clear();
            e.Result = jsonResult;
        }

        private void btnLocalization_Click(object sender, EventArgs e)
        {
            InitProcess();
        }

        void InitProcess()
        { 
            if (backgroundWorker.IsBusy)
            {
                MessageBox.Show("Process is already running");
                return;
            }
            btnLocalization.Enabled = false;
            btnLocalization.Text= "Processing...";
            btnLocalization.BackColor = Color.Gray;

            backgroundWorker.RunWorkerAsync();
        }
         
    }
}
