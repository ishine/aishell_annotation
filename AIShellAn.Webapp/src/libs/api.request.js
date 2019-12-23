import HttpRequest from '@/libs/axios'
import Vue from 'vue'
import config from '@/config'

//根据配置信息判断开发或者生成环境，从而选择对应的接口的url前缀地址
const baseUrl = process.env.NODE_ENV === 'development' ? config.baseUrl.dev : config.baseUrl.pro

//写入全局变量
Vue.prototype.$baseUrl = baseUrl;

const axios = new HttpRequest(baseUrl)
export default axios


