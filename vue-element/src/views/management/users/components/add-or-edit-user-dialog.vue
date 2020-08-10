<template>
  <el-dialog
    :title="isEdit ? $t('management.users.editUser') : $t('management.users.addUser')"
    :visible.sync="dialogVisible"
    @closed="addUserForm.clearValidate()"
  >
    <!-- Dialog Content -->
    <el-form
      ref="addUserForm"
      :model="form"
      :rules="rules"
      label-width="150px"
      status-icon
    >
      <!-- UserName -->
      <el-form-item
        :label="$t('management.users.userName')"
        prop="userName"
      >
        <el-input
          v-model="form.userName"
          autocomplete="off"
        />
      </el-form-item>
      <!-- Password -->
      <el-form-item
        v-if="!isEdit"
        :label="$t('management.users.password')"
        prop="password"
      >
        <el-input
          v-model="form.password"
          type="password"
          autocomplete="off"
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
      <!-- Role -->
      <el-form-item
        label="Role"
        prop="roleNames"
      >
        <el-select
          v-model="form.roleNames"
          placeholder="Role Name"
          multiple
        >
          <el-option
            label="Admin"
            value="admin"
          />
          <el-option
            label="Editor"
            value="editor"
          />
        </el-select>
      </el-form-item>
      <!-- Active -->
      <el-form-item
        label="Active"
        prop="isActive"
      >
        <el-switch v-model="form.isActive" />
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
      >{{ isEdit ? $t('management.users.updateUser') : $t('management.users.addUser') }}</el-button>
    </span>
  </el-dialog>
</template>

<script lang="ts">
import { Component, Vue, Ref, Emit } from 'vue-property-decorator';
import TodoList from './components/TodoList/index.vue';
import { IUserPayload } from '@/types/management/users';
import { ElForm } from 'element-ui/types/form';
import { UserModule } from '@/store/modules/user';
import { UsersModule } from '@/store/modules/management/users';
import { EventEmitter } from 'events';

const defaultUserParams: IUserPayload = {
  name: '',
  surname: '',
  userName: '',
  emailAddress: '',
  isActive: true,
  roleNames: [],
  password: ''
};

@Component({
  name: 'AddOrEditUserDiablog'
})
export default class AddOrEditUserDiablog extends Vue {
  @Ref('addUserForm')
  private addUserForm!: ElForm;
  private form: IUserPayload = { ...defaultUserParams };
  private dialogVisible: boolean = false;

  private rules = {
    name: [
      { required: true, message: 'Please input your name', trigger: 'blur' }
    ],
    surname: [
      { required: true, message: 'Please input your surname', trigger: 'blur' }
    ],
    userName: [
      { required: true, message: 'Please input your user name', trigger: 'blur' }
    ],
    emailAddress: [
      { required: true, message: 'Please input your email address', trigger: 'blur' },
      { type: 'email', message: 'Please input correct email address', trigger: ['blur'] }
    ],
    roleNames: [
      { required: true, message: 'Please input your role name', trigger: ['blur'] }
    ],
    password: [
      { required: true, message: 'Please input your password', trigger: 'blur' }
    ]
  }

  get isEdit(): boolean {
    return !!this.form.id?.toString();
  }

  private async submit() {
    const isValid = await this.addUserForm.validate();
    if (isValid) {
      if (this.isEdit) {
        await UsersModule.updateUser(this.form);
      } else {
        await UsersModule.createUser(this.form);
      }
      this.addUserForm.clearValidate();
      this.submitted();
      this.close();
    }
  }

  @Emit('submitted')
  private submitted() {
    return true;
  }

  public open(user?: IUserPayload) {
    if (user) {
      this.form = { ...user };
    } else {
      this.form = { ...defaultUserParams };
    }
    this.dialogVisible = true;
  }

  public close() {
    this.form = { ...defaultUserParams };
    this.addUserForm.clearValidate();
    this.dialogVisible = false;
  }
}
</script>

<style lang="scss" scoped>
</style>
