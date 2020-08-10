<template>
  <div class="app-container">
    <div class="page-header">
      <el-input
        v-model="searchString"
        class="search-box"
        placeholder="Search UserName or Name"
        @input="search()"
      />
      <el-button
        type="primary"
        @click="AddOrEditUserDiablog.open()"
      >
        <!-- $t('key'): i18n multiple language -->
        {{ $t('table.add') }}
      </el-button>
    </div>

    <el-table
      v-loading="isLoading"
      class="table"
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
        align="right"
      >
        <template slot-scope="scope">
          <div>
            <el-button
              type="primary"
              @click="openEditUserDialog(scope.row)"
            >
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

    <el-pagination
      class="pagination"
      background
      layout="prev, pager, next"
      :total="totalCount"
      :page-size="pageSize"
      :current-page="currentPage"
      @current-change="onCurrentPageChange"
    />

    <AddOrEditUserDiablog
      ref="AddOrEditUserDiablog"
      @submitted="fetchUsers()"
    />
  </div>
</template>

<script lang="ts">
import { Component, Vue, Ref } from 'vue-property-decorator';
import { UsersModule } from '@/store/modules/management/users';
import AddOrEditUserDiablog from './components/add-or-edit-user-dialog.vue';
import { MessageBox } from 'element-ui';
import { IUser } from '@/types/management/users';
import { debounce } from 'lodash';

@Component({
  name: 'Users',
  components: {
    AddOrEditUserDiablog
  }
})
export default class extends Vue {
  isLoading: boolean = true;
  users: IUser[] = [];
  totalCount: number = 0;
  pageSize: number = 2;
  currentPage: number = 1;
  searchString: string = '';
  search!: () => void;

  @Ref('AddOrEditUserDiablog')
  private AddOrEditUserDiablog!: AddOrEditUserDiablog;

  private async mounted() {
    this.search = debounce(() => {
      this.currentPage = 1;
      this.fetchUsers();
    }, 500);
    await this.fetchUsers();
  }

  private async fetchUsers() {
    this.isLoading = true;
    const { result } = await UsersModule.getAllUsers({
      skipCount: (this.currentPage - 1) * this.pageSize,
      maxResultCount: this.pageSize,
      keyword: this.searchString
    });
    this.users = result?.items;
    this.totalCount = result?.totalCount;
    this.isLoading = false;
  }

  private deleteUser(id: string) {
    MessageBox.confirm(
      this.$t('management.users.confirmDeleteMessage').toString(),
      this.$t('management.users.confirmDelete').toString(),
      { type: 'warning' }
    ).then(async () => {
      await UsersModule.deleteUser(id);
      await this.fetchUsers();
    }).catch(error => {
      console.error(error);
    });
  }

  private openEditUserDialog(userRow: IUser) {
    this.AddOrEditUserDiablog.open({
      userName: userRow.userName,
      name: userRow.name,
      surname: userRow.surname,
      emailAddress: userRow.emailAddress,
      isActive: userRow.isActive,
      roleNames: userRow.roleNames,
      id: userRow.id
    });
  }

  private onCurrentPageChange(pageNumber: number) {
    this.currentPage = pageNumber;
    this.fetchUsers();
  }
}
</script>

<style lang="scss" scoped>
.page-header {
  display: flex;
  justify-content: space-between;

  .search-box {
    margin-right: 15px;
  }
}

.table {
  margin-top: 10px;
}

.pagination {
  display: flex;
  justify-content: center;
  margin-top: 30px;
}
</style>
