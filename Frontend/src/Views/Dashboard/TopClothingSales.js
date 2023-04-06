import React, { useState, useEffect } from 'react';
import { BarChart, Bar, XAxis, YAxis, CartesianGrid, Tooltip, Legend } from 'recharts';
import './TopClothingSales.css';

function TopClothingSales({ cabang }) {
    const [data, setData] = useState([]);
    const [bulan, setBulan] = useState(3);

    useEffect(() => {
        fetch(`https://localhost:44386/Api/Penjualan/GetTopPenjualanPakaian?cabang=${cabang}&bulan=${bulan}`)
            .then(response => response.json())
            .then(data => setData(data))
            .catch(error => console.error(error));
    }, [cabang, bulan]);

    return (
        <div className="top-clothing-sales">
            <h2>Top 10 Clothing Sales in {cabang}</h2>
            <select value={bulan} onChange={event => setBulan(event.target.value)}> // Use bulan state variable
                <option value={1}>January</option>
                <option value={2}>February</option>
                <option value={3}>March</option>
            </select>
            <div className="chart-container">
                <BarChart width={600} height={400} data={data}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis dataKey="namaPakaian" />
                    <YAxis />
                    <Tooltip />
                    <Legend />
                    <Bar dataKey="totalQty" fill="#8884d8" />
                </BarChart>
            </div>
        </div>
    );
}

export default TopClothingSales;
