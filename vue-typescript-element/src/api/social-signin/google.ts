import request from '@/utils/request';
import { ISocialSigninPayload } from '@/types/social-signin/google';

export const socialSignin = (payload: ISocialSigninPayload) =>
  request({
    url: '/api/TokenAuth/ExternalAuthenticate',
    method: 'POST',
    data: payload
  });
