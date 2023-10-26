Imports Microsoft.VisualBasic
Imports System.Net
Imports System.IO
Imports System.Xml

Public Class WeatherRSS
    Dim _visibility As String = String.Empty
    Dim _humidity As String = String.Empty
    Dim _location As String = String.Empty
    Dim _text As String = String.Empty
    Dim _code As String = String.Empty
    Dim _temp As String = String.Empty
    Dim _hi As String = String.Empty
    Dim _lo As String = String.Empty
    Dim _text2 As String = String.Empty
    Dim _code2 As String = String.Empty
    Dim _hi2 As String = String.Empty
    Dim _lo2 As String = String.Empty

    Public Sub WeatherRSS()

    End Sub

    Property Visibility() As String
        Get
            Return _visibility
        End Get
        Set(ByVal value As String)
            _visibility = value
        End Set
    End Property

    Property Humidity() As String
        Get
            Return _humidity
        End Get
        Set(ByVal value As String)
            _humidity = value
        End Set
    End Property

    Property Location() As String
        Get
            Return _location
        End Get
        Set(ByVal value As String)
            _location = value
        End Set
    End Property

    Property TodayConditionText() As String
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            _text = value
        End Set
    End Property

    Property TodayConditionCode() As String
        Get
            Return _code
        End Get
        Set(ByVal value As String)
            _code = value
        End Set
    End Property

    Property TodayConditionTemp() As String
        Get
            Return _temp
        End Get
        Set(ByVal value As String)
            _temp = value
        End Set
    End Property

    Property TodayConditionHi() As String
        Get
            Return _hi
        End Get
        Set(ByVal value As String)
            _hi = value
        End Set
    End Property

    Property TodayConditionLo() As String
        Get
            Return _lo
        End Get
        Set(ByVal value As String)
            _lo = value
        End Set
    End Property

    Property TomorrowConditionText() As String
        Get
            Return _text2
        End Get
        Set(ByVal value As String)
            _text2 = value
        End Set
    End Property

    Property TomorrowConditionCode() As String
        Get
            Return _code2
        End Get
        Set(ByVal value As String)
            _code2 = value
        End Set
    End Property

    Property TomorrowConditionHi() As String
        Get
            Return _hi2
        End Get
        Set(ByVal value As String)
            _hi2 = value
        End Set
    End Property

    Property TomorrowConditionLo() As String
        Get
            Return _lo2
        End Get
        Set(ByVal value As String)
            _lo2 = value
        End Set
    End Property

    Public Shared Function GetWeatherInfo(ByVal zipCode As String) As WeatherRSS

        Dim weatherInfo As WeatherRSS = New WeatherRSS

        Try
            Dim weatherRssUrl As String = "http://xml.weather.yahoo.com/forecastrss?p=" & zipCode

            Dim myClient As WebClient = New WebClient
            Dim response As Stream = myClient.OpenRead(weatherRssUrl)

            Dim xmlData As XmlDocument = New XmlDocument
            xmlData.Load(response)

            response.Close()

            Dim channelNode As XmlNode = xmlData.DocumentElement.FirstChild

            Dim locNode As XmlNode = channelNode("yweather:location")
            If Not locNode Is Nothing Then
                Try
                    weatherInfo.Location = locNode.Attributes("city").Value & ", " & locNode.Attributes("region").Value
                Catch ex As Exception

                End Try
            End If
            '=========
            Dim AtmosphereNode As XmlNode = channelNode("yweather:atmosphere")
            If Not AtmosphereNode Is Nothing Then
                Try
                    weatherInfo.Humidity = AtmosphereNode.Attributes("humidity").Value
                    weatherInfo.Visibility = AtmosphereNode.Attributes("visibility").Value
                Catch ex As Exception

                End Try
            End If
            '=============

            Dim itemNode As XmlElement = channelNode("item")

            If Not itemNode Is Nothing Then
                Try
                    Dim condition As XmlNodeList = itemNode.GetElementsByTagName("yweather:condition")
                    weatherInfo.TodayConditionTemp = condition(0).Attributes("temp").Value
                    weatherInfo.TodayConditionText = condition(0).Attributes("text").Value
                    weatherInfo.TodayConditionCode = condition(0).Attributes("code").Value

                    Dim forecast As XmlNodeList = itemNode.GetElementsByTagName("yweather:forecast")
                    If Not forecast(0) Is Nothing Then
                        weatherInfo.TodayConditionHi = forecast(0).Attributes("high").Value
                        weatherInfo.TodayConditionLo = forecast(0).Attributes("low").Value
                    End If
                    If Not forecast(1) Is Nothing Then
                        weatherInfo.TomorrowConditionText = forecast(1).Attributes("text").Value
                        weatherInfo.TomorrowConditionCode = forecast(1).Attributes("code").Value
                        weatherInfo.TomorrowConditionHi = forecast(1).Attributes("high").Value
                        weatherInfo.TomorrowConditionLo = forecast(1).Attributes("low").Value
                    End If
                Catch ex As Exception

                End Try
            End If

        Catch ex As Exception

        End Try

        Return weatherInfo

    End Function
End Class
