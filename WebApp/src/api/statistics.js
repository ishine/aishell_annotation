import axios from '@/libs/api.request'


export const getMarkTaskTeamDataStatistics = (data) => {
    return axios.request({
      url: 'api/Statistics/GetMarkTaskTeamDataStatistics',
      params:data,
      method: 'get'
    })
  }


  export const getTaskDataStatistics = (data) => {
    return axios.request({
      url: 'api/Statistics/getTaskDataStatistics',
      params:data,
      method: 'get'
    })
  }

  export const getCheckDataStatistics = (data) => {
    return axios.request({
      url: 'api/Statistics/GetCheckDataStatistics',
      params:data,
      method: 'get'
    })
  }



  

  