import axios from '@/libs/api.request'

export const getUserQuotaBaseLine = (data) => {
  return axios.request({
    url: 'api/analysis/GetUserQuotaBaseLine',
    params:data,
    method: 'get'
  })
}

export const getUserQuota = (data) => {
  return axios.request({
    url: 'api/analysis/GetUserQuota',
    params:data,
    method: 'get'
  })
}


export const markCountWithMarkUser = (data) => {
    return axios.request({
      url: 'api/analysis/GetMarkCountWithMarkUser/',
      params:data,
      method: 'get'
    })
  }

  export const markAvgTimeWithMarkUser = (data) => {
    return axios.request({
      url: 'api/analysis/MarkAvgTimeWithMarkUser/',
      params:data,
      method: 'get'
    })
  }

  export const getPartOfOperateCountWithUser = (data) => {
    return axios.request({
      url: 'api/analysis/GetPartOfOperateCountWithUser',
      params:data,
      method: 'get'
    })
  }

  
  export const getPreparePlayWithUser = (data) => {
    return axios.request({
      url: 'api/analysis/GetPreparePlayWithUser',
      params:data,
      method: 'get'
    })
  }
  
  
  
  