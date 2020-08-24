<template>
  <button class="el-button el-button--default el-button--medium">
    <svg-icon name="facebook-logo" />
    Login with Facebook
  </button>
</template>

<script lang="ts">
import { Component, Vue, Ref } from 'vue-property-decorator';

@Component({
  name: 'FacebookSignin'
})
export default class extends Vue {
  mounted() { }

  async onSuccess(facebookUser: any) { }
}
</script>

<style lang="scss" scoped>
button {
  width: 100%;
}
</style>
