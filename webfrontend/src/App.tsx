import React from "react";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import Register from "./Register";

function Home() {
  return (
    <div className="App">
      <h1>Trang Chủ</h1>
      <p>Chào mừng bạn đến với ứng dụng!</p>
      <Link to="/register">
        <button>Đăng ký</button>
      </Link>
    </div>
  );
}

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/register" element={<Register />} />
      </Routes>
    </Router>
  );
}

export default App;
