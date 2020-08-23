<template>
  <button
    id="g-signin-button"
    ref="gSigninButton"
    class="el-button el-button--default el-button--medium"
  >
    <svg-icon name="google-logo" />
    Login with Google
  </button>
</template>

<script lang="ts">
import { Component, Vue, Ref } from 'vue-property-decorator';
import { IWindow, IGoogleAuthResponse } from '@/types/social-signin/google';
import { UserModule } from '@/store/modules/user';
import { Message } from 'element-ui';

@Component({
  name: 'GoogleSignin'
})
export default class extends Vue {
  @Ref('gSigninButton')
  private gSigninButton!: Element;

  mounted() {
    const wd: IWindow = window;
    if (!wd.gapi) {
      throw new Error(
        '"https://apis.google.com/js/api:client.js" needs to be included as a <script>.'
      );
    }

    wd.gapi.load('auth2', () => {
      const auth2 = wd.gapi.auth2.init({
        client_id: '69541603314-st5uan1l3o0ff47ougr7jd3dt3s0vh9b.apps.googleusercontent.com',
        cookiepolicy: 'single_host_origin'
      });
      auth2.attachClickHandler(
        this.gSigninButton,
        {},
        this.onSuccess,
        (error: any) => {
          console.error(error);
        });
    });
  }

  async onSuccess(googleUser: any) {
    const authResponse: IGoogleAuthResponse = googleUser.getAuthResponse();
    try {
      await UserModule.socialSignin({
        authProvider: 'GOOGLE',
        providerKey: googleUser.getId(),
        providerAccessCode: googleUser.wc.id_token
      });
      this.$emit('onSuccess');
    } catch (error) {
      Message.error(error);
    }
  }
}
</script>

<style lang="scss" scoped>
button {
  width: 100%;
}
</style>
