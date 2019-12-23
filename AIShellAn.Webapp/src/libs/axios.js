import axios from 'axios'
import store from '@/store'
import { getToken } from '@/libs/util'


//配置请求的header信息
axios.defaults.headers = {
  "Content-Type": "application/json;charset=UTF-8"
};

class HttpRequest {
  constructor (baseUrl = baseURL) {
    this.baseUrl = baseUrl
    this.queue = {}
  }
  getInsideConfig () {
    const config = {
      baseURL: this.baseUrl,
      headers:{
        "Content-Type": "application/json;charset=UTF-8"
      }
    }
    return config
  }
  destroy (url) {
    delete this.queue[url]
    
  }
  interceptors (instance, url) {
    // 请求拦截
    instance.interceptors.request.use(config => {
      this.queue[url] = true
      let token=getToken();
       // 判断是否存在token，如果存在的话，则每个http header都加上token
      if (token) { 
        config.headers={
          "Content-Type": "application/json;charset=UTF-8",
          "Authorization":`Bearer ${token}`   
        };
      }
      return config
    }, error => {
       //可以在此处添加错误处理，记录本地日志等操作
      return Promise.reject(error)
    })

   
    // 响应拦截
    instance.interceptors.response.use(res => {
      this.destroy(url)
      const { data, status } = res
      return { data, status }
    }, error => {

      //可以在此处添加错误处理，记录本地日志等操作
      this.destroy(url);
      return Promise.reject(error)
    })
  }
  request (options) {
    const instance = axios.create();
    options = Object.assign(this.getInsideConfig(), options);
    this.interceptors(instance, options.url)
    return instance(options)
  }
}
export default HttpRequest
