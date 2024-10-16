import React, { useEffect, useState } from 'react';

function Weather() {
    const [weatherData, setWeatherData] = useState([]);

    useEffect(() => {
        // Fetch data from the ASP.NET Core Web API
        fetch('http://localhost:5076/WeatherForecast') // Adjust the URL if needed
            .then(res => res.json())
            .then(data => setWeatherData(data))
            .catch(err => console.error('Error fetching weather data:', err));
    }, []);

    return (
        <div>
            <h1>Weather Forecast</h1>
            {weatherData.length > 0 ? (
                <table>
                    <thead>
                        <tr>
                            <th>Date</th>
                            <th>Temperature (C)</th>
                            <th>Summary</th>
                        </tr>
                    </thead>

                    <tbody>
                        {weatherData.map((weather, index) => (
                            <tr key={index}>
                                <td>{weather.date}</td>
                                <td>{weather.temperatureC} °C</td>
                                <td>{weather.summary}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            ) : (
                <p>Loading weather data...</p>
            )}
        </div>
    )
}
export default Weather;