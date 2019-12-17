import axios from '@/libs/api.request'

export const getTotalData = () => {
    return axios.request({
      url: 'api/Home/GetAdminTotalData/',
      method: 'get',
    })
  }

export const getCheckTypeCount=()=>{
  return axios.request({
    url: 'api/Home/GetCheckTypeCount/',
    method: 'get',
  })
}

export const getMarkUserActivation=()=>{
  return axios.request({
    url: 'api/Home/GetMarkUserActivation/',
    method: 'get',
  })
}


export const getEveryDayMarkCount=()=>{
  return axios.request({
    url: 'api/Home/GetEveryDayMarkCount/',
    method: 'get',
  })
}




