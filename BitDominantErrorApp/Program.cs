using System.Speech.Recognition;
using System.Media;
using System.Reflection;
using BitDominantErrorApp.Properties;

class Program
{
    static SoundPlayer soundPlayer;
    static void Main()
    {

        SpeechRecognitionEngine speech = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("ja-JP"));

        GrammarBuilder grammar = new();

        grammar.Append("ビット");

        speech.LoadGrammar(new Grammar(grammar));

        speech.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognised);

        speech.SetInputToDefaultAudioDevice();

        speech.RecognizeAsync(RecognizeMode.Multiple);

        soundPlayer = new(Resources.sound);

        while (true)
        {
            Console.ReadLine();
        }


    }

    static void recognised(object sender, SpeechRecognizedEventArgs arg)
    {
        Console.WriteLine("Eeee");
        soundPlayer.Play();
    }
}
