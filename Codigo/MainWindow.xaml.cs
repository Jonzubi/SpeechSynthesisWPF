using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
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

namespace SpeechSynthesisWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SpeechSynthesizer m_Synthesizer;

        public MainWindow()
        {
            InitializeComponent();

            m_Synthesizer = new SpeechSynthesizer();

            var voices = m_Synthesizer.GetInstalledVoices();

            foreach (var voice in voices)
                cmbVoices.Items.Add(voice.VoiceInfo.Name);

            cmbVoices.SelectedIndex = 0;
        }

        private void btnSpeak_Click(object sender, RoutedEventArgs e)
        {
            m_Synthesizer.SelectVoice(cmbVoices.SelectedItem.ToString());
            m_Synthesizer.Speak(txtSpeach.Text);
        }

    }
}
