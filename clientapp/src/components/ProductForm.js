import { useState } from "react";

const ProductForm = () => {
    const [name, setName] = useState("");
    const [price, setPrice] = useState(null);
    //const [prodID, setProdID] = useState(null);
    const [error, setError] = useState("");


    const handleSubmit = (e) => {
        e.preventDefault();
        setError("");

        try {
            console.log("Test");
        } catch (error) {
            console.log(error);
        }
    };

    return (
        <>
            <div className='sub_container'>
                <div className='add_product_form'>
                    <div className='add_product'>
                        <h1 className='add_product_title'>
                            Add New Product
                        </h1>

                        <form onSubmit={handleSubmit} className='form'>
                            <div>
                                <label>Product Name</label>
                                <input
                                    type="text"
                                    placeholder="Input name here"
                                    value={name}
                                    onChange={(e) => setName(e.target.value)}
                                    required
                                />
                            </div>

                            <div>
                                <label>Product Price</label>
                                <input
                                    type="number"
                                    placeholder="Input price here"
                                    value={price}
                                    onChange={(e) => setPrice(e.target.value)}
                                    required
                                />
                            </div>

                            <button className='submit'>Submit</button>
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