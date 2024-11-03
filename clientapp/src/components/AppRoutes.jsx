import { Routes, Route } from 'react-router-dom';
import { HomePage, WeatherPage, ProductsPage, CurrentDatePage } from '../RouteImports.js';

const AppRoutes = () => (
    <Routes>
        <Route path="/" element={<HomePage />} />
        <Route
            path="/weather"
            element={<WeatherPage backTo="/" />} />
        <Route
            path="/products"
            element={<ProductsPage backTo="/" />}
        />
        <Route
            path="/datetime"
            element={<CurrentDatePage backTo="/" />}
        />
    </Routes>
)

export default AppRoutes;