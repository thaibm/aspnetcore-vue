<template>
  <div class="app-container">
    <el-button
      type="primary"
      @click="AddUserDiablog.open()"
    >
      <!-- $t('key'): i18n multiple language -->
      {{ $t('table.add') }}
    </el-button>

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

      <!-- Custom row template -->
      <el-table-column label="Creation Time">
        <template slot-scope="scope">
          <span>{{ scope.row.creationTime | moment("DD/MM/YYYY") }}</span>
        </template>
      </el-table-column>

      <!-- Custom row template -->
      <el-table-column label="Last Login Time">
        <template slot-scope="scope">
          <span>{{ scope.row.lastLoginTime || new Date() | moment("HH:MM DD/MM/YYYY") }}</span>
        </template>
      </el-table-column>

      <el-table-column
        label="Action"
        width="200"
      >
        <template slot-scope="scope">
          <div>
            <el-button type="primary">
              <!-- $t('key'): i18n multiple language -->
              {{ $t('table.edit') }}
            </el-button>
            <el-button
              type="danger"
              @click="deleteUser(scope.row.id)"
            >
              {{ $t('table.delete') }}
            </el-button>
          </div>
        </template>
      </el-table-column>
    </el-table>

    <AddUserDiablog
      ref="AddUserDiablog"
      @created="fetchUsers()"
    />
  </div>
</template>

<script lang="ts">
import { Component, Vue, Ref } from 'vue-property-decorator';
import { UsersModule } from '@/store/modules/management/users';
import AddUserDiablog from './components/add-user-dialog.vue';
import { MessageBox } from 'element-ui';

@Component({
  name: 'Users',
  components: {
    AddUserDiablog
  }
})
export default class extends Vue {
  users: any[] = [];

  @Ref('AddUserDiablog')
  private AddUserDiablog!: AddUserDiablog;

  private async mounted() {
    await this.fetchUsers();
  }

  private async fetchUsers() {
    const { result } = await UsersModule.getAllUsers({});
    this.users = result?.items;
  }

  private deleteUser(id: string) {
    MessageBox.confirm(this.$t('management.users.confirmDeleteMessage').toString(), this.$t('management.users.confirmDelete').toString(), {
      type: 'warning'
    }).then(async() => {
      await UsersModule.deleteUser(id);
      await this.fetchUsers();
    }).catch(error => {
      console.error(error);
    });
  }
}
</script>
