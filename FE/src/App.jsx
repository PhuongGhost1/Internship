import "./App.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";

import Home from "./pages/Home/Home";
import CourseDetailPage from "./pages/UserPage/CourseDetailPage/CourseDetailPage";
import LoginPage from "./pages/AuthPage/LoginPage/LoginPage";
import RegisterPage from "./pages/AuthPage/RegisterPage/RegisterPage";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/">
          <Route index element={<Home />} />
          <Route path="login" element={<LoginPage />} />
          <Route path="signup" element={<RegisterPage />} />
        </Route>
        <Route path="/courses">
          <Route path=":courseName" element={<CourseDetailPage />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
