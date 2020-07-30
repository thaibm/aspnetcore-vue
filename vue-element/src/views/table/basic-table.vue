<template>
  <div class="app-container">
    <el-table
      :data="list"
      :border="true"
    >
      <el-table-column
        prop="username"
        label="User Name"
        min-width="50"
      />
      <el-table-column
        label="OrderID"
        min-width="30"
      >
        <template slot-scope="scope">
          {{ scope.row.orderId | orderNoFilter }}
        </template>
      </el-table-column>
      <el-table-column
        label="Price"
        min-width="10"
        align="center"
      >
        <template slot-scope="scope">
          ¥{{ scope.row.price | toThousandFilter }}
        </template>
      </el-table-column>
      <el-table-column
        label="Status"
        min-width="10"
        align="center"
      >
        <template slot-scope="{row}">
          <el-tag :type="row.status | transactionStatusFilter">
            {{ row.status }}
          </el-tag>
        </template>
      </el-table-column>
    </el-table>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import { getTransactions } from '@/api/transactions';
import { ITransactionData } from '@/api/types';

@Component({
  name: 'BasicTable',
  filters: {
    transactionStatusFilter: (status: string) => {
      const statusMap: { [key: string]: string } = {
        success: 'success',
        pending: 'danger'
      };
      return statusMap[status];
    },
    orderNoFilter: (str: string) => str.substring(0, 30),
    // Input 10000 => Output "10,000"
    toThousandFilter: (num: number) => {
      return (+num || 0).toString().replace(/^-?\d+/g, m => m.replace(/(?=(?!\b)(\d{3})+$)/g, ','));
    }
  }
})
export default class extends Vue {
  private list: ITransactionData[] = []

  created() {
    this.fetchData();
  }

  private async fetchData() {
    const { data } = await getTransactions({ /* Your params here */ });
    this.list = data.items.slice(0, 8);
  }
}
</script>
