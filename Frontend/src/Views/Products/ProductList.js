import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './ProductList.css';
import Navbar from '../Reusables/NavBar';

function ProductList() {
    const [products, setProducts] = useState([]);
    const [currentPage, setCurrentPage] = useState(1);
    const [mostExpensive, setMostExpensive] = useState({});
    const [cheapest, setCheapest] = useState({});
    const [productsPerPage] = useState(9);

    useEffect(() => {
        const fetchProducts = async () => {
            const res = await axios.get('https://localhost:44386/Api/Pakaian/GetPakaian');
            setProducts(res.data);
        };

        fetchProducts();
        const fetchData = async () => {
            const mostExpensiveData = await axios.get('https://localhost:44386/Api/Pakaian/GetPakaianOrderByPrice?urutan=DESC');
            setMostExpensive(mostExpensiveData.data);

            const cheapestData = await axios.get('https://localhost:44386/Api/Pakaian/GetPakaianOrderByPrice?urutan=ASC');
            setCheapest(cheapestData.data);

            console.log(mostExpensiveData.data, cheapestData.data)

        };
        fetchData();
        console.log(mostExpensive, cheapest)
    }, []);

    const indexOfLastProduct = currentPage * productsPerPage;
    const indexOfFirstProduct = indexOfLastProduct - productsPerPage;
    const currentProducts = products.slice(indexOfFirstProduct, indexOfLastProduct);

    const paginate = (pageNumber) => setCurrentPage(pageNumber);

    const pageNumbers = [];
    for (let i = 1; i <= Math.ceil(products.length / productsPerPage); i++) {
        pageNumbers.push(i);
    }

    return (
        <div className="home">
            <Navbar />
            <div>
                <div class="product-info">
                    <h3>Most Expensive Product:</h3>
                    <img style={{ maxHeight: '200px' }} src={mostExpensive.image} alt={mostExpensive.nama} />
                    <p><strong>{mostExpensive.nama}</strong></p>
                    <p>Rp. {mostExpensive.harga}</p>
                </div>

                <div class="product-info">
                    <h3>Cheapest Product:</h3>
                    <img style={{ maxHeight: '200px' }} src={cheapest.image} alt={cheapest.nama} />
                    <p><strong>{cheapest.nama}</strong></p>
                    <p>Rp. {cheapest.harga}</p>
                </div>
            </div>
            <div className="product-list">
                {currentProducts.map((product, index) => (
                    <div className="product" key={product.pakaianID}>
                        <img src={product.image} alt={product.nama} />
                        <h3>{product.nama}</h3>
                        <p>Rp. {product.harga},- </p>
                    </div>
                ))}
                <ul className="pagination">
                    {pageNumbers.map((number) => (
                        <li key={number}>
                            <a onClick={() => paginate(number)} href="#">
                                {number}
                            </a>
                        </li>
                    ))}
                </ul>
            </div>
        </div>
    );
}

export default ProductList;
