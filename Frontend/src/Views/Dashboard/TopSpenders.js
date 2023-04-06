import React, { useState, useEffect } from 'react';
import { BarChart, Bar, XAxis, YAxis, CartesianGrid, Tooltip, Legend } from 'recharts';
import './TopSpenders.css';

function TopSpenders(props) {
    const [topSpendersData, setTopSpendersData] = useState([]);
    const [bulan, setBulan] = useState(1);

    useEffect(() => {
        fetch(`https://localhost:44386/Api/Penjualan/GetTopSpenders?cabang=${props.cabang}&bulan=${bulan}`)
            .then(response => response.json())
            .then(data => setTopSpendersData(data))
            .catch(error => console.error(error));
    }, [props.cabang, bulan]);

    return (
        <div className="top-spenders">
            <h2>Top 10 Spenders in {props.cabang} in </h2>
            <select value={bulan} onChange={event => setBulan(event.target.value)}>
                <option value={1}>January</option>
                <option value={2}>February</option>
                <option value={3}>March</option>
            </select>
            <div className="chart-container">
                <BarChart width={600} height={400} data={topSpendersData}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis dataKey="namaPelanggan" />
                    <YAxis />
                    <Tooltip />
                    <Legend />
                    <Bar dataKey="totalPricePerPax" fill="#8884d8" />
                </BarChart>
            </div>
        </div>
    );
}

export default TopSpenders;
