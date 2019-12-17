import Vue from 'vue'
import App from './App'
import routers from './router'
import store from './store'
import iView from 'view-design'
import config from '@/config'
import importDirective from '@/directive'
import installPlugin from '@/plugins'
import 'view-design/dist/styles/iview.css';
import './index.less'
import '@/assets/icons/iconfont.css'
import localForage from "localforage";

Vue.use(iView, {
 
})

/**
 * @description 注册admin内置插件
 */
installPlugin(Vue)
/**
 * @description 生产环境关掉提示
 */
Vue.config.productionTip = false
/**
 * @description 全局注册应用配置
 */
Vue.prototype.$config = config

/**
 * 注册指令
 */
importDirective(Vue)

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router:routers,
  store,
  render: h => h(App)
})

localForage.config({
  name:"data-annotation",

});

Vue.prototype.$localForage=localForage;