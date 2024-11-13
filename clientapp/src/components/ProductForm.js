import { useState } from "react";

const ProductForm = () => {
    const [product, setProduct] = useState({
        productID: '',
        name: '',
        price: '',
    });
    const [error, setError] = useState("");


    const handleChange = (e) => {
        const { name, value } = e.target;

        setProduct((prevProduct) => ({
            ...prevProduct,
            [name]: value,
        }));
    };

    const addProduct = async () => {
        try {
            const res = await fetch('http://localhost:5076/api/ProductsFirestore', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    ProductID: parseInt(product.productID),
                    Name: product.name,
                    Price: parseFloat(product.price),
                }),
            });

            if (res.ok) {
                const result = await res.json();

                alert(result.message || 'Product added successfully');
            } else {
                alert('Failed to add product');
            }
        } catch (error) {
            console.error('Error:', error);
            setError(error);

            alert('Error adding product');
        }
    }

    return (
        <>
            <div className='sub_container'>
                <div className='add_product_form'>
                    <div className='add_product'>
                        <h1 className='add_product_title'>
                            Add New Product
                        </h1>

                        <form className='form'>
                            <div>
                                <label>Product ID</label>
                                <input
                                    type="number"
                                    name="productID"
                                    placeholder="Input ID here"
                                    value={product.productID}
                                    onChange={handleChange}
                                    required
                                />
                            </div>

                            <div>
                                <label>Product Name</label>
                                <input
                                    type="text"
                                    name="name"
                                    placeholder="Input name here"
                                    value={product.name}
                                    onChange={handleChange}
                                    required
                                />
                            </div>

                            <div>
                                <label>Product Price</label>
                                <input
                                    type="number"
                                    name="price"
                                    placeholder="Input price here"
                                    value={product.price}
                                    onChange={handleChange}
                                    required
                                />
                            </div>

                            <button className='submit' onClick={addProduct}>Submit</button>
                        </form>
                    </div>
                </div>

                {error &&
                    <div className='error'>
                        <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" className="w-6 h-6">
                            <path strokeLinecap="round" strokeLinejoin="round" d="M12 9v3.75m9-.75a9 9 0 1 1-18 0 9 9 0 0 1 18 0Zm-9 3.75h.008v.008H12v-.008Z" />
                        </svg>

                        <div>
                            <span className='font-medium'>{error}</span>
                        </div>
                    </div>
                }

            </div>
        </>
    )
}

export default ProductForm;