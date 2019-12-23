<style lang="less">
  @import './login.less';
</style>

<template>
  <div class="login">
    <div class="login-con">
      <Card icon="log-in" title="欢迎登录" :bordered="false">
        <div class="form-con">
          <login-form @on-success-valid="handleSubmit"></login-form>
          <p class="login-tip">输入分配的用户名和密码</p>
        </div>
      </Card>
    </div>
  </div>
</template>

<script>
import LoginForm from '_c/login-form'
import { mapActions } from 'vuex'
export default {
  components: {
    LoginForm
  },
  methods: {
    ...mapActions([
      'handleLogin',
      'getUserInfo'
    ]),
    handleSubmit ({ userName, password }) {
      let _this=this;
      this.handleLogin({ userName, password }).then(res => {
         _this.getUserInfo().then(res => {
          _this.$router.push({
            name: _this.$config.homeName
          })
        })
       }).catch(err => {
            _this.$Message.error({
              content:err.data.Message
            });
        })
    }
  }
}
</script>

<style>

</style>
