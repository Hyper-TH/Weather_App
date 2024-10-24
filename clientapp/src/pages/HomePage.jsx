import { Link, useNavigate } from 'react-router-dom';
import '../styles/home.css';

const HomePage = () => {
    const navigate = useNavigate();
    const content = (() => {
        <>
            <h2 className="sub_title">
                User Login in the future
            </h2>

            <Link to="/weather" className="btn_collection_top">
                See the weather today
            </Link>

            <Link to="/products" className="btn_collection_bottom">
                See the list of products
            </Link>
        </>
    })

    return (
        <>
            <section className="main_container">
                <div className="sub_container">
                    <h1 className="main_title">
                        This is a web app
                    </h1>
                </div>

                <div className="home_container">
                    {content}
                </div>
            </section>
        </>
    )
}

export default HomePage;