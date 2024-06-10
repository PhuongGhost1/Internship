import './App.css'
import { BrowserRouter, Routes, Route } from "react-router-dom";

import Home from './pages/Home/Home'
import CourseDetail from './pages/CourseDetail/CourseDetail';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/">
          <Route index element={<Home />} />
          <Route path='course' element={<CourseDetail />} />
        </Route>
      </Routes>
    </BrowserRouter>
  )
}

export default App
