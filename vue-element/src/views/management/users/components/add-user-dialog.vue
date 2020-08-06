<template>
  <el-dialog
    title="Add User"
    :visible.sync="dialogVisible"
  >
    <!-- Dialog Content -->
    <el-form
      ref="addUserForm"
      :model="form"
      :rules="rules"
    >
      <!-- UserName -->
      <el-form-item
        :label="$t('management.users.userName')"
        prop="userName"
      >
        <el-input v-model="form.userName" />
      </el-form-item>
      <!-- Password -->
      <el-form-item
        :label="$t('management.users.password')"
        prop="password"
      >
        <el-input
          v-model="form.password"
          type="password"
        />
      </el-form-item>
      <!-- Name -->
      <el-form-item
        :label="$t('management.users.name')"
        prop="name"
      >
        <el-input v-model="form.name" />
      </el-form-item>
      <!-- Surname -->
      <el-form-item
        :label="$t('management.users.surname')"
        prop="surname"
      >
        <el-input v-model="form.surname" />
      </el-form-item>
      <!-- Email Address -->
      <el-form-item
        :label="$t('management.users.emailAddress')"
        prop="emailAddress"
      >
        <el-input v-model="form.emailAddress" />
      </el-form-item>
      <!-- Active -->
      <el-form-item
        label="Active"
        prop="isActive"
      >
        <el-switch v-model="form.isActive" />
      </el-form-item>
      <!-- Role -->
      <el-form-item
        label="Role"
        prop="roleNames"
      >
        <el-select
          v-model="form.roleNames"
          placeholder="Role Name"
        >
          <el-option
            label="Admin"
            value="admin"
          />
        </el-select>
      </el-form-item>
    </el-form>
    <!-- Dialog Footer -->
    <span
      slot="footer"
      class="dialog-footer"
    >
      <el-button @click="close()">Cancel</el-button>
      <el-button
        type="primary"
        @click="submit()"
      >Add User</el-button>
    </span>
  </el-dialog>
</template>

<script lang="ts">
import { Component, Vue, Ref } from 'vue-property-decorator';
import TodoList from './components/TodoList/index.vue';
import { IUserParams } from '@/types/management/users';
import { ElForm } from 'element-ui/types/form';

@Component({
  name: 'AddUserDiablog'
})
export default class AddUserDiablog extends Vue {
  @Ref('addUserForm')
  private addUserForm!: ElForm;

  private dialogVisible: boolean = false;
  private form: IUserParams = {
    name: '',
    surname: '',
    userName: '',
    emailAddress: '',
    isActive: true,
    roleNames: '',
    password: ''
  };

  private rules = {
    name: [
      { required: true, message: 'Please input your name', trigger: 'change' }
    ],
    surname: [
      { required: true, message: 'Please input your surname', trigger: 'change' }
    ],
    userName: [
      { required: true, message: 'Please input your user name', trigger: 'change' }
    ],
    emailAddress: [
      { required: true, message: 'Please input your email address', trigger: 'change' },
      { type: 'email', message: 'Please input correct email address', trigger: ['blur', 'change'] }
    ],
    roleNames: [
      { required: true, message: 'Please input your role name', trigger: ['blur', 'change'] }
    ],
    password: [
      { required: true, message: 'Please input your password', trigger: 'change' }
    ]
  }

  private async submit() {
    const isValid = await this.addUserForm.validate();
  }

  public open() {
    this.dialogVisible = true;
  }

  public close() {
    this.dialogVisible = false;
  }
}
</script>

<style lang="scss" scoped>
</style>
