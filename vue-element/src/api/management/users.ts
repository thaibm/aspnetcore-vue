import request from '@/utils/request';
import { IUserParams } from '@/types/management/users';

export const getAllUsersAPI = (params: any) =>
  request({
    url: '/api/services/app/User/GetAll',
    method: 'GET',
    params
  });

export const createUserAPI = (data: IUserParams) =>
  request({
    url: '/api/services/app/User/Create',
    method: 'POST',
    data
  });
