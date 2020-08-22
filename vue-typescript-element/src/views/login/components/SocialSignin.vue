<template>
  <div class="social-signup-container">
    <button
      ref="signinBtn"
      class="g-signin-button"
    >
      Sign in with Google
    </button>
  </div>
</template>

<script lang="ts">
// import openWindow from '@/utils/openWindow'
import { Component, Vue } from 'vue-property-decorator';

@Component({
  name: 'SocialSignin'
})
export default class extends Vue {
  clientId = '69541603314-st5uan1l3o0ff47ougr7jd3dt3s0vh9b.apps.googleusercontent.com';

  mounted() {
    if (!window.gapi) {
      throw new Error(
        '"https://apis.google.com/js/api:client.js" needs to be included as a <script>.'
      );
    }

    if (!this.clientId) {
      throw new Error('Client Id must be specified.');
    }
    window.gapi.load('auth2', () => {
      const auth2 = window.gapi.auth2.init({ client_id: this.clientId });
      auth2.attachClickHandler(
        this.$refs.signinBtn,
        {},
        (googleUser: any) => {
          console.log('extends -> mounted -> googleUser', googleUser);
          debugger;
          this.$emit('success', googleUser);
        },
        (error: any) => {
          this.$emit('error', error);
        }
      );
    });
  }
}
</script>

<style lang="scss" scoped>
.social-signup-container {
  margin: 20px 0;

  .sign-btn {
    display: inline-block;
    cursor: pointer;
  }

  .icon {
    color: #fff;
    font-size: 24px;
    margin-top: 8px;
  }

  .wx-svg-container,
  .qq-svg-container {
    display: inline-block;
    width: 40px;
    height: 40px;
    line-height: 40px;
    text-align: center;
    padding-top: 1px;
    border-radius: 4px;
    margin-bottom: 20px;
    margin-right: 5px;
  }

  .wx-svg-container {
    background-color: #24da70;
  }

  .qq-svg-container {
    background-color: #6ba2d6;
    margin-left: 50px;
  }
}
</style>
