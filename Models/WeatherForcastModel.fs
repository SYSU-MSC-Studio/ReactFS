namespace ReactFS.Models

type WeatherForcastModel public () =
    member val public DateFormatted : string = null with get, set
    member val public TemperatureC : int = 0 with get, set
    member val public Summary : string = null with get, set
    member public this.TemperatureF with get () = 32 + (int ((float this.TemperatureC) / 0.5556))
