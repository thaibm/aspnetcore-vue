<template>
  <div class="app-container">
    <el-table
      :data="users"
      style="width: 100%"
    >
      <el-table-column
        prop="userName"
        label="User Name"
        width="180"
      />
      <el-table-column
        prop="fullName"
        label="Full Name"
        width="180"
      />
      <el-table-column
        prop="emailAddress"
        label="Email Address"
      />
      <!-- Custom row template -->
      <el-table-column label="Active">
        <template slot-scope="scope">
          <span>{{ scope.row.isActive ? 'Yes' : 'No' }}</span>
        </template>
      </el-table-column>
    </el-table>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import { UsersModule } from '@/store/modules/management/users';

@Component({
  name: 'Users'
})
export default class extends Vue {
  users: any[] = [];

  private async mounted() {
    const { result } = await UsersModule.getAllUsers({});
    this.users = result?.items;
  }
}
</script>
