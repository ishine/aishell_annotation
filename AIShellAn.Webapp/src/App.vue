<template>
  <div id="app">
    <router-view />
  </div>
</template>
<script>
import axios from 'axios'
export default {
  data() {
    return {
      iMessage:false,
    };
  },
  methods: {
    //获取服务器静态文件版本信息，如果与本地不一样则提示用户刷新页面
    async getHash() {
      // 在 js 中请求首页地址不会更新页面
      const response = await axios.get(
        `${window.location.protocol}//${window.location.host}/`
      );
      // 返回的是字符串，需要转换为 html
      let el = document.createElement("html");
      el.innerHTML = response.data;
      // 拿到 hash
      let new_hash_src = el.getElementsByTagName("script")[0].src.split("/");
      let new_hash = new_hash_src[new_hash_src.length - 1].split(".")[1];
      // iMessage 是个全局变量（默认值 false），用来帮助判断什么时候会弹出提示，不然定时器5s就弹一次了
      if (new_hash != this.cur_hash && !this.iMessage) {
        // 版本更新，弹出提示
        this.iMessage = true;
        this.$Message.info({
          render: h => {
            return h("span", [
              `平台版本已更新，请及时刷新浏览器！`,
              h(
                "a",
                {
                  on: {
                    click: function() {
                      window.location.reload();
                    }
                  }
                },
                "刷新页面"
              )
            ]);
          },
          duration: 0,
          closable: false
        });
      }
    }
  },
  mounted(){
      
      // 当前版本的 hash
      let cur_hash_src = document.getElementsByTagName('body')[0].getElementsByTagName('script')[0].src.split('/')
      this.cur_hash = cur_hash_src[cur_hash_src.length - 1].split('.')[1]
      // 定时器五分钟轮询一次，timerVersion 是全局变量，默认值为 null
      this.timerVersion = setInterval(this.getHash, 60000);
  }
};
</script>

<style lang="less">
.size {
  width: 100%;
  height: 100%;
}
html,
body {
  .size;
  overflow: hidden;
  margin: 0;
  padding: 0;
}
#app {
  .size;
}
</style>
