import React from 'react';
import { BarChart, Bar, XAxis, YAxis, CartesianGrid, Tooltip, Legend, ResponsiveContainer } from 'recharts';
import './Analytics.css';

const data = [
    { name: 'Jul 21', Expense: 4000, Revenue: 2400 },
    { name: 'Aug 21', Expense: 3000, Revenue: 1398 },
    { name: 'Sep 21', Expense: 2000, Revenue: 9800 },
    { name: 'Oct 21', Expense: 2780, Revenue: 3908 },
    { name: 'Nov 21', Expense: 1890, Revenue: 4800 },
    { name: 'Dec 21', Expense: 2390, Revenue: 3800 },
    { name: 'Jan 22', Expense: 3490, Revenue: 4300 },
    { name: 'Feb 22', Expense: 2000, Revenue: 9800 },
    { name: 'Mar 22', Expense: 2780, Revenue: 3908 },
];

export default function Analytics() {
    return (
        <div id="Analytics">
            <h2>Analytics</h2>
            <ResponsiveContainer width="100%" height={300}>
                <BarChart
                    data={data}
                    margin={{ top: 20, right: 30, left: 20, bottom: 5 }}
                >
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis dataKey="name" />
                    <YAxis />
                    <Tooltip />
                    <Legend />
                    <Bar dataKey="Expense" fill="#8884d8" />
                    <Bar dataKey="Revenue" fill="#ff7300" />
                </BarChart>
            </ResponsiveContainer>
        </div>
    );
}
