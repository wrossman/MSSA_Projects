using Microsoft.CognitiveServices.Speech;

class Speech
{
    public Speech(Uri endpoint, string apiKey)
    {
        speechEndpoint = endpoint;
        speechKey = apiKey;
    }
    string speechKey;
    Uri speechEndpoint;
    static void OutputSpeechSynthesisResult(SpeechSynthesisResult speechSynthesisResult, string text)
    {
        switch (speechSynthesisResult.Reason)
        {
            case ResultReason.SynthesizingAudioCompleted:
                Console.WriteLine($"Speech synthesized for text: [{text}]");
                break;
            case ResultReason.Canceled:
                var cancellation = SpeechSynthesisCancellationDetails.FromResult(speechSynthesisResult);
                Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                if (cancellation.Reason == CancellationReason.Error)
                {
                    Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                    Console.WriteLine($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                    Console.WriteLine($"CANCELED: Did you set the speech resource key and endpoint values?");
                }
                break;
            default:
                break;
        }
    }

    public async Task RunSpeech(string input)
    {
        var speechConfig = SpeechConfig.FromEndpoint(speechEndpoint, speechKey);

        // The neural multilingual voice can speak different languages based on the input text.
        speechConfig.SpeechSynthesisVoiceName = "en-US-Ava:DragonHDLatestNeural";

        using (var speechSynthesizer = new SpeechSynthesizer(speechConfig))
        {
            // Get text from the console and synthesize to the default speaker.
            var speechSynthesisResult = await speechSynthesizer.SpeakTextAsync(input);
            OutputSpeechSynthesisResult(speechSynthesisResult, input);
        }
    }
}