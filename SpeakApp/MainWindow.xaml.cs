using SharpTalk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpeakApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FonixTalkEngine tts;

        public MainWindow()
        {
            InitializeComponent();
            tts = new FonixTalkEngine();
            this.Closing += OnClosing;
        }

        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tts.Dispose();
        }

        private void SpeakClick(object sender, RoutedEventArgs e)
        {
            tts.Reset();
            tts.Speak(Speech.GetText());
        }

        private void WAVClick(object sender, RoutedEventArgs e)
        {
            tts.Reset();
            tts.SpeakToWavFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/fonixtalk.wav", Speech.GetText());
        }
    }
}
