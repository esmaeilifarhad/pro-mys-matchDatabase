using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Mys.DataAccess.Api
{
    public class SendEmailServiceApi
    {
        public async Task SendEmail() {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:9003/api/message/sendemail");

            var obj = new {
             body= "<table><tr><th>#</th><th>کار</th></tr><tr><td>1</td><td>چشم پزشکی</td></tr><tr><td>2</td><td>پاسپورت</td></tr></table>",
            subject= "کار",
             mailUserName= "کار"
            };
            var body= Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var content = new StringContent("", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }
}
