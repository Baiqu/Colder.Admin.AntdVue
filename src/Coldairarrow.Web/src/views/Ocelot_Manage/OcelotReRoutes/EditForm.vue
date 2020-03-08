<template>
  <a-modal
    :title="title"
    width="40%"
    :visible="visible"
    :confirmLoading="loading"
    @ok="handleSubmit"
    @cancel="handleCancel"
  >
    <a-spin :spinning="loading">
      <a-form :form="form">
        <a-form-item label="OcelotGlobalConfigurationId" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['OcelotGlobalConfigurationId', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="UpstreamPathTemplate" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['UpstreamPathTemplate', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="UpstreamHttpMethod" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['UpstreamHttpMethod', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="UpstreamHost" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['UpstreamHost', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="DownstreamScheme" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['DownstreamScheme', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="DownstreamPathTemplate" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['DownstreamPathTemplate', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="DownstreamHostAndPorts" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['DownstreamHostAndPorts', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="AuthenticationOptions" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['AuthenticationOptions', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="RequestIdKey" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['RequestIdKey', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="CacheOptions" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['CacheOptions', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="ServiceName" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['ServiceName', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="QoSOptions" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['QoSOptions', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="LoadBalancerOptions" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['LoadBalancerOptions', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="Key" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['Key', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="DelegatingHandlers" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['DelegatingHandlers', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="Priority" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['Priority', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="Timeout" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['Timeout', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="IsStatus" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['IsStatus', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="AddTime" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['AddTime', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
      </a-form>
    </a-spin>
  </a-modal>
</template>

<script>
export default {
  props: {
    parentObj: Object
  },
  data() {
    return {
      form: this.$form.createForm(this),
      labelCol: { xs: { span: 24 }, sm: { span: 7 } },
      wrapperCol: { xs: { span: 24 }, sm: { span: 13 } },
      visible: false,
      loading: false,
      formFields: {},
      entity: {},
      title: ''
    }
  },
  methods: {
    openForm(id, title) {
      //参数赋值
      this.title = title || '编辑表单'
      this.loading = true

      //组件初始化
      this.init()

      //编辑赋值
      if (id) {
        this.$nextTick(() => {
          this.formFields = this.form.getFieldsValue()

          this.$http.post('/Ocelot_Manage/OcelotReRoutes/GetTheData', { id: id }).then(resJson => {
            this.entity = resJson.Data
            var setData = {}
            Object.keys(this.formFields).forEach(item => {
              setData[item] = this.entity[item]
            })
            this.form.setFieldsValue(setData)
            this.loading = false
          })
        })
      } else {
        this.loading = false
      }
    },
    init() {
      this.entity = {}
      this.form.resetFields()
      this.visible = true
    },
    handleSubmit() {
      this.form.validateFields((errors, values) => {
        //校验成功
        if (!errors) {
          this.entity = Object.assign(this.entity, this.form.getFieldsValue())

          this.loading = true
          this.$http.post('/Ocelot_Manage/OcelotReRoutes/SaveData', this.entity).then(resJson => {
            this.loading = false

            if (resJson.Success) {
              this.$message.success('操作成功!')
              this.visible = false

              this.parentObj.getDataList()
            } else {
              this.$message.error(resJson.Msg)
            }
          })
        }
      })
    },
    handleCancel() {
      this.visible = false
    }
  }
}
</script>
