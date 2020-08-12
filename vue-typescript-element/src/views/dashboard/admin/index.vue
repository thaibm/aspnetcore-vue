<template>
  <div class="dashboard-editor-container">
    <todo-list />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import TodoList from './components/TodoList/index.vue';

@Component({
  name: 'DashboardAdmin',
  components: {
    TodoList
  }
})
export default class extends Vue {}
</script>

<style lang="scss" scoped>
.dashboard-editor-container {
  padding: 32px;
  background-color: rgb(240, 242, 245);
  position: relative;
  min-height: calc(100vh - 50px);
}
</style>
