import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { Product } from '../components/Product.js';

const ProductsPage = ({ backTo }) => {
    const [productsData, setProductsData] = useState([]);

    useEffect(() => {
        fetch('http://localhost:5076/api/ProductsFirestore')
            .then(res => res.json())
            .then(data => setProductsData(data))
            .catch(err => console.error('Error fetching products data', err));
    }, []);

    for (let i=0; i<= productsData.length; i++) {
        console.log(productsData[i]);
    }

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
                            <h1>Product Details</h1>
                        </div>
                    </div>

                    <div className="product_details">

                        {productsData.map((data, index) => (
                            <Product
                                id={data.id}
                                name={data.name}
                                price={data.price}
                            />
                        ))}

                    </div>
                </div>
            </section>
        </>
    )
}

export default ProductsPage;