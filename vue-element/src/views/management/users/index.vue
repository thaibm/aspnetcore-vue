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

      <el-table-column label="Action">
        <template>
          <div>
            <el-button type="primary">
              <!-- $t('key'): i18n multiple language -->
              {{ $t('table.edit') }}
            </el-button>
            <el-button type="danger">
              {{ $t('table.delete') }}
            </el-button>
          </div>
        </template>
      </el-table-column>
    </el-table>

    <AddUserDiablog ref="AddUserDiablog" />
  </div>
</template>

<script lang="ts">
import { Component, Vue, Ref } from 'vue-property-decorator';
import { UsersModule } from '@/store/modules/management/users';
import AddUserDiablog from './components/add-user-dialog.vue';

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
    const { result } = await UsersModule.getAllUsers({});
    this.users = result?.items;
  }
}
</script>
