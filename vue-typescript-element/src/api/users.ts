import request from '@/utils/request';

export const getUsers = (params: any) =>
  request({
    url: '/users',
    method: 'GET',
    params
  });

export const getUserInfo = (params?: any) =>
  request({
    url: '/api/services/app/Session/GetCurrentLoginInformations',
    method: 'GET',
    params
  });

export const getUserByName = (username: string) =>
  request({
    url: `/users/${username}`,
    method: 'GET'
  });

export const updateUser = (username: string, data: any) =>
  request({
    url: `/users/${username}`,
    method: 'PUT',
    data
  });

export const deleteUser = (username: string) =>
  request({
    url: `/users/${username}`,
    method: 'delete'
  });

export const login = (data: any) =>
  request({
    url: '/api/TokenAuth/Authenticate',
    method: 'post',
    data
  });

// export const logout = () =>
//   request({
//     url: '/users/logout',
//     method: 'post'
//   })

export const register = (data: any) =>
  request({
    url: '/users/register',
    method: 'post',
    data
  });
