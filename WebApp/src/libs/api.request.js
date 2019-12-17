import HttpRequest from '@/libs/axios'
import Vue from 'vue'
import config from '@/config'

const baseUrl = process.env.NODE_ENV === 'development' ? config.baseUrl.dev : config.baseUrl.pro

Vue.prototype.$baseUrl = baseUrl;

const axios = new HttpRequest(baseUrl)
export default axios


