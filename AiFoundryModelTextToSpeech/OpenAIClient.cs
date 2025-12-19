using OpenAI.Chat;
using Azure;
using Azure.AI.OpenAI;
using Azure.AI.OpenAI.Chat;
using Microsoft.Extensions.Configuration;
public class ChatBot
{
    public ChatBot(Uri endpoint, string deployment, string key)
    {
        modelEndpoint = endpoint;
        modelDeploymentName = deployment;
        modelKey = key;
    }
    Uri modelEndpoint;
    string modelDeploymentName;
    string modelKey;
    public string StartChat(string prompt)
    {
        AzureOpenAIClient azureClient = new(
    modelEndpoint,
    new AzureKeyCredential(modelKey));
        ChatClient chatClient = azureClient.GetChatClient(modelDeploymentName);

        // Support for this recently-launched model with MaxOutputTokenCount parameter requires
        // Azure.AI.OpenAI 2.2.0-beta.4 and SetNewMaxCompletionTokensPropertyEnabled
        var requestOptions = new ChatCompletionOptions()
        {
            MaxOutputTokenCount = 10000,
        };

        // The SetNewMaxCompletionTokensPropertyEnabled() method is an [Experimental] opt-in to use
        // the new max_completion_tokens JSON property instead of the legacy max_tokens property.
        // This extension method will be removed and unnecessary in a future service API version;
        // please disable the [Experimental] warning to acknowledge.
#pragma warning disable AOAI001
        requestOptions.SetNewMaxCompletionTokensPropertyEnabled(true);
#pragma warning restore AOAI001

        List<ChatMessage> messages = new List<ChatMessage>()
        {
            new SystemChatMessage("You are a helpful assistant that gives short responses that can easily be converted to speech using TTS."),
            new UserChatMessage(prompt),
        };

        var response = chatClient.CompleteChat(messages, requestOptions);
        return response.Value.Content[0].Text;
    }
}