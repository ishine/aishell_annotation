import axios from '@/libs/api.request'

export const addTemplate = (template) => {
    return axios.request({
      url: 'api/Mark/AddMarkTemplate',
      data:template,
      method: 'post'
    })
  }

  export const getTemplateList = (type) => {
    return axios.request({
      url: 'api/Mark/GetTemplateList',
      params:{type:type},
      method: 'get'
    })
  }

  export const getTemplate = (id) => {
    return axios.request({
      url: 'api/Mark/GetTemplate/'+id,
      params:{},
      method: 'get'
    })
  }

  export const deleteTemplate = (id) => {
    return axios.request({
      url: 'api/Mark/DeleteTemplate',
      data:{value:id},
      method: 'post'
    })
  }