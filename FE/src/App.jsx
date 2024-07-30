import "./App.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";

import "bootstrap/dist/css/bootstrap.min.css";

import Home from "./pages/Home/Home";
import CourseDetailPage from "./pages/UserPage/CourseDetailPage/CourseDetailPage";
import LoginPage from "./pages/AuthPage/LoginPage/LoginPage";
import RegisterPage from "./pages/AuthPage/RegisterPage/RegisterPage";
import StudentProfilePage from "./pages/StudentPage/ProfilePage/StudentProfilePage";
import CourseLearning from "./pages/StudentPage/CourseLearning/CourseLearning";
import InstructorProfilePage from "./pages/InstructorPage/ProfilePage/InstructorProfilePage";
import PaymentPage from "./pages/StudentPage/Payment/PaymentPage";
import SearchPage from "./pages/UserPage/SearchPage/SearchPage";
import CourseCompletedPage from "./pages/StudentPage/MyLearning/Completed/CourseCompletedPage";
import FollowingPage from "./pages/StudentPage/MyLearning/Following/FollowingPage";
import CourseInProgressPage from "./pages/StudentPage/MyLearning/InProgress/CourseInProgressPage";
import CourseSavedPage from "./pages/StudentPage/MyLearning/Saved/CourseSavedPage";
import DashBoard from "./pages/Admin/DashBoardPage/DashBoard";
import ManageInstructorPage from "./pages/Admin/ManageInstructorPage/ManageInstructorPage";
import ManageStudentPage from "./pages/Admin/ManageStudentPage/ManageStudentPage";
import ManageCoursePage from "./pages/Admin/ManageCoursePage/ManageCoursePage";
import RequestsPage from "./pages/Admin/RequestsPage/RequestsPage";
import SettingPage from "./pages/Admin/SettingPage/SettingPage";
import CertificationPage from "./pages/StudentPage/CertificationPage/CertificationPage";
import CartPage from "./pages/StudentPage/CartPage/CartPage";
import PayoutPage from "./pages/StudentPage/Payout/PayoutPage";
import ReportPage from "./pages/Admin/ReportPage/ReportPage";
import FeedBackAdminPage from "./pages/Admin/FeedBackAdminPage/FeedBackAdminPage";
import CategoryPage from "./pages/Admin/CategoryPage/CategoryPage";
import CreateCoursePage from "./pages/InstructorPage/CreateCourse/CreateCoursePage";

import { AuthProvider } from "./pages/Context/AuthContext";
import SignInPage from "./pages/AuthPage/SignInPage/SignInPage";
import InstructorDashBoard from "./pages/InstructorPage/DashBoard/InstructorDashBoard";
import UserInfoPage from "./pages/UserPage/UserInfoPage/UserInfoPage";
import PrivateRoute from "./pages/Context/PrivateRoute";
import ErrorPage from "./pages/AuthPage/ErrorPage/ErrorPage";

function App() {
  return (
    <BrowserRouter>
      <AuthProvider>
        <Routes>
          <Route path="/">
            <Route index element={<Home />} />
            <Route path="login" element={<LoginPage />} />
            <Route path="sign-in" element={<SignInPage />} />
            <Route path="error" element={<ErrorPage />} />
            <Route path="signup" element={<RegisterPage />} />
            <Route
              path="payment"
              element={
                <PrivateRoute
                  element={<PaymentPage />}
                  roles={["Instructor", "Student"]}
                />
              }
            />
            <Route path="search" element={<SearchPage />} />
          </Route>
          <Route path="/courses">
            <Route path=":courseName" element={<CourseDetailPage />} />
            <Route
              path="learning/:courseName/:courseType/:itemName"
              element={
                <PrivateRoute
                  element={<CourseLearning />}
                  roles={["Instructor", "Student"]}
                />
              }
            />
            <Route
              path="create/:courseName"
              element={
                <PrivateRoute
                  element={<CreateCoursePage />}
                  roles={["Instructor"]}
                />
              }
            />
          </Route>
          <Route path="/student">
            <Route
              path="cart"
              element={
                <PrivateRoute
                  element={<CartPage />}
                  roles={["Instructor", "Student"]}
                />
              }
            />
            <Route
              path="payout"
              element={
                <PrivateRoute
                  element={<PayoutPage />}
                  roles={["Instructor", "Student"]}
                />
              }
            />
            <Route
              path="certification/:userId"
              element={
                <PrivateRoute
                  element={<CertificationPage />}
                  roles={["Instructor", "Student"]}
                />
              }
            />
            <Route
              path="profile"
              element={
                <PrivateRoute
                  element={<StudentProfilePage />}
                  roles={["Instructor", "Student"]}
                />
              }
            />
            <Route path="my-learning">
              <Route
                path="completed"
                element={
                  <PrivateRoute
                    element={<CourseCompletedPage />}
                    roles={["Instructor", "Student"]}
                  />
                }
              />
              <Route
                path="following"
                element={
                  <PrivateRoute
                    element={<FollowingPage />}
                    roles={["Instructor", "Student"]}
                  />
                }
              />
              <Route
                path="in-progress"
                element={
                  <PrivateRoute
                    element={<CourseInProgressPage />}
                    roles={["Instructor", "Student"]}
                  />
                }
              />
              <Route
                path="saved"
                element={
                  <PrivateRoute
                    element={<CourseSavedPage />}
                    roles={["Instructor", "Student"]}
                  />
                }
              />
            </Route>
          </Route>
          <Route path="/instructor">
            <Route
              path="profile"
              element={
                <PrivateRoute
                  element={<InstructorProfilePage />}
                  roles={["Instructor"]}
                />
              }
            />
            <Route
              path="dashboard"
              element={
                <PrivateRoute
                  element={<InstructorDashBoard />}
                  roles={["Instructor"]}
                />
              }
            />
          </Route>
          <Route path="/user">
            <Route path=":id" element={<UserInfoPage />} />
          </Route>

          <Route path="/admin">
            <Route
              path="dashboard"
              element={
                <PrivateRoute element={<DashBoard />} roles={["Admin"]} />
              }
            />
            <Route
              path="instructor"
              element={
                <PrivateRoute
                  element={<ManageInstructorPage />}
                  roles={["Admin"]}
                />
              }
            />
            <Route
              path="student"
              element={
                <PrivateRoute
                  element={<ManageStudentPage />}
                  roles={["Admin"]}
                />
              }
            />
            <Route
              path="course"
              element={
                <PrivateRoute
                  element={<ManageCoursePage />}
                  roles={["Admin"]}
                />
              }
            />
            <Route
              path="requests"
              element={
                <PrivateRoute element={<RequestsPage />} roles={["Admin"]} />
              }
            />
            <Route
              path="report"
              element={
                <PrivateRoute element={<ReportPage />} roles={["Admin"]} />
              }
            />
            <Route
              path="feedback"
              element={
                <PrivateRoute
                  element={<FeedBackAdminPage />}
                  roles={["Admin"]}
                />
              }
            />
            <Route
              path="category"
              element={
                <PrivateRoute element={<CategoryPage />} roles={["Admin"]} />
              }
            />
          </Route>
        </Routes>
      </AuthProvider>
    </BrowserRouter>
  );
}

export default App;
