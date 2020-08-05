import { Message } from 'element-ui';
import { getAllUsersAPI } from '@/api/management/users';
import { VuexModule, Module, Mutation, Action, getModule } from 'vuex-module-decorators';
import store from '@/store';

export interface IUsersState {

}

@Module({ dynamic: true, store, name: 'users' })
class Users extends VuexModule implements IUsersState {
  @Action
  public async getAllUsers(params: any) {
    try {
      const { data } = await getAllUsersAPI(params);
      return data;
    } catch (error) {
      Message.error(error);
      return [];
    }
  }
}

export const UsersModule = getModule(Users);
