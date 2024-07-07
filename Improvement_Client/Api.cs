using Improvement_API.db;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;
using System.Net.Http.Json;

namespace Improvement_Client
{
    public class Api
    {
        public const string APP_PATH = "http://localhost:44731";

        public static readonly HttpClient client = new HttpClient();
        public static string role = "";
        public static int? userId;

        public static async Task<Uri> CreateRoleAsync(Role role)
        {
            //     MessageBox.Show(role.Role_Name + " " + role.id_Role);
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/Roles", role);

            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }
        public static void SetBaseAddress(string address)
        {
            client.BaseAddress = new Uri(address);
        }

        public static async Task<Role> GetRoleAsync()
        {
            Role role = null;

            HttpResponseMessage response = await client.GetAsync("Api/Roles");
            if (response.IsSuccessStatusCode)
            {
                role = await response.Content.ReadAsAsync<Role>();
            }
            return role;
        }









        public static async Task<(string, string)> UserAuthAsync(string email, string password)
        {
            var values = new Dictionary<string, string>
        {
            { "Login", email },
            { "password", password }
        };
            var content = new FormUrlEncodedContent(values);
            HttpResponseMessage response = await client.PostAsync($"http://localhost:44731/token/?Login={email}&Password={password}", content);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonConvert.DeserializeObject<dynamic>(responseContent);
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
                userId = tokenResponse.idUser;
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.

                string token = tokenResponse.access_token;
                role = tokenResponse.role;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                return (token, role);
            }

            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new HttpRequestException("Unauthorized", null, response.StatusCode);
            }
            else
            {
                throw new HttpRequestException("Error", null, response.StatusCode);

            }
        }

    }
}
