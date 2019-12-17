import axios from '@/libs/api.request'

export const getRoleList = () => {
    return axios.request({
      url: 'api/Role/List',
      method: 'get'
    })
  }