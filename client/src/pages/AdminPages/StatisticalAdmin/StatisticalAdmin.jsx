import React from "react";
import { useState } from "react";
import AdminStatisticalControl from "../../../components/AdminComponents/AdminStatisticalComponent/AdminStatisticalControl";
import { Chart as ChartJS } from 'chart.js/auto'
import { Chart } from 'react-chartjs-2'

const initialChartData = {
    labels: ['Boston', 'Worcester', 'Springfield', 'Lowell', 'Cambridge', 'New Bedford'],
    datasets: [
        {
            label: 'Population',
            data: [
                10000,
                181045,
                153060,
                106519,
                105162,
                95072
            ],
            backgroundColor: [
                'rgba(255, 99, 132, 0.6)',
                'rgba(54, 162, 235, 0.6)',
                'rgba(255, 206, 86, 0.6)',
                'rgba(75, 192, 192, 0.6)',
                'rgba(153, 102, 255, 0.6)',
                'rgba(255, 159, 64, 0.6)',
                'rgba(140, 99, 132, 0.6)'
            ]
        }
    ]
}

function StatisticalAdmin() {
    const [title, setTitle] = useState("Thống kê");
    const [data, setData] = useState(initialChartData)

    return (
        <div>
            <div>
                <h3 className="text-center mt-2">{title}</h3>
                <hr />
            </div>

            <AdminStatisticalControl />
            <div className="chart">
                <Chart 
                    type="bar"
                    data={data} 
                    options={{
                        title: {
                            display : true,
                            text : "Largest",
                            fontSize : 25
                        },
                        legend : {
                            display : true,
                            position: "right"
                        }
                    }}
                    
                />
            </div>
        </div>
    );
}

export default StatisticalAdmin;
