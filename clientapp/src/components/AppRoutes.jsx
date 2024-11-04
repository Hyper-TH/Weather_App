import { Routes, Route } from 'react-router-dom';
import * as Pages from '../RouteImports.js';

const AppRoutes = () => (
    <Routes>
        <Route path="/" element={<Pages.HomePage />} />
        <Route
            path="/weather"
            element={<Pages.WeatherPage backTo="/" />} />
        <Route
            path="/products"
            element={<Pages.ProductsPage backTo="/" />}
        />
        <Route
            path="/datetime"
            element={<Pages.CurrentDatePage backTo="/" />}
        />
        <Route
            path="/calendar"
            element={<Pages.CalendarPage backTo="/" />}
        />
    </Routes>
)

export default AppRoutes;