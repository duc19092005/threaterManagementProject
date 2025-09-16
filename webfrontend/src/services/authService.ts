import axios from 'axios';

// Interface cho response từ API (dựa trên backend AuthResponseMessage)
export interface AuthResponseMessage {
  userToken: string;
  expiration: string;
}

// Hàm mock login (sử dụng trong dev)
export const login = async (userName: string, password: string): Promise<AuthResponseMessage> => {
  // Simulate delay
  await new Promise(resolve => setTimeout(resolve, 1000));

  // Mock logic: Thành công nếu username = 'admin' và password = '123'
  if (userName === 'admin' && password === '123') {
    return {
      userToken: 'mock-jwt-token-123456',
      expiration: new Date(Date.now() + 3600000).toLocaleTimeString(), // 1 giờ sau
    };
  } else {
    throw new Error('Thông tin chưa chính xác, đăng nhập thất bại!');
  }
};

// Hàm thật (bỏ comment khi backend sẵn sàng)
// export const login = async (userName: string, password: string): Promise<AuthResponseMessage> => {
//   const response = await axios.post('/api/Auth/login', { userName, password });
//   return response.data;
// };