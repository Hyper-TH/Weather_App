import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { Weather } from '../components/Weather.js';
import '../styles/home.css';

const WeatherPage = ({ backTo }) => {
    const [weatherData, setWeatherData] = useState([]);

    useEffect(() => {
        // Fetch data from the ASP.NET Core Web API
        fetch('http://localhost:5076/WeatherForecast') // Adjust the URL if needed
            .then(res => res.json())
            .then(data => setWeatherData(data))
            .catch(err => console.error('Error fetching weather data:', err));
    }, []);

    console.log(weatherData[1]);

    return (
        <>
            <section className="main_container">
                <div className="sub_container">
                    <div className="sub_container_header">
                        <Link to={backTo}>
                            <button>
                                Go back
                            </button>
                        </Link>

                        <div className="main_title">
                            <h1>Weather Details</h1>
                        </div>
                    </div>

                    <div className="weather_details">
                        {weatherData.map((data) => {
                            return (
                                <Weather
                                    id={data.date}
                                    date={data.date}
                                    summary={data.summary}
                                    temperature={data.temperatureC}
                                />
                            )
                        })}
                    </div>
                </div>
            </section>
        </>
    )
}

export default WeatherPage;