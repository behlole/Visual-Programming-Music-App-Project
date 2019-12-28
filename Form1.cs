using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Web;
using System.Security.Cryptography;
using System.Net;
using MaterialSkin;
using MaterialSkin.Controls;
using ACRCloudRecognitionTest;
using NAudio.Wave;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Web.Helpers;

//using Newtonsoft.Json.Linq;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WindowsFormsApp11
{

    public partial class Form1 : MaterialForm
    {
      


        SpeechSynthesizer synth = new SpeechSynthesizer();
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        public Form1()
        {
            

           
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400,Primary.Blue500,
                Primary.Blue500,Accent.LightBlue200,
                TextShade.WHITE
                );
            
            synth.Rate = -2;
            synth.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);
            Choices commands = new Choices();
            commands.Add(new string[] { "say hello", "Say my name" });
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new DictationGrammar();
            recEngine.LoadGrammarAsync(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += RecEngine_SpeechRecognized;
           

        }
        public void addText(string str)
        {
            richTextBox1.Text += str;
        }
        private void RecEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {   
           
            
            switch(e.Result.Text)
            {
                case "say hello":
                    {
                        synth.Speak("Hello Behlole");
                        richTextBox1.Text += "Hello Behlole";
                        break;
                    }

                   
                case "say my name":
                    {
                        synth.Speak("Muhammad Behlole Aqil");
                        richTextBox1.Text += "M Behlole Aqil";
                        break;
                    }
                default:
                    {
                        //synth.Speak("Could not hear you\n");
                        break;
                    }
            }
           
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

            WasapiLoopbackCapture CaptureInstance = new WasapiLoopbackCapture();

        public WaveFileWriter RecordedAudioWriter { get; private set; }

        private void enable_Click(object sender, EventArgs e)
        {


            string outputFilePath = @"hello.wav";

            // Redefine the capturer instance with a new instance of the LoopbackCapture class
            this.CaptureInstance = new WasapiLoopbackCapture();

            // Redefine the audio writer instance with the given configuration
            this.RecordedAudioWriter = new WaveFileWriter(outputFilePath, CaptureInstance.WaveFormat);
            //FileStream fs = new FileStream("hello.wav", FileMode.Open);
            //fs.Flush();

            // When the capturer receives audio, start writing the buffer into the mentioned file
            this.CaptureInstance.DataAvailable += (s, a) =>
            {
                this.RecordedAudioWriter.Write(a.Buffer, 0, a.BytesRecorded);
            };

            // When the Capturer Stops
            this.CaptureInstance.RecordingStopped += (s, a) =>
            {
                this.RecordedAudioWriter.Dispose();
                this.RecordedAudioWriter = null;
                CaptureInstance.Dispose();
            };

            // Enable "Stop button" and disable "Start Button"
            this.enable.Enabled = false;
            this.disable.Enabled = true;
            this.recog.Enabled = false;

            // Start recording !
            this.CaptureInstance.StartRecording();
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            disable.Enabled = true;


        }

        private void disable_Click(object sender, EventArgs e)
        {

            //File.Delete(outputFilePath);

            recEngine.RecognizeAsyncStop();

            this.CaptureInstance.StopRecording();
            this.RecordedAudioWriter.Close();



            // Enable "Start button" and disable "Stop Button"
            this.enable.Enabled = false;
            this.disable.Enabled = false;
            this.recog.Enabled = true;





        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void recog_Click(object sender, EventArgs e)
        {
            this.enable.Enabled = true;
            this.disable.Enabled = false;
            this.recog.Enabled = false;
           
            ACRCloudRecognitionTest.Program obj = new ACRCloudRecognitionTest.Program();
            string result= obj.main();

            if (result == null)
            {
                MessageBox.Show("ERROR");
            }
            else
            {
                //var obj = JsonConvert.DeserializeObject<RootObject>(json);
                //Console.WriteLine(obj.data.img_url)

                //result = "[" + result + "]";
                //dynamic variable = (musicData)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(musicData));


                //var details = JObject.Parse(result);

                //var url = (string)details["metadata.music.album.name"];
                //List<musicData> variable = (List<musicData>)Newtonsoft.Json.JsonConvert.DeserializeObject((result), typeof(List<musicData>));
                //string result1 = "[" + result + "]";

                //var variable = JsonConvert.DeserializeObject<musicData>(result);
                //string result1 = result.Replace("\\", " ");
                //string result2 =System.Text.RegularExpressions.Regex.Replace(result, '\''.ToString(), ' '.ToString());
                //result2 = result2.Remove(0, 1);
                //int length = result2.Length;
                //result2.Remove(length, 1);

                //var variable = JsonSerializer.Deserialize<musicData>(result);

                richTextBox1.Text =result ;

                //MessageBox.Show(result);
            }
        }
    }



   
}
