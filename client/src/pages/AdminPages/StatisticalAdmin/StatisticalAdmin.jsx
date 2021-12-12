import React from "react";
import { useState } from "react";
import { useDispatch, useSelector } from 'react-redux'
import AdminStatisticalControl from "../../../components/AdminComponents/AdminStatisticalComponent/AdminStatisticalControl";
import { Chart as ChartJS } from 'chart.js/auto'
import { Chart } from 'react-chartjs-2'
import { useCallback } from "react";
import { useEffect } from "react";
import { actDoanhThuMonthAdmin, actDoanhThuYearAdmin } from "../../../redux/actions/AdminStatisticalAction";

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

const initialChartData1 = {
    labels: ['Boston', 'Worcester', 'Springfield', 'Lowell'],
    datasets: [
        {
            label: 'Population',
            data: [
                10000,
                181045,
                153060,
                106519,
            ],
            backgroundColor: [
                'rgba(255, 99, 132, 0.6)',
                'rgba(54, 162, 235, 0.6)',
                'rgba(255, 206, 86, 0.6)',
                'rgba(75, 192, 192, 0.6)',
                'rgba(140, 99, 132, 0.6)'
            ]
        }
    ]
}

function StatisticalAdmin() {

    const AdminStatisticalReducer = useSelector(state => state.AdminStatisticalReducer);

    const [title, setTitle] = useState("Thống kê");
    const [data, setData] = useState(initialChartData)
    const [elmContentPie, setElmContentPie] = useState(null)
    const [elmContentBar, setElmContentBar] = useState(null)
    const [elmContentLine, setElmContentLine] = useState(null)

    // const [yearData, setYearData] = useState()
    const [selectOption, setSelectOption] = useState('doanhthu-year')

    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(actDoanhThuYearAdmin({ begin: 1900, end: new Date().getFullYear() }));
    }, [dispatch])

    useEffect(() => {
        // switch (selectOption) {
        //     case 'doanhthu-year':
        //         if (AdminStatisticalReducer.labels) {
        //             setElmContentPie(<Chart
        //                 type="pie"
        //                 data={AdminStatisticalReducer}
        //             />);
        //             setElmContentBar(<Chart
        //                 type="bar"
        //                 data={AdminStatisticalReducer}
        //             />);
        //             setElmContentLine(<Chart
        //                 type="line"
        //                 data={AdminStatisticalReducer}
        //             />);
        //         }
        //         else {
        //             setElmContentPie(null);
        //             setElmContentBar(null);
        //             setElmContentLine(null);
        //         }
        //         break;
        //     default:
        //         break;
        // }
        if(AdminStatisticalReducer.labels) {
            setElmContentPie(<Chart
                type="pie"
                data={AdminStatisticalReducer}
            />);
            setElmContentBar(<Chart
                type="bar"
                data={AdminStatisticalReducer}
            />);
            setElmContentLine(<Chart
                type="line"
                data={AdminStatisticalReducer}
            />);
        }
        
    }, [AdminStatisticalReducer])

    const submitLoc = (data) => {
        // console.log(selectOption)
        switch (selectOption) {
            case 'doanhthu-year':
                dispatch(actDoanhThuYearAdmin(data))
                break;
            case 'doanhthu-month':
                dispatch(actDoanhThuMonthAdmin(data))
                break;
            default:
                break;
        }
    }

    return (
        <div>
            <div>
                <h3 className="text-center mt-2">{title}</h3>
                <hr />
            </div>

            <AdminStatisticalControl submitLoc={submitLoc} selectOption={selectOption} setSelectOption={setSelectOption} />
            <div className="chart">
                {elmContentBar}

                <div className="row mt-5">
                    <div className="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                        {elmContentLine}
                    </div>
                    <div className="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                        {/* <Chart
                            type="pie"
                            data={data}
                            options={{
                                title: {
                                    display: true,
                                    text: "Largest",
                                    fontSize: 25
                                },
                                legend: {
                                    display: true,
                                    position: "right"
                                }
                            }}
                        /> */}
                        {elmContentPie}
                    </div>
                </div>



            </div>
        </div>
    );
}

export default StatisticalAdmin;
