import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { login } from '../../services/authService';
import Input from '../../components/Input';
import './LoginPage.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faUser, faLock } from '@fortawesome/free-solid-svg-icons';

const LoginPage: React.FC = () => {
  const [userName, setUserName] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError(null);
    setLoading(true);

    try {
      const response = await login(userName, password);
      localStorage.setItem('token', response.userToken);
      navigate('/dashboard');
    } catch (err: any) {
      setError(err.message || 'Đăng nhập thất bại. Vui lòng thử lại.');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="login-container">
      <div className="login-box">
        <h2 className="login-title">Đăng Nhập</h2>
        <form onSubmit={handleSubmit}>
          <div className="input-group">
            <label htmlFor="userName">
              <FontAwesomeIcon icon={faUser} className="input-icon" /> Tên đăng nhập
            </label>
            <Input
              label=""
              type="text"
              id="userName"
              value={userName}
              onChange={(e) => setUserName(e.target.value)}
              required
            />
          </div>
          <div className="input-group">
            <label htmlFor="password">
              <FontAwesomeIcon icon={faLock} className="input-icon" /> Mật khẩu
            </label>
            <Input
              label=""
              type="password"
              id="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              required
            />
          </div>
          {error && <p className="error-message">{error}</p>}
          <button type="submit" disabled={loading}>
            {loading ? 'Đang đăng nhập...' : 'Đăng Nhập'}
          </button>
        </form>
        <div className="login-options">
          <a href="#" className="forgot-password">Quên mật khẩu</a>
          <div className="register-row">
            <span className="register-text">Chưa có tài khoản? </span>
            <a href="#" className="register-link">Đăng ký</a>
          </div>
        </div>
      </div>
    </div>
  );
};

export default LoginPage;