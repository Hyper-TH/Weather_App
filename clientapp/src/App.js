import './App.css';
import { Routes, Route } from 'react-router-dom';
import { HomePage, WeatherPage } from './RouteImports.js';

function App() {
    return (
        <div className="App">
            <header className="App-header">
                <h1>Hi there</h1>

                <Routes>
                    <Route path="/" element={<HomePage />} />
                    <Route
                        path="/weather"
                        element={<WeatherPage backTo="/"/>} />
                    {/*<Route*/}
                    {/*    path="/products"*/}
                    {/*    element={<ProductsPage backTo="/" />}*/}
                    {/*/>*/}
                </Routes>
            </header>
        </div>
    );
}

export default App;
