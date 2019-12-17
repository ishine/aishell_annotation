import axios from '@/libs/api.request'


export const getTaskItemMarks = (taskItemId) => {
  return axios.request({
    url: 'api/Mark/GetTaskItemMarks/'+taskItemId,
    method: 'get',
  })
}


export const saveMark = (data) => {
    return axios.request({
      url: 'api/Mark/SaveMark/',
      data:data,
      method: 'post',
    })
  }

  export const removeMark = (data) => {
    return axios.request({
      url: 'api/Mark/RemoveMark/',
      data:data,
      method: 'post',
    })
  }


  export const nextAndSave = (data) => {
    return axios.request({
      url: 'api/Mark/NextAndSave/',
      data:data,
      method: 'post',
    })
  }

  export const lastMark = (data) => {
    return axios.request({
      url: 'api/Mark/Last/',
      data:{taskItemId:data},
      method: 'post',
    })
  }

  
  export const nextMark = (data) => {
    return axios.request({
      url: 'api/Mark/Next/',
      data:{taskItemId:data},
      method: 'post',
    })
  }

  export const lastReMark = (data) => {
    return axios.request({
      url: 'api/Mark/LastRemark/',
      data:{reMarkTaskItemId:data},
      method: 'post',
    })
  }

 
  export const nextReMark = (data) => {
    return axios.request({
      url: 'api/Mark/NextRemark/',
      data:{reMarkTaskItemId:data},
      method: 'post',
    })
  }


  
export const saveImageMark = (data) => {
  return axios.request({
    url: 'api/Mark/SaveImageMark/',
    data:data,
    method: 'post',
  })
}


export const getTaskItemImageMarks = (taskItemId) => {
  return axios.request({
    url: 'api/Mark/GetTaskItemImageMarks/'+taskItemId,
    method: 'get',
  })
}