import './App.css'
import { BrowserRouter, Routes, Route } from "react-router-dom";

import 'bootstrap/dist/css/bootstrap.min.css';

import Home from './pages/Home/Home'
import CourseDetailPage from './pages/UserPage/CourseDetailPage/CourseDetailPage';
import LoginPage from './pages/AuthPage/LoginPage/LoginPage';
import RegisterPage from './pages/AuthPage/RegisterPage/RegisterPage';
import StudentProfilePage from './pages/StudentPage/ProfilePage/StudentProfilePage';
import CourseLearning from './pages/StudentPage/CourseLearning/CourseLearning';
import InstructorProfilePage from './pages/InstructorPage/ProfilePage/InstructorProfilePage';
import PaymentPage from './pages/StudentPage/Payment/PaymentPage';
import SearchPage from './pages/UserPage/SearchPage/SearchPage';
import CourseCompletedPage from './pages/StudentPage/MyLearning/Completed/CourseCompletedPage';
import FollowingPage from './pages/StudentPage/MyLearning/Following/FollowingPage';
import CourseInProgressPage from './pages/StudentPage/MyLearning/InProgress/CourseInProgressPage';
import CourseSavedPage from './pages/StudentPage/MyLearning/Saved/CourseSavedPage';
import DashBoard from './pages/Admin/DashBoardPage/DashBoard';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/">
          <Route index element={<Home />} />
          <Route path='login' element={<LoginPage />} />
          <Route path='signup' element={<RegisterPage />} />
          <Route path='payment' element={<PaymentPage />} />
          <Route path='search' element={<SearchPage />} />
        </Route>
        <Route path='/courses'>
          <Route path=':courseName' element={<CourseDetailPage />} />
          <Route path='learning/:courseType/:itemName' element={<CourseLearning />} />
        </Route>
        <Route path='/student'>
          <Route path='profile' element={<StudentProfilePage />} />
          <Route path='my-learning'>
            <Route path='completed' element={<CourseCompletedPage />} />
            <Route path='following' element={<FollowingPage />} />
            <Route path='in-progress' element={<CourseInProgressPage />} />
            <Route path='saved' element={<CourseSavedPage />} />
          </Route>
        </Route>
        <Route path='/instructor'>
          <Route path='profile' element={<InstructorProfilePage />} />
        </Route>

        <Route path='/admin'>
          <Route path='dashboard' element={<DashBoard />} />
        </Route>
      </Routes>
    </BrowserRouter>
  )
}

export default App
