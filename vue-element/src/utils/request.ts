import { UserModule } from '@/store/modules/user';
import axios from 'axios';
import { Message, MessageBox } from 'element-ui';

const service = axios.create({
  baseURL: process.env.VUE_APP_BASE_API, // url = base url + request url
  timeout: 40000
  // withCredentials: true // send cookies when cross-domain requests
});

// Request interceptors
service.interceptors.request.use(
  (config) => {
    if (UserModule.token) {
      config.headers['Authorization'] = 'Bearer ' + UserModule.token;
    }
    // config.headers.common[".AspNetCore.Culture"] = 'vi'
    config.headers.common['Abp.TenantId'] = null;
    return config;
  },
  (error) => {
    Promise.reject(error);
  }
);

// Response interceptors
service.interceptors.response.use(
  (response) => {
    if (Math.floor(response.status / 100) !== 2) {
      Message({
        message: response.statusText || `Error ${response.status}`,
        type: 'error',
        duration: 5 * 1000
      });
      return Promise.reject(new Error(response.statusText || 'Error'));
    } else {
      return response;
    }
  },
  (error) => {
    return Promise.reject(error.response);
  }
);

export default service;
