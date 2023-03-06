

using Newtonsoft.Json.Linq;
using System.Diagnostics.Metrics;
using static System.Net.WebRequestMethods;

var client = new HttpClient();

var key = "cb57886fcc30746ab84a3f5ecb190e4c";
var city = "Birmingham";

Console.WriteLine("Hi, would you like to know the weather in your area?");
Console.WriteLine("Yes or No");
var answer1 = Console.ReadLine();


if (answer1 == "Yes")
{
    Console.WriteLine("Please enter your ZIP Code.");
    var zipCode = int.Parse(Console.ReadLine());

    var weatherZIP = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCode},us&units=imperial&appid={key}";
    var response = client.GetStringAsync(weatherZIP).Result;
    var formattedResponse = JObject.Parse(response).GetValue("main");

    Console.WriteLine($"The weather for your area is {formattedResponse}");

    Console.WriteLine("Would you like to check a different city?");
    Console.WriteLine("Yes or No");
    var answer2 = Console.ReadLine();
    while (answer2 == "Yes")
    {
        Console.WriteLine("Please enter a new ZIP Code.");
        zipCode = int.Parse(Console.ReadLine());

        weatherZIP = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCode},us&units=imperial&appid={key}";
        response = client.GetStringAsync(weatherZIP).Result;
        formattedResponse = JObject.Parse(response).GetValue("main");

        Console.WriteLine($"The weather for that area is {formattedResponse}");
        Console.WriteLine("Would you like to check a different city?");
        answer2 = Console.ReadLine();
    }

}
else
{
    Console.WriteLine("Ok have a nice day.");
}

    Console.WriteLine("Ok have a nice day.");


//var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=imperial&appid={key}";
//var response = client.GetStringAsync(weatherURL).Result;

//var formattedResponse = JObject.Parse(response).GetValue("main");



//var temp = formattedResponse["list"][0]["main"]["temp"];


//Console.WriteLine(formattedResponse);


