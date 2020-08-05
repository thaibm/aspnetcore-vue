import request from '@/utils/request';

export const getAllUsersAPI = (params: any) =>
  request({
    url: '/api/services/app/User/GetAll',
    method: 'GET',
    params
  });
