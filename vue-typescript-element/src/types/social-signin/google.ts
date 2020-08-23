
export interface IWindow extends Window {
    gapi?: any;
}
/* eslint-disable camelcase */
export interface IGoogleAuthResponse {
    expires_at: Date;
    expires_in: Date;
    first_issued_at: Date;
    id_token: string;
    idpId: string;
    login_hint: string;
    session_state: any;
    token_type: string;
}

export interface ISocialSigninPayload {
    authProvider: string;
    providerKey: string;
    providerAccessCode: string;
}
