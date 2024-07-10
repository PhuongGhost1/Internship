import axios from "axios";

const ApiService = {
  getCourseByName: async (courseName) => {
    try {
      const response = await axios.post(
        "http://localhost:5144/api/v1/web/course/find-course",
        { courseName: courseName },
        {
          headers: {
            "Content-Type": "application/x-www-form-urlencoded",
          },
        }
      );
      return response.data;
    } catch (error) {
      console.error("Error fetching most purchased courses:", error);
      throw error;
    }
  },
  getMostPurchasedCourses: async () => {
    try {
      const response = await axios.get(
        "http://localhost:5144/api/v1/web/course/most-purchased-courses"
      );
      return response.data;
    } catch (error) {
      console.error("Error fetching most purchased courses:", error);
      throw error;
    }
  },
  getMonthlyExpenseAndRevenue: async () => {
    try {
      const response = await axios.get(
        "http://localhost:5144/api/v1/web/course/monthly-expense-revenue"
      );
      return response.data;
    } catch (error) {
      console.error("Error fetching monthly expense and revenue:", error);
      throw error;
    }
  },
  getTotalPricesForSingleMonthly: async () => {
    try {
      const response = await axios.get(
        "http://localhost:5144/api/v1/web/payment/total-prices-single-month"
      );
      return response.data;
    } catch (error) {
      console.error("Error fetching total prices monthly:", error);
      throw error;
    }
  },
  getPercentageChangeForCurrentMonthly: async () => {
    try {
      const response = await axios.get(
        "http://localhost:5144/api/v1/web/payment/get-current-monthly-changes"
      );
      return response.data;
    } catch (error) {
      console.error("Error fetching percentage monthly:", error);
      throw error;
    }
  },
  getTotalPricesForCurrentWeekly: async () => {
    try {
      const response = await axios.get(
        "http://localhost:5144/api/v1/web/payment/total-prices-single-week"
      );
      return response.data;
    } catch (error) {
      console.error("Error fetching monthly expense and revenue:", error);
      throw error;
    }
  },
  getPercentageChangeForCurrentWeekly: async () => {
    try {
      const response = await axios.get(
        "http://localhost:5144/api/v1/web/payment/get-current-weekly-changes"
      );
      return response.data;
    } catch (error) {
      console.error("Error fetching monthly expense and revenue:", error);
      throw error;
    }
  },
  getCountAccountsByStudentRoleForMonth: async () => {
    try {
      const response = await axios.get(
        "http://localhost:5144/api/v1/web/user/count-total-student-monthly"
      );
      return response.data;
    } catch (error) {
      console.error("Error fetching student account monthly:", error);
      throw error;
    }
  },
  getCountAccountsByInstructorForMonth: async () => {
    try {
      const response = await axios.get(
        "http://localhost:5144/api/v1/web/user/count-total-instructor-monthly"
      );
      return response.data;
    } catch (error) {
      console.error("Error fetching instructor account monthly:", error);
      throw error;
    }
  },
  getPercentageChangeForInstructorAccountsLastMonth: async () => {
    try {
      const response = await axios.get(
        "http://localhost:5144/api/v1/web/user/get-instructor-percentage-changes-monthly"
      );
      return response.data;
    } catch (error) {
      console.error(
        "Error fetching percentage instructor account monthly:",
        error
      );
      throw error;
    }
  },
  getPercentageChangeForStudentAccountsLastMonth: async () => {
    try {
      const response = await axios.get(
        "http://localhost:5144/api/v1/web/user/get-student-percentage-changes-monthly"
      );
      return response.data;
    } catch (error) {
      console.error(
        "Error fetching percentage student account monthly:",
        error
      );
      throw error;
    }
  },
  getInstructors: async () => {
    try {
      const response = await axios.get(
        "http://localhost:5144/api/v1/web/user/get-instructors"
      );
      return response.data;
    } catch (error) {
      console.error("Error fetching get instructors info:", error);
      throw error;
    }
  },
  updateStatusInstructors: async (userId) => {
    try {
      const formData = new FormData();
      formData.append("userId", userId);

      const response = await axios.put(
        `http://localhost:5144/api/v1/web/user/update-user-status`,
        formData,
        {
          headers: {
            "Content-Type": "application/x-www-form-urlencoded",
          },
        }
      );

      return response.data; // Assuming response.data is the updated status or success indicator
    } catch (error) {
      console.error("Error updating status:", error);
      throw error;
    }
  },
  getStudents: async () => {
    try {
      const response = await axios.get(
        "http://localhost:5144/api/v1/web/user/get-students"
      );
      return response.data;
    } catch (error) {
      console.error("Error fetching get students info:", error);
      throw error;
    }
  },
};

export default ApiService;
