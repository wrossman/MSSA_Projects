class Program
{
    public static async Task Main(string[] args)
    {

        var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

        var endpoint = config["Endpoint"];
        var modelKey = config["ModelKey"];
        var speechKey = config["SpeechKey"];

        if (modelKey is null || speechKey is null || endpoint is null)
        {
            System.Console.WriteLine("Failed to get keys from user-secrets.");
            return;
        }

        var modelEndpoint = new Uri(endpoint);
        var modelDeploymentName = "gpt-4o";
        var speechEndpoint = new Uri(endpoint);

        ChatBot chat = new(modelEndpoint, modelDeploymentName, modelKey);
        Speech speak = new(speechEndpoint, speechKey);

        string? prompt;
        do
        {
            Console.Clear();
            System.Console.WriteLine("Enter your prompt...");
            prompt = Console.ReadLine();
        } while (string.IsNullOrEmpty(prompt));

        string chatResponse = chat.StartChat(prompt);
        await speak.RunSpeech(chatResponse);
    }
}