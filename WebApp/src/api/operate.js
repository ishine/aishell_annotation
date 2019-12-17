import axios from '@/libs/api.request'
export const getList = (query) => {
    return axios.request({
      url: 'api/Operate/List',
      params:query,
      method: 'get'
    })
  }


  export const addOperate = (data) => {
    return axios.request({
      url: 'api/Operate/Add',
      data:data,
      method: 'post'
    })
  }

  //用户操作随数量分布
  export const getCountWithOperateTypeDistribution=(data)=>{
    return axios.request({
      url: 'api/Operate/GetCountWithOperateTypeDistribution',
      data:data,
      method: 'get'
    })
  }

  
  export const getCountWithUserDistribution=(data)=>{
    return axios.request({
      url: 'api/Operate/getCountWithUserDistribution',
      data:data,
      method: 'get'
    })
  }

    
  export const getCountWithOperateTimeDistribution=(data)=>{
    return axios.request({
      url: 'api/Operate/GetCountWithOperateTimeDistribution',
      data:data,
      method: 'get'
    })
  }