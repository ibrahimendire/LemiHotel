#pragma checksum "C:\Users\ibrah\OneDrive\Desktop\Proj\LemiHotel\HotelBookingSystem\HotelBookingSystem\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1a6fecf2bf7fe6176891398018d51f75dc2e2262"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\ibrah\OneDrive\Desktop\Proj\LemiHotel\HotelBookingSystem\HotelBookingSystem\Views\_ViewImports.cshtml"
using HotelBookingSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ibrah\OneDrive\Desktop\Proj\LemiHotel\HotelBookingSystem\HotelBookingSystem\Views\_ViewImports.cshtml"
using HotelBookingSystem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a6fecf2bf7fe6176891398018d51f75dc2e2262", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a64d3b98617441fb562a585d3b117d81a2f5ba6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"


<div class=""text-center"">
    <div class=""welcome"">
        <h1>WELCOME TO LEMI HOTEL </h1> 
        <section>
            <table class=""table table-success table-striped"">
                <thead>
                    <tr>
                        <th>Current Date/Time</th>
                        <th>Temperature</th>
                        <th>Condition</th>
                        <th>Location</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td><span id=""datetime""></span></td>
                        <td><span id=""temperature""></span></td>
                        <td><span id=""description""></span></td>
                        <td><span id=""location""></span></td>
                    </tr>
                </tbody>
           
            </table>
            
        </section>
    <div></div>
    </div>

    
    <style>
            body {
                background-image: url(""https://i.ibb.c");
            WriteLiteral(@"o/4jxL4xB/pool-png.jpg"");
                background-color: #cccccc; /* Used if the image is unavailable */
                height: 500px; /* You must set a specified height */
                background-position: center; /* Center the image */
                background-repeat: no-repeat; /* Do not repeat the image */
                background-size: cover;
            }

            .welcome {
                background-color: ghostwhite;
            }

         table {

  background-color: green;

  animation-name: info;
  animation-duration: 10s;
  animation-iteration-count: 100;
  animation-direction: alternate;
}

");
            WriteLiteral(@"@keyframes info {
  0%   {background-color:white; left:0px; top:0px;}
  25%  {background-color:gold; left:200px; top:0px;}
  50%  {background-color:darkseagreen; left:200px; top:200px;}
  75%  {background-color:lightyellow; left:0px; top:200px;}
  100% {background-color:slategrey; left:0px; top:0px;}
}


    </style>


        <script>
            var dt = new Date();
            document.getElementById(""datetime"").innerHTML = dt.toLocaleString();



            function getWeather() {
                let temperature = document.getElementById(""temperature"");
                let description = document.getElementById(""description"");
                let location = document.getElementById(""location"");
            }

            let api = ""https://api.openweathermap.org/data/2.5/weather"";
            let apiKey = ""a7ae6cc41f4418017387af627bf49aaa"";


            navigator.geolocation.getCurrentPosition(success, error);


            function success(position) {
                conso");
            WriteLiteral(@"le.log(position);
            }

            function error() {
                console.log(""error"");
            }


            getWeather()


            latitude = position.coords.latitude;
            longitude = position.coords.longitude;

            let url =
                api +
                ""?lat="" +
                latitude +
                ""&lon="" +
                longitude +
                ""&appid="" +
                apiKey +
                ""&units=imperial"";

            fetch(url)
                .then(response => response.json())
                .then(data => {
                    console.log(data);
                    let temp = data.main.temp;
                    temperature.innerHTML = temp + ""° F"";
                    location.innerHTML =
                        data.name ");
            WriteLiteral(@"
                    description.innerHTML = data.weather[0].main;
                });


            function getWeather() {
                let temperature = document.getElementById(""temperature"");
                let description = document.getElementById(""description"");
                let location = document.getElementById(""location"");

                let api = ""https://api.openweathermap.org/data/2.5/weather"";
                let apiKey = ""f146799a557e8ab658304c1b30cc3cfd"";

                location.innerHTML = ""Locating..."";

                navigator.geolocation.getCurrentPosition(success, error);

                function success(position) {
                    latitude = position.coords.latitude;
                    longitude = position.coords.longitude;

                    let url =
                        api +
                        ""?lat="" +
                        latitude +
                        ""&lon="" +
                        longitude +
                       ");
            WriteLiteral(@" ""&appid="" +
                        apiKey +
                        ""&units=imperial"";

                    fetch(url)
                        .then(response => response.json())
                        .then(data => {
                            console.log(data);
                            let temp = data.main.temp;
                            temperature.innerHTML = temp + ""° F"";
                            location.innerHTML =
                                data.name ");
            WriteLiteral(@"
                            description.innerHTML = data.weather[0].main;
                        });
                }

                function error() {
                    location.innerHTML = ""Unable to retrieve your location"";
                }
            }

            getWeather();
        </script>
    

</div>
");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
