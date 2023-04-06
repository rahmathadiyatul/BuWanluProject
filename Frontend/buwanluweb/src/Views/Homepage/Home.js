import React, { useState, useEffect } from 'react';
import Navbar from '../Reusables/NavBar';
import TopSpenders from '../Dashboard/TopSpenders';
import TopClothingSales from '../Dashboard/TopClothingSales';
import SalesGrowthChart from '../Dashboard/SalesGrowthChart';
import './Home.css';

function HomePage() {
    const [showCharts, setShowCharts] = useState(false);
    const [revenueMedan, setRevenueMedan] = useState(null);
    const [revenueJakarta, setRevenueJakarta] = useState(null);

    const toggleCharts = () => {
        setShowCharts(!showCharts);
    }

    useEffect(() => {
        fetch('https://localhost:44386/Api/Penjualan/GetRevenueByYear?cabang=Medan')
            .then(response => response.json())
            .then(data => setRevenueMedan(data))
            .catch(error => console.error(error));
        fetch('https://localhost:44386/Api/Penjualan/GetRevenueByYear?cabang=Jakarta')
            .then(response => response.json())
            .then(data => setRevenueJakarta(data))
            .catch(error => console.error(error));
    }, []);


    return (
        <div className="home">
            <Navbar />
            <h1>Selamat Datang Bu Wanlu</h1>
            <div className='dashboards'>
                <div className='dashboards-total'>
                    {revenueMedan && (
                        <div className="revenue">
                            <h2>Total Revenue for Medan branch in 2023</h2>
                            <p>Nominal Penjualan: Rp {revenueMedan},-</p>
                        </div>
                    )}
                    {revenueJakarta && (
                        <div className="revenue">
                            <h2>Total Revenue for Jakarta branch in 2023</h2>
                            <p>Nominal Penjualan: Rp {revenueJakarta},-</p>
                        </div>
                    )}
                </div>
                <div className='dashboards-charts'>
                    <p>Klik tombol berikut untuk melihat data dashboard Butik Bu Wanlu</p>
                    <button onClick={toggleCharts}>
                        {showCharts ? "Hide Charts" : "Show Charts"}
                    </button>
                    {showCharts && (
                        <>
                            <div>
                                <SalesGrowthChart />
                                <TopClothingSales cabang="Medan" />
                                <TopClothingSales cabang="Jakarta" />
                                <TopSpenders cabang="Medan" />
                                <TopSpenders cabang="Jakarta" />
                            </div>
                        </>
                    )}
                </div>
            </div>
        </div>
    );
}

export default HomePage;
