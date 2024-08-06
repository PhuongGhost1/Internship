import axios from "axios";
const serverUrl = import.meta.env.VITE_SERVER_URL;
const API_URL =
  `${serverUrl}/api/v1`
  ;

const api = axios.create({
  baseURL: API_URL,
  headers: {
    "Content-Type": "application/json",
  },
});

const ApiService = {
  getCourseByName: async (courseName, userId) => {
    try {
      const formData = new FormData();
      formData.append("courseName", courseName);
      formData.append("userId", userId);

      const response = await api.post("/web/course/find-course", formData, {
        headers: {
          "Content-Type": "application/x-www-form-urlencoded",
        },
      });
      return response.data;
    } catch (error) {
      console.error("Error fetching most purchased courses:", error);
      throw error;
    }
  },
  getMostPurchasedCourses: async (count) => {
    try {
      const response = await api.get(
        `/web/course/most-purchased-courses/${count}`
      );
      return response.data;
    } catch (error) {
      console.error("Error fetching most purchased courses:", error);
      throw error;
    }
  },
  getMonthlyExpenseAndRevenue: async () => {
    try {
      const response = await api.get("/web/course/monthly-expense-revenue");
      return response.data;
    } catch (error) {
      console.error("Error fetching monthly expense and revenue:", error);
      throw error;
    }
  },
  getTotalPricesForSingleMonthly: async () => {
    try {
      const response = await api.get("/web/payment/total-prices-single-month");
      return response.data;
    } catch (error) {
      console.error("Error fetching total prices monthly:", error);
      throw error;
    }
  },
  getPercentageChangeForCurrentMonthly: async () => {
    try {
      const response = await api.get(
        "/web/payment/get-current-monthly-changes"
      );
      return response.data;
    } catch (error) {
      console.error("Error fetching percentage monthly:", error);
      throw error;
    }
  },
  getTotalPricesForCurrentWeekly: async () => {
    try {
      const response = await api.get("/web/payment/total-prices-single-week");
      return response.data;
    } catch (error) {
      console.error("Error fetching monthly expense and revenue:", error);
      throw error;
    }
  },
  getPercentageChangeForCurrentWeekly: async () => {
    try {
      const response = await api.get("/web/payment/get-current-weekly-changes");
      return response.data;
    } catch (error) {
      console.error("Error fetching monthly expense and revenue:", error);
      throw error;
    }
  },
  getCountAccountsByStudentRoleForMonth: async () => {
    try {
      const response = await api.get("/web/user/count-total-student-monthly");
      return response.data;
    } catch (error) {
      console.error("Error fetching student account monthly:", error);
      throw error;
    }
  },
  getCountAccountsByInstructorForMonth: async () => {
    try {
      const response = await api.get(
        "/web/user/count-total-instructor-monthly"
      );
      return response.data;
    } catch (error) {
      console.error("Error fetching instructor account monthly:", error);
      throw error;
    }
  },
  getPercentageChangeForInstructorAccountsLastMonth: async () => {
    try {
      const response = await api.get(
        "/web/user/get-instructor-percentage-changes-monthly"
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
      const response = await api.get(
        "/web/user/get-student-percentage-changes-monthly"
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
      const response = await api.get("/web/user/get-instructors");
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

      const response = await api.put(`/web/user/update-user-status`, formData, {
        headers: {
          "Content-Type": "application/x-www-form-urlencoded",
        },
      });

      return response.data; // Assuming response.data is the updated status or success indicator
    } catch (error) {
      console.error("Error updating status:", error);
      throw error;
    }
  },
  getStudents: async () => {
    try {
      const response = await api.get("/web/user/get-students");
      return response.data;
    } catch (error) {
      console.error("Error fetching get students info:", error);
      throw error;
    }
  },
  getCourseManagementByAdmin: async () => {
    try {
      const response = await api.get("/web/course/manage-courses");
      return response.data;
    } catch (error) {
      console.error("Error fetching get courses info:", error);
      throw error;
    }
  },
  getCourseManagementForWaitingByAdmin: async () => {
    try {
      const response = await api.get("/web/course/manage-waiting-courses");
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

      const response = await api.put(
        "/web/course/update-course-management",
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
      const response = await api.get("/web/user/get-request-feedbacks");
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

      const response = await api.post(
        "/web/role-user/request-roleUser",
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

      const response = await api.post(
        "/web/role-user/update-request-roleUser",
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
      const response = await api.get("/web/user/get-reports");
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

      const response = await api.put(
        "/web/user/update-report-management-status",
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
      const response = await api.get("/web/category/categories-list");
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

      const response = await api.put(
        "/web/category/update-status-category",
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

      const response = await api.post(
        "/web/category/create-category",
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
      const response = await api.get("/web/certification/credentials", {
        params: { UserId },
      });

      return response.data;
    } catch (error) {
      console.error("Error fetching credentials list:", error);
      throw error;
    }
  },
  getCourseContent: async (courseId) => {
    try {
      const formData = new FormData();
      formData.append("courseId", courseId);

      const response = await api.post("/web/course/content", formData, {
        headers: {
          "Content-Type": "application/x-www-form-urlencoded",
        },
      });

      return response.data;
    } catch (error) {
      console.error("Error get course content:", error);
      throw error;
    }
  },
  getCourseRandom: async (count) => {
    try {
      const response = await api.get(`/web/course/random/${count}`);

      return response.data;
    } catch (error) {
      console.error("Error getCourseRandom:", error);
      throw error;
    }
  },
  checkLogin: async (username, password) => {
    try {
      const formdata = new FormData();
      formdata.append("Username", username);
      formdata.append("Password", password);
      const response = await api.post("/web/user/user-login", formdata, {
        headers: {
          "Content-Type": "application/x-www-form-urlencoded",
        },
      });
      return response.data;
    } catch (error) {
      console.error("Error checkLogin: ", error);
      throw error;
    }
  },
  login: async (token) => {
    try {
      const formData = new FormData();
      formData.append("token", token);

      const response = await api.post("/web/user/get-user-token", formData, {
        headers: {
          "Content-Type": "application/x-www-form-urlencoded",
        },
      });

      return response.data;
    } catch (error) {
      console.error("Error token: ", error);
    }
  },
  fetchImage: async (imgUrl) => {
    try {
      const response = await fetch(imgUrl);
      const blob = await response.blob();
      return URL.createObjectURL(blob);
    } catch (error) {
      console.error("Error imgUrl: ", error);
    }
  },
  updateUpdate: async (
    userId,
    image,
    name,
    username,
    dob,
    description,
    gender
  ) => {
    try {
      const formdata = new FormData();
      formdata.append("UserId", userId);
      formdata.append("Image", image);
      formdata.append("Name", name);
      formdata.append("Username", username);
      formdata.append("DOB", dob);
      formdata.append("Description", description);
      formdata.append("Gender", gender);
      const response = await api.post("/web/user/update-profile", formdata, {
        headers: {
          "Content-Type": "application/x-www-form-urlencoded",
        },
      });
      return response.data;
    } catch (error) {
      console.log("Failed to update profile: ", error);
    }
  },
  getInstructorProfile: async (insId) => {
    try {
      const response = await api.get("/web/user/get-instructor-profile", {
        params: { insId },
      });

      return response.data;
    } catch (error) {
      console.error("Error update: ", error);
    }
  },
  getWaitingCourses: async (insId) => {
    try {
      const response = await api.get(
        "/web/user/get-instructor-profile-on-waiting-courses",
        {
          params: { insId },
        }
      );

      return response.data;
    } catch (error) {
      console.error(
        "Error fetching get waiting courses on instructor profile:",
        error
      );
      throw error;
    }
  },
  getNewReleaseCourses: async (count) => {
    try {
      const response = await api.get(
        `/web/course/new-release-courses/${count}`
      );
      return response.data;
    } catch (error) {
      console.error("Error fetching get new release courses:", error);
      throw error;
    }
  },
  getTopRatedCourses: async (count) => {
    try {
      const response = await api.get(`/web/course/top-rated-courses/${count}`);
      return response.data;
    } catch (error) {
      console.error("Error fetching get top rated courses:", error);
      throw error;
    }
  },
  getSavedCourse: async (userId) => {
    try {
      const formData = new FormData();
      formData.append("userId", userId);
      const response = await api.post(
        "/web/save-course/get-save-course",
        formData,
        {
          headers: {
            "Content-Type": "application/x-www-form-urlencoded",
          },
        }
      );
      return response.data;
    } catch (error) {
      console.error(error);
    }
  },

  getFollowing: async (UserId) => {
    try {
      const formData = new FormData();
      formData.append("UserId", UserId);

      const response = await api.post("/web/follow/view-following", formData, {
        headers: {
          "Content-Type": "application/x-www-form-urlencoded",
        },
      });
      return response.data;
    } catch (error) {
      console.error("Error fetching following list:", error);
      throw error;
    }
  },
  createFollowing: async (FollowerId, FollowedId) => {
    try {
      const formData = new FormData();
      formData.append("FollowerId", FollowerId);
      formData.append("FollowedId", FollowedId);

      const response = await api.post("/web/follow/create-follow", formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      });
      return response.data;
    } catch (error) {
      console.error("Error fetching creating following: ", error);
      throw error;
    }
  },
  removeFollowing: async (FollowerId, FollowedId) => {
    try {
      const formData = new FormData();
      formData.append("FollowerId", FollowerId);
      formData.append("FollowedId", FollowedId);

      const response = await api.post("/web/follow/delete-follow", formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      });
      return response.data;
    } catch (error) {
      console.error("Error removing follow: ", error);
      throw error;
    }
  },
  createSaveCourse: async (CourseId, UserId) => {
    try {
      const formData = new FormData();
      formData.append("CourseId", CourseId);
      formData.append("UserId", UserId);

      const response = await api.post(
        "/web/save-course/create-saveCourse",
        formData,
        {
          headers: {
            "Content-Type": "multipart/form-data",
          },
        }
      );
      return response.data;
    } catch (error) {
      console.error("Error fetching creating save course: ", error);
      throw error;
    }
  },
  removeSaveCourse: async (saveCourseId) => {
    try {
      const formData = new FormData();
      formData.append("saveCourseId", saveCourseId);

      const response = await api.post(
        "/web/save-course/delete-saveCourse",
        formData,
        {
          headers: {
            "Content-Type": "multipart/form-data",
          },
        }
      );
      return response.data;
    } catch (error) {
      console.error("Error removing save course: ", error);
      throw error;
    }
  },
  checkSaveCourseExist: async (UserId, CourseId) => {
    try {
      const formData = new FormData();
      formData.append("UserId", UserId);
      formData.append("CourseId", CourseId);

      const response = await api.post(
        "/web/save-course/get-saveCourse-exist",
        formData,
        {
          headers: {
            "Content-Type": "application/x-www-form-urlencoded",
          },
        }
      );
      return response.data;
    } catch (error) {
      console.error("Error fetching check save course exist:", error);
      throw error;
    }
  },
  getCourseComment: async (courseId) => {
    try {
      const formData = new FormData();
      formData.append("courseId", courseId);
      const response = await api.post(
        "/web/comment/get-comment-course",
        formData,
        {
          headers: {
            "Content-Type": "application/x-www-form-urlencoded",
          },
        }
      );
      return response.data;
    } catch (error) {
      console.log(error);
    }
  },
  LoginGoogle: async () => {
    try {
      const response = await api.get("/web/user/login-google");
      return response.data;
    } catch (error) {
      console.log(error);
    }
  },
  getCart: async (userId) => {
    try {
      const formData = new FormData();
      formData.append("userId", userId);
      const response = await api.post("/web/course/view-cart", formData, {
        headers: {
          "Content-Type": "application/x-www-form-urlencoded",
        },
      });
      return response.data;
    } catch (error) {
      console.log(error);
    }
  },
  addCourseToCart: async (CourseId, UserId) => {
    try {
      const formData = new FormData();
      formData.append("CourseId", CourseId);
      formData.append("UserId", UserId);

      const response = await api.post("/web/course/add-cart", formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      });
      return response.data;
    } catch (error) {
      console.error("Error fetching add course to cart: ", error);
      throw error;
    }
  },
  removeCourseFromCart: async (cartCourseId) => {
    try {
      const formData = new FormData();
      formData.append("cartCourseId", cartCourseId);

      const response = await api.post(
        "/web/course/delete-item-cart",
        formData,
        {
          headers: {
            "Content-Type": "multipart/form-data",
          },
        }
      );
      return response.data;
    } catch (error) {
      console.error("Error removing course from cart: ", error);
      throw error;
    }
  },
  checkCourseInCart: async (cartId, courseId) => {
    try {
      const response = await api.get("/web/course/is-course-in-cart", {
        params: {
          cartId,
          courseId,
        },
      });
      return response.data;
    } catch (error) {
      console.error("Error checking course in cart:", error);
      throw error;
    }
  },
  payCartCourse: async (CartCourseIds, UserId) => {
    try {
      const response = await api.post(
        "/web/course/pay-cart-course-items",
        {
          CartCourseIds: CartCourseIds,
          UserId: UserId,
        },
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );
      return response.data;
    } catch (error) {
      console.error("Error fetching pay course from cart: ", error);
      throw error;
    }
  },
  createPaypalOrder: async (total, referenceId) => {
    try {
      const response = await api.post(
        "/web/payment/create-order",
        {
          purchaseUnits: [
            {
              amount: {
                currencyCode: "USD",
                value: total.toString(),
              },
              referenceId: referenceId,
            },
          ],
        },
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );
      return response.data;
    } catch (error) {
      console.error("Error creating PayPal order: ", error);
      throw error;
    }
  },
  capturePaypalOrder: async (orderId) => {
    try {
      console.log(`Token in ApiService: ${orderId}`);
      const response = await api.post(
        `/web/payment/capture-order/${orderId}`,
        {},
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );
      return response.data;
    } catch (error) {
      console.error(
        "Error capturing PayPal order: ",
        error.response ? error.response.data : error.message
      );
      throw error;
    }
  },
  cancelPaypalOrder: async (orderId) => {
    try {
      const response = await api.post(
        `/web/payment/cancel-order/${orderId}`,
        {},
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );
      return response.data;
    } catch (error) {
      console.error(
        "Error canceling PayPal order: ",
        error.response ? error.response.data : error.message
      );
      throw error;
    }
  },
  getUserProfileToSeen: async (userId) => {
    try {
      const response = await api.get("/web/user/user-profile-to-seen", {
        params: { userId },
      });

      return response.data;
    } catch (error) {
      console.error("Error get user: ", error);
    }
  },
  SearchCourses: async (page, items, query) => {
    try {
      const formData = new FormData();
      formData.append("query", query);
      const response = await api.post(
        `/web/course/search?page=${page}&items=${items}`,
        formData,
        {
          headers: {
            "Content-Type": "application/x-www-form-urlencoded",
          },
        }
      );
      return response.data;
    } catch (error) {
      console.log(error);
    }
  },
  GetCategories: async () => {
    try {
      const response = await api.get("/web/category/categories-list");
      return response.data;
    } catch (error) {
      console.log(error);
    }
  },
  SearchFilter: async (
    page,
    items,
    query,
    categories,
    priceRange,
    ratings,
    levels,
    userId
  ) => {
    try {
      const formData = new FormData();
      formData.append("query", query);
      formData.append("categories", JSON.stringify(categories));
      formData.append("priceRange", JSON.stringify(priceRange));
      formData.append("ratings", JSON.stringify(ratings));
      formData.append("levels", JSON.stringify(levels));
      formData.append("userId", userId);

      const response = await api.post(
        `/web/course/search-filter?page=${page}&items=${items}`,
        formData,
        {
          headers: {
            "Content-Type": "application/x-www-form-urlencoded",
          },
        }
      );
      return response.data;
    } catch (error) {
      console.log(error);
    }
  },
  AddToCart: async (courseId, userId) => {
    try {
      const formData = new FormData();
      formData.append("courseId", courseId);
      formData.append("userId", userId);

      const response = await api.post(`/web/course/add-cart`, formData, {
        headers: {
          "Content-Type": "application/x-www-form-urlencoded",
        },
      });
      return response.data;
    } catch (error) {
      console.log("Failed to add to cart: ", error);
    }
  },
  GetLecture: async (hashCode) => {
    try {
      const formData = new FormData();
      formData.append("hashCode", hashCode);
      const response = await api.post(`/web/course/get-lecture`, formData, {
        headers: {
          "Content-Type": "application/x-www-form-urlencoded",
        },
      });
      return response.data;
    } catch (error) {
      console.log("Failed to get lecture: ", error);
    }
  },
  GetQuiz: async (hashCode) => {
    try {
      const formData = new FormData();
      formData.append("hashCode", hashCode);
      const response = await api.post(`/web/course/get-quiz`, formData, {
        headers: {
          "Content-Type": "application/x-www-form-urlencoded",
        },
      });
      return response.data;
    } catch (error) {
      console.log("Failed to get quiz: ", error);
    }
  },
  GetUserRole: async (userId) => {
    try {
      const formData = new FormData();
      formData.append("userId", userId)
      const response = await api.post(`/web/user/get-user-role`,
        formData, {
        headers: {
          "Content-Type": "application/x-www-form-urlencoded",
        },
      })
      return response.data
    } catch (error) {
      console.log("Failed to get useRole: ", error)
    }
  }
};

export default ApiService;
