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
        <a-form-item label="自增长数字" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['id', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="userid" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['userid', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="fundpassword" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['fundpassword', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="headurl" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['headurl', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="nick" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['nick', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="0=女 1=男" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['sex', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="用戶稱號" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['usertypeid', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="邀请码" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['invitecode', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="推广用户ID" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['refuserid', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="創建日期" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['created', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="自動標識" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['usernumid', { rules: [{ required: true, message: '必填' }] }]" />
        </a-form-item>
        <a-form-item label="開戶地址" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="['openarea', { rules: [{ required: true, message: '必填' }] }]" />
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

          this.$http.post('/Users_Manage/gax_users/GetTheData', { id: id }).then(resJson => {
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
          this.$http.post('/Users_Manage/gax_users/SaveData', this.entity).then(resJson => {
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
