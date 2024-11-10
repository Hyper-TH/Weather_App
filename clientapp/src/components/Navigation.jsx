import { Link } from 'react-router-dom';

const Navigation = () => { 
    return (
        <>
            <h2 className="sub_title">
                User Login in the future
            </h2>

            <Link to="/weather" className="btn_collection_top">
                See the weather today
            </Link>

            <Link to="/products" className="btn_collection_middle">
                See the list of products
            </Link>

            <Link to="/datetime" className="btn_collection_bottom">
                See the date and time today
            </Link>
        </>
    );
}

export default Navigation;