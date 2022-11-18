
using HTTPPost;

using(var client = new HttpClient()) {
    var endpoint = new Uri("https://api.chucknorris.io/jokes/random");
    var result = client.GetAsync(endpoint).Result.Content.ReadAsStringAsync().Result;
    //Console.Write(result);
    dynamic json = JsonConvert.DeserializeObject(result);
    Console.WriteLine(json);
}

namespace HTTPPost {
    class JsonConvert {
        internal static dynamic DeserializeObject(string result) {
            throw new NotImplementedException();
        }
    }
}