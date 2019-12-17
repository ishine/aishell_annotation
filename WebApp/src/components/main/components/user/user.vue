<template>
  <div class="user-avator-dropdown" >
    <Dropdown @on-click="handleClick" :transfer="true">
      <Avatar :src="userAvator"/>
      <Icon :size="18" type="md-arrow-dropdown"></Icon>
      <DropdownMenu slot="list" >
         <DropdownItem name="editInfo">修改密码</DropdownItem>
        <DropdownItem name="logout">退出登录</DropdownItem>
      </DropdownMenu>
    </Dropdown>
   
  </div>

</template>

<script>
import './user.less'
import { mapActions } from 'vuex'

export default {
  components:{
  },
  name: 'User',
  props: {
    userAvator: {
      type: String,
      default: ''
    }
  },
  data(){
    return {
     
    }
  },
  methods: {
    ...mapActions([
      'handleLogOut'
    ]),
    handleClick (name) {
      switch (name) {
        case 'logout':
          this.handleLogOut().then(() => {
            this.$router.push({
              name: 'login'
            })
          })
          break;
          case 'editInfo':
           this.$router.push({
             name:"changePassword"
           });
          break;
      }
    }
  }
}
</script>
