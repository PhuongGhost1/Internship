import React, { useEffect, useState } from "react";
import ApiService from "../../../api/ApiService";
import "./Weekly.css";

const titles = [
  { title: "Monthly Income" },
  { title: "Weekly Income" },
  { title: "Student Accounts" },
  { title: "Instructor Accounts" },
];

export default function Weekly() {
  const [weeklyData, setWeeklyData] = useState([]);

  useEffect(() => {
    const fetchWeeklyData = async () => {
      try {
        const [
          totalMonthly,
          monthlyChanges,
          totalWeekly,
          weeklyChanges,
          totalStudents,
          studentChanges,
          totalInstructors,
          instructorChanges,
        ] = await Promise.all([
          ApiService.getTotalPricesForSingleMonthly(),
          ApiService.getPercentageChangeForCurrentMonthly(),
          ApiService.getTotalPricesForCurrentWeekly(),
          ApiService.getPercentageChangeForCurrentWeekly(),
          ApiService.getCountAccountsByStudentRoleForMonth(),
          ApiService.getPercentageChangeForStudentAccountsLastMonth(),
          ApiService.getCountAccountsByInstructorForMonth(),
          ApiService.getPercentageChangeForInstructorAccountsLastMonth(),
        ]);

        const newWeeklyData = [
          {
            ...titles[0],
            value: `$${totalMonthly}`,
            subtext: `${monthlyChanges}% vs last month`,
          },
          {
            ...titles[1],
            value: `$${totalWeekly}`,
            subtext: `${weeklyChanges}% vs last week`,
          },
          {
            ...titles[2],
            value: `${totalStudents}`,
            subtext: `${studentChanges}% higher than last month`,
          },
          {
            ...titles[3],
            value: `${totalInstructors}`,
            subtext: `${instructorChanges}% increase than last month`,
          },
        ];

        setWeeklyData(newWeeklyData);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };

    fetchWeeklyData();
  }, []);

  return (
    <div id="Weekly">
      {weeklyData.map((item, index) => (
        <div className="weekly-item" key={index}>
          <div className="weekly-title">{item.title}</div>
          <div className="weekly-value">{item.value}</div>
          <div className="weekly-subtext">{item.subtext}</div>
        </div>
      ))}
    </div>
  );
}
