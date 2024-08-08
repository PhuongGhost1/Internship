import React from "react";
import { LineChart } from '@mui/x-charts/LineChart';
import "./Transaction.css";
import { HiOutlineMinus } from "react-icons/hi";

export default function Transaction() {
     return (
          <div id="Transaction">
               <div className="header">
                    <h2> My transaction</h2>
                    <div className="Line">
                         <p><HiOutlineMinus className="increase" /> : <strong>Money received</strong> </p>
                         <p><HiOutlineMinus className="decrease" /> : <strong> Money paid</strong></p>
                    </div>

               </div>
               <LineChart
                    xAxis={[{ data: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12] }]}
                    series={[
                         {
                              data: [100, 50, 98, 52, 35, 30, 100, 50, 98, 52, 35, 30],
                         },
                         {
                              data: [70, 40, 68, 62, 30, 55, 30, 60, 40, 62, 30, 55],
                              color: "red"
                         }
                    ]}
                    height={300}
                    grid={{ vertical: true, horizontal: true }}
               />
          </div>
     );
}