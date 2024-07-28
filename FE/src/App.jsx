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

function App() {
  return (
    <BrowserRouter>
      <AuthProvider>
        <Routes>
          <Route path="/">
            <Route index element={<Home />} />
            <Route path="login" element={<LoginPage />} />
            <Route path="sign-in" element={<SignInPage />} />
            <Route path="signup" element={<RegisterPage />} />
            <Route path="payment" element={<PaymentPage />} />
            <Route path="search" element={<SearchPage />} />
          </Route>
          <Route path="/courses">
            <Route path=":courseName" element={<CourseDetailPage />} />
            <Route
              path="learning/:courseName/:courseType/:itemName"
              element={<CourseLearning />}
            />
            <Route path="create/:courseName" element={<CreateCoursePage />} />
          </Route>
          <Route path="/student">
            <Route path="cart" element={<CartPage />} />
            <Route path="payout" element={<PayoutPage />} />
            <Route
              path="certification/:userId"
              element={<CertificationPage />}
            />
            <Route path="profile" element={<StudentProfilePage />} />
            <Route path="my-learning">
              <Route path="completed" element={<CourseCompletedPage />} />
              <Route path="following" element={<FollowingPage />} />
              <Route path="in-progress" element={<CourseInProgressPage />} />
              <Route path="saved" element={<CourseSavedPage />} />
            </Route>
          </Route>
          <Route path="/instructor">
            <Route path="profile" element={<InstructorProfilePage />} />
          </Route>

          <Route path="/admin">
            <Route path="dashboard" element={<DashBoard />} />
            <Route path="instructor" element={<ManageInstructorPage />} />
            <Route path="student" element={<ManageStudentPage />} />
            <Route path="course" element={<ManageCoursePage />} />
            <Route path="requests" element={<RequestsPage />} />
            <Route path="setting" element={<SettingPage />} />
            <Route path="report" element={<ReportPage />} />
            <Route path="feedback" element={<FeedBackAdminPage />} />
            <Route path="category" element={<CategoryPage />} />
          </Route>
        </Routes>
      </AuthProvider>
    </BrowserRouter>
  );
}

export default App;
