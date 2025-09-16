import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
     import LoginPage from './pages/LoginPage/LoginPage';

     function App() {
       return (
         <Router>
           <Routes>
             <Route path="/login" element={<LoginPage />} />
             <Route path="/dashboard" element={<div>Dashboard Placeholder</div>} />
             <Route path="/" element={<LoginPage />} />
           </Routes>
         </Router>
       );
     }

     export default App;