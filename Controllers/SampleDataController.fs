namespace ReactFS.Controllers

open System
open System.Linq
open Microsoft.AspNetCore.Mvc
open ReactFS.Models
open System.Data.SQLite
open System.Data.Common
open Microsoft.Extensions.Configuration

[<Route("api/[controller]")>]
type SampleDataController (config: IConfiguration) = 
    inherit Controller()
    member val configurations = config //To acquire databse conneciton string saved in appsettings.json, you can access this.configurations.GetConnectionString("[Name]")
    static member val Summaries : string[] = [| "Freezing"; "Bracing"; "Chilly"; "Cool"; "Mild"; "Warm"; "Balmy"; "Hot"; "Sweltering"; "Scorching" |]

    [<HttpGet("[action]")>]
    member this.WeatherForecasts () = 
        let rng = new Random()
            
        Enumerable.Range(1, 5).Select(fun index -> 
            new WeatherForcastModel(DateFormatted = DateTime.Now.AddDays(float index).ToString("d"), TemperatureC = rng.Next(-20, 55), Summary = SampleDataController.Summaries.[rng.Next(SampleDataController.Summaries.Length)])
        )