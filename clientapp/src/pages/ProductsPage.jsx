import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { Product } from '../components/Product.js';
import ProductForm from '../components/ProductForm.js';

const ProductsPage = ({ backTo }) => {
    const [productsData, setProductsData] = useState([]);
    const [showForm, setShowForm] = useState(false);

    useEffect(() => {
        fetch('http://localhost:5076/api/ProductsFirestore')
            .then(res => res.json())
            .then(data => setProductsData(data))
            .catch(err => console.error('Error fetching products data', err));
    }, []);


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

                    <button onClick={() => setShowForm(!showForm)}>
                        Add Product
                    </button>

                    {showForm && <ProductForm />}

                </div>
            </section>
        </>
    )
}

export default ProductsPage;