

namespace AiChatBot
{
    public class PromptService
    {
        // Create a static HttpClient instance for reuse
        private static readonly HttpClient _client = new HttpClient();

        public static async Task<HttpResponseMessage> GetImage(string prompt)
        {
            try
            {
                var data = new
                {
                    prompt = prompt,
                    negative_prompt = "ugly, tiling, poorly drawn hands, poorly drawn feet, poorly drawn face, out of frame, extra limbs, disfigured, deformed, body out of frame, blurry, bad anatomy, blurred, watermark, grainy, signature, cut off, draft",
                    style = "base",
                    samples = 1,
                    scheduler = "UniPC",
                    num_inference_steps = 25,
                    guidance_scale = 8,
                    strength = 0.2,
                    high_noise_fraction = 0.8,
                    seed = 468685,
                    img_width = 896,
                    img_height = 1152,
                    refiner = "yes",
                    base64 = false
                };

                // Validate URI
                string uri = "https://api.segmind.com/v1/sdxl1.0-txt2img";
                if (!Uri.IsWellFormedUriString(uri, UriKind.Absolute))
                {
                    throw new ArgumentException("Invalid URI format.");
                }

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(uri))
                {
                    Content = JsonContent.Create(data)
                };
                requestMessage.Headers.Add("x-api-key", "SG_5e5b72c1fbec964f");

                // Send the request and get response
                var response = await _client.SendAsync(requestMessage);
                
                // Check if the response is successful
                if (!response.IsSuccessStatusCode)
                {
                    // Log or handle error if needed
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
                throw; 
            }
        }
    }
}
