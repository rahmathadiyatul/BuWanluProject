import React from 'react';
import { Link } from 'react-router-dom';
import './NavBar.css';

function Navbar() {
    return (
        <nav>
            <ul>
                <li>
                    <Link to="/">Dashboard</Link>
                </li>
                <li>
                    <Link to="/products">Our Products</Link>
                </li>
                <li>
                    <Link to="/customers">Our Customers</Link>
                </li>
            </ul>
        </nav>
    );
}

export default Navbar;
