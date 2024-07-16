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
  getCourseManagementByAdmin: async () => {
    try {
      const response = await axios.get(
        "http://localhost:5144/api/v1/web/course/manage-courses"
      );
      return response.data;
    } catch (error) {
      console.error("Error fetching get courses info:", error);
      throw error;
    }
  },
  getCourseManagementForWaitingByAdmin: async () => {
    try {
      const response = await axios.get(
        "http://localhost:5144/api/v1/web/course/manage-waiting-courses"
      );
      return response.data;
    } catch (error) {
      console.error("Error fetching get waiting courses info:", error);
      throw error;
    }
  },
  updateCourseByAdmin: async (courseId, status) => {
    try {
      const formData = new FormData();
      formData.append("courseId", courseId);
      formData.append("status", status);

      const response = await axios.put(
        "http://localhost:5144/api/v1/web/course/update-course-management",
        formData,
        {
          headers: {
            "Content-Type": "application/x-www-form-urlencoded",
          },
        }
      );

      return response.data;
    } catch (error) {
      console.error("Error updating status:", error);
      throw error;
    }
  },
  getRequestBecomeInstructorManagementByAdmin: async () => {
    try {
      const response = await axios.get(
        "http://localhost:5144/api/v1/web/user/get-request-feedbacks"
      );
      return response.data;
    } catch (error) {
      console.error("Error fetching get waiting courses info:", error);
      throw error;
    }
  },
  updateUserToBecomeInstructorByAdmin: async (userId, status) => {
    try {
      const formData = new FormData();
      formData.append("userId", userId);
      formData.append("status", status);

      const response = await axios.post(
        "http://localhost:5144/api/v1/web/role-user/request-roleUser",
        formData,
        {
          headers: {
            "Content-Type": "application/x-www-form-urlencoded",
          },
        }
      );

      return response.data;
    } catch (error) {
      console.error("Error updating status:", error);
      throw error;
    }
  },
  UpdateRequestRoleUserByAdmin: async (userId, status) => {
    try {
      const formData = new FormData();
      formData.append("userId", userId);
      formData.append("status", status);

      const response = await axios.post(
        "http://localhost:5144/api/v1/web/role-user/update-request-roleUser",
        formData,
        {
          headers: {
            "Content-Type": "application/x-www-form-urlencoded",
          },
        }
      );

      return response.data;
    } catch (error) {
      console.error("Error updating status:", error);
      throw error;
    }
  },
  getReportsManagementByAdmin: async () => {
    try {
      const response = await axios.get(
        "http://localhost:5144/api/v1/web/user/get-reports"
      );
      return response.data;
    } catch (error) {
      console.error("Error fetching get reports info:", error);
      throw error;
    }
  },
  updateReportManagementByAdmin: async (
    userId,
    reportId,
    commentId,
    courseId
  ) => {
    try {
      const formData = new FormData();
      formData.append("userId", userId);
      formData.append("reportId", reportId);
      formData.append("commentId", commentId);
      formData.append("courseId", courseId);

      const response = await axios.put(
        "http://localhost:5144/api/v1/web/user/update-report-management-status",
        formData,
        {
          headers: {
            "Content-Type": "application/x-www-form-urlencoded",
          },
        }
      );

      return response.data;
    } catch (error) {
      console.error("Error updating report status:", error);
      throw error;
    }
  },
  getAllCategoriesManagementByAdmin: async () => {
    try {
      const response = await axios.get(
        "http://localhost:5144/api/v1/web/category/categories-list"
      );
      return response.data;
    } catch (error) {
      console.error("Error fetching get all categories info:", error);
      throw error;
    }
  },
  updateStatusCategoriesManagementByAdmin: async (cateId) => {
    try {
      const formData = new FormData();
      formData.append("cateId", cateId);

      const response = await axios.put(
        "http://localhost:5144/api/v1/web/category/update-status-category",
        formData,
        {
          headers: {
            "Content-Type": "application/x-www-form-urlencoded",
          },
        }
      );

      return response.data;
    } catch (error) {
      console.error("Error updating category status:", error);
      throw error;
    }
  },
  createNewCategoryManagementByAdmin: async (cateName, isVisible) => {
    try {
      const formData = new FormData();
      formData.append("Name", cateName);
      formData.append("IsVisible", isVisible);

      console.log([...formData.entries()]);

      const response = await axios.post(
        "http://localhost:5144/api/v1/web/category/create-category",
        formData,
        {
          headers: {
            "Content-Type": "application/x-www-form-urlencoded",
          },
        }
      );

      return response.data;
    } catch (error) {
      console.error("Error creating new category:", error);
      throw error;
    }
  },
  getCredentials: async (UserId) => {
    try {
      const response = await axios.get(
        "http://localhost:5144/api/v1/web/certification/credentials",
        {
          params: { UserId },
        }
      );

      return response.data;
    } catch (error) {
      console.error("Error fetching credentials list:", error);
      throw error;
    }
  },
};
// getFollowing: async (UserId) =>{
//     try{
//         const response = await axios.get(
//             //gan api do
//             {
//                 params:{ UserId},
//             }
//         );
//         return response.data;
//     } catch (error) {
//       console.error("Error fetching following list:", error);
//       throw error;
//     }
//   },
// };


export default ApiService;
