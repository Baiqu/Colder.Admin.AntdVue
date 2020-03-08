<template>
  <a-card :bordered="false">
    <div class="table-operator">
      <a-button type="primary" icon="plus" @click="hanldleAdd()">新建</a-button>
      <a-button
        type="primary"
        icon="minus"
        @click="handleDelete(selectedRowKeys)"
        :disabled="!hasSelected()"
        :loading="loading"
      >删除</a-button>
      <a-button type="primary" icon="redo" @click="getDataList()">刷新</a-button>
    </div>

    <div class="table-page-search-wrapper">
      <a-form layout="inline">
        <a-row :gutter="10">
          <a-col :md="4" :sm="24">
            <a-form-item label="查询类别">
              <a-select allowClear v-model="queryParam.condition">
                <a-select-option key="UpstreamPathTemplate">UpstreamPathTemplate</a-select-option>
                <a-select-option key="UpstreamHttpMethod">UpstreamHttpMethod</a-select-option>
                <a-select-option key="UpstreamHost">UpstreamHost</a-select-option>
                <a-select-option key="DownstreamScheme">DownstreamScheme</a-select-option>
                <a-select-option key="DownstreamPathTemplate">DownstreamPathTemplate</a-select-option>
                <a-select-option key="DownstreamHostAndPorts">DownstreamHostAndPorts</a-select-option>
                <a-select-option key="AuthenticationOptions">AuthenticationOptions</a-select-option>
                <a-select-option key="RequestIdKey">RequestIdKey</a-select-option>
                <a-select-option key="CacheOptions">CacheOptions</a-select-option>
                <a-select-option key="ServiceName">ServiceName</a-select-option>
                <a-select-option key="QoSOptions">QoSOptions</a-select-option>
                <a-select-option key="LoadBalancerOptions">LoadBalancerOptions</a-select-option>
                <a-select-option key="Key">Key</a-select-option>
                <a-select-option key="DelegatingHandlers">DelegatingHandlers</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :md="4" :sm="24">
            <a-form-item>
              <a-input v-model="queryParam.keyword" placeholder="关键字" />
            </a-form-item>
          </a-col>
          <a-col :md="6" :sm="24">
            <a-button type="primary" @click="getDataList">查询</a-button>
            <a-button style="margin-left: 8px" @click="() => (queryParam = {})">重置</a-button>
          </a-col>
        </a-row>
      </a-form>
    </div>

    <a-table
      ref="table"
      :columns="columns"
      :rowKey="row => row.Id"
      :dataSource="data"
      :pagination="pagination"
      :loading="loading"
      @change="handleTableChange"
      :rowSelection="{ selectedRowKeys: selectedRowKeys, onChange: onSelectChange }"
      :bordered="true"
      size="small"
    >
      <span slot="action" slot-scope="text, record">
        <template>
          <a @click="handleEdit(record.Id)">编辑</a>
          <a-divider type="vertical" />
          <a @click="handleDelete([record.Id])">删除</a>
        </template>
      </span>
    </a-table>

    <edit-form ref="editForm" :parentObj="this"></edit-form>
  </a-card>
</template>

<script>
import EditForm from './EditForm'

const columns = [
  { title: 'OcelotGlobalConfigurationId', dataIndex: 'OcelotGlobalConfigurationId', width: '10%' },
  { title: 'UpstreamPathTemplate', dataIndex: 'UpstreamPathTemplate', width: '10%' },
  { title: 'UpstreamHttpMethod', dataIndex: 'UpstreamHttpMethod', width: '10%' },
  { title: 'UpstreamHost', dataIndex: 'UpstreamHost', width: '10%' },
  { title: 'DownstreamScheme', dataIndex: 'DownstreamScheme', width: '10%' },
  { title: 'DownstreamPathTemplate', dataIndex: 'DownstreamPathTemplate', width: '10%' },
  { title: 'DownstreamHostAndPorts', dataIndex: 'DownstreamHostAndPorts', width: '10%' },
  { title: 'AuthenticationOptions', dataIndex: 'AuthenticationOptions', width: '10%' },
  { title: 'RequestIdKey', dataIndex: 'RequestIdKey', width: '10%' },
  { title: 'CacheOptions', dataIndex: 'CacheOptions', width: '10%' },
  { title: 'ServiceName', dataIndex: 'ServiceName', width: '10%' },
  { title: 'QoSOptions', dataIndex: 'QoSOptions', width: '10%' },
  { title: 'LoadBalancerOptions', dataIndex: 'LoadBalancerOptions', width: '10%' },
  { title: 'Key', dataIndex: 'Key', width: '10%' },
  { title: 'DelegatingHandlers', dataIndex: 'DelegatingHandlers', width: '10%' },
  { title: 'Priority', dataIndex: 'Priority', width: '10%' },
  { title: 'Timeout', dataIndex: 'Timeout', width: '10%' },
  { title: 'IsStatus', dataIndex: 'IsStatus', width: '10%' },
  { title: 'AddTime', dataIndex: 'AddTime', width: '10%' },
  { title: '操作', dataIndex: 'action', scopedSlots: { customRender: 'action' } }
]

export default {
  components: {
    EditForm
  },
  mounted() {
    this.getDataList()
  },
  data() {
    return {
      data: [],
      pagination: {
        current: 1,
        pageSize: 10,
        showTotal: (total, range) => `总数:${total} 当前:${range[0]}-${range[1]}`
      },
      filters: {},
      sorter: { field: 'Id', order: 'asc' },
      loading: false,
      columns,
      queryParam: {},
      selectedRowKeys: []
    }
  },
  methods: {
    handleTableChange(pagination, filters, sorter) {
      this.pagination = { ...pagination }
      this.filters = { ...filters }
      this.sorter = { ...sorter }
      this.getDataList()
    },
    getDataList() {
      this.selectedRowKeys = []

      this.loading = true
      this.$http
        .post('/Ocelot_Manage/OcelotReRoutes/GetDataList', {
          PageIndex: this.pagination.current,
          PageRows: this.pagination.pageSize,
          SortField: this.sorter.field || 'Id',
          SortType: this.sorter.order,
          ...this.queryParam,
          ...this.filters
        })
        .then(resJson => {
          this.loading = false
          this.data = resJson.Data
          const pagination = { ...this.pagination }
          pagination.total = resJson.Total
          this.pagination = pagination
        })
    },
    onSelectChange(selectedRowKeys) {
      this.selectedRowKeys = selectedRowKeys
    },
    hasSelected() {
      return this.selectedRowKeys.length > 0
    },
    hanldleAdd() {
      this.$refs.editForm.openForm()
    },
    handleEdit(id) {
      this.$refs.editForm.openForm(id)
    },
    handleDelete(ids) {
      var thisObj = this
      this.$confirm({
        title: '确认删除吗?',
        onOk() {
          return new Promise((resolve, reject) => {
            thisObj.$http.post('/Ocelot_Manage/OcelotReRoutes/DeleteData', { ids: JSON.stringify(ids) }).then(resJson => {
              resolve()

              if (resJson.Success) {
                thisObj.$message.success('操作成功!')

                thisObj.getDataList()
              } else {
                thisObj.$message.error(resJson.Msg)
              }
            })
          })
        }
      })
    }
  }
}
</script>