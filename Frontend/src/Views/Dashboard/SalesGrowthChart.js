import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { BarChart, XAxis, YAxis, Tooltip, Legend, Bar } from 'recharts';
import "./SalesGrowthChart.css"

const SalesGrowthChart = () => {
    const [salesGrowthData, setSalesGrowthData] = useState([]);

    useEffect(() => {
        axios.get('https://localhost:44386/Api/Penjualan/GetSalesGrowth')
            .then(response => {
                setSalesGrowthData(response.data);
            })
            .catch(error => {
                console.log(error);
            });
    }, []);

    return (
        <div>
            <h2>Products with The Best Growth</h2>
            <BarChart width={600} height={300} data={salesGrowthData}>
                <XAxis dataKey="namaPakaian" />
                <YAxis />
                <Tooltip />
                <Legend />
                <Bar dataKey="qtyLastMonth" fill="#8884d8" name="Qty Last Month" />
                <Bar dataKey="qtyThisMonth" fill="#82ca9d" name="Qty This Month" />
            </BarChart>
        </div>
    );
};

export default SalesGrowthChart;
