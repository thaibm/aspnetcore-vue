import request from '@/utils/request';
import { IGoogleSigninPayload } from '@/types/social-signin/google';

export const googleSignin = (payload: IGoogleSigninPayload) =>
  request({
    url: '/api/TokenAuth/ExternalAuthenticate',
    method: 'POST',
    data: payload
  });
