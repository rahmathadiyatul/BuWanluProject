import { useState, useEffect } from 'react';
import './CustomerList.css';
import Navbar from '../Reusables/NavBar';

function CustomerList() {
    const [customerList, setCustomerList] = useState([]);
    const [earliestCustomer, setEarliestCustomer] = useState(null);
    const [latestCustomer, setLatestCustomer] = useState(null);

    useEffect(() => {
        fetch('https://localhost:44386/Api/Pelanggan/GetPelanggan')
            .then(response => response.json())
            .then(data => {
                setCustomerList(data);
                setEarliestCustomer(data.reduce((prev, current) => prev.tanggalBergabung < current.tanggalBergabung ? prev : current));
                setLatestCustomer(data.reduce((prev, current) => prev.tanggalBergabung > current.tanggalBergabung ? prev : current));
            });
    }, []);

    return (
        <div className='home'>
            <Navbar />
            <div style={{ display: 'flex', flexWrap: 'wrap' }}>
                <div style={{ border: '1px solid #ccc', padding: '10px', margin: '10px', width: '200px' }}>
                    <h2>Earliest Registered Customer</h2>
                    {earliestCustomer ? (
                        <>
                            <p>{earliestCustomer.nama}</p>
                            <p>Tanggal Bergabung: {new Date(earliestCustomer.tanggalBergabung).toLocaleDateString()}</p>
                            <p>Cabang: {earliestCustomer.cabang}</p>
                        </>
                    ) : (
                        <p>No customer data found</p>
                    )}
                </div>
                <div style={{ border: '1px solid #ccc', padding: '10px', margin: '10px', width: '200px' }}>
                    <h2>Latest Registered Customer</h2>
                    {latestCustomer ? (
                        <>
                            <p>{latestCustomer.nama}</p>
                            <p>Tanggal Bergabung: {new Date(latestCustomer.tanggalBergabung).toLocaleDateString()}</p>
                            <p>Cabang: {latestCustomer.cabang}</p>
                        </>
                    ) : (
                        <p>No customer data found</p>
                    )}
                </div>
            </div>
            <div style={{ display: 'flex', flexWrap: 'wrap' }}>
                {customerList.map(pelanggan => (
                    <div key={pelanggan.pelangganID} style={{ border: '1px solid #ccc', padding: '10px', margin: '10px', width: '200px' }}>
                        <h2>{pelanggan.nama}</h2>
                        <p>Tanggal Bergabung: {new Date(pelanggan.tanggalBergabung).toLocaleDateString()}</p>
                        <p>Cabang: {pelanggan.cabang}</p>
                    </div>
                ))}
            </div>
        </div>
    );
}

export default CustomerList;
