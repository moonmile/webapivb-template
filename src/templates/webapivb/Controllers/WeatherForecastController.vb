Imports Microsoft.AspNetCore.Mvc
Imports Microsoft.Extensions.Logging

Namespace Controllers
    <ApiController>
    <Route("[controller]")>
    Public Class WeatherForecastController
        Inherits ControllerBase

        Private Shared ReadOnly Summaries() As String =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        }
        Private ReadOnly _logger As ILogger(Of WeatherForecastController)


        Sub New(logger As ILogger(Of WeatherForecastController))
            Me._logger = logger
        End Sub

        <HttpGet(Name:="GetWeatherForecast")>
        Public Function [Get]() As IEnumerable(Of WeatherForecast)
            Return Enumerable.Range(1, 5).Select(
                Function(index)
                    Return New WeatherForecast With
                        {
                            .Date = DateTime.Now.AddDays(index),
                            .TemperatureC = Random.Shared.Next(-20, 55),
                            .Summary = Summaries(Random.Shared.Next(Summaries.Length))
                        }
                End Function)
        End Function
    End Class
End Namespace


