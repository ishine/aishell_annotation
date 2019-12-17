import axios from '@/libs/api.request'


export const getCheckItem = (id) => {
  return axios.request({
    url: 'api/Check/GetCheckItem',
    params:{id:id},
    method: 'get',
  })
}





export const getCheckPackage = (checkTaskId,checkStatus,result, page,size) => {
  const data = {
    checkTaskId,
    checkStatus,
    result,
    page,
    size
  }
  return axios.request({
    url: 'api/Check/GetCheckPackage',
    params:data,
    method: 'get',
  })
}

export const getCheckPackageItems = (checkPackageId,page,size) => {
  const data = {
    checkPackageId,
    page,
    size
  }
  return axios.request({
    url: 'api/Check/GetCheckPackageItems',
    params:data,
    method: 'get',
  })
}

export const getCheckItems = (checkTaskId,team,page,size,result) => {
  const data = {
    checkTaskId,
    team,
    page,
    size,
    result
  }
  return axios.request({
    url: 'api/Check/GetCheckItems',
    params:data,
    method: 'get',
  })
}

export const getCheckTaskItemCount = (id,teamId) => {
  const data = {
    id,
    teamId,
  }
  return axios.request({
    url: 'api/Check/GetCheckTaskItemCount',
    params:data,
    method: 'get',
  })
}





export const getReMarkList = (taskId,status,page,size) => {
  const data = {
    taskId,
    status,
    page,
    size
  }
  return axios.request({
    url: 'api/Check/GetReMarkList',
    params:data,
    method: 'get',
  })
}

export const getReMarkTaskItemList = ({checkTaskPackageId,page,size}) => {
  const data = {
    checkTaskPackageId,
    page,
    size
  }
  return axios.request({
    url: 'api/Check/GetReCheckPackageItems',
    params:data,
    method: 'get',
  })
}





export const getCheckList = ({status,taskType,taskName, page,size}) => {
  const data = {
    status,
    taskType,
    taskName,
    page,
    size
  }
  return axios.request({
    url: 'api/Check/CheckTaskList',
    params:data,
    method: 'get',
  })
}

export const getCheckListByTaskId = (taskId) => {
 
  return axios.request({
    url: 'api/Check/CheckTaskListByTaskId/'+taskId,
    params:null,
    method: 'get',
  })
}


export const getCheckTaskCount = (status) => {
  const data = {
    status,
  }
  return axios.request({
    url: 'api/Check/GetCheckTaskCount',
    params:data,
    method: 'get',
  })
}



export const getCheckTask = (id) => {
  return axios.request({
    url: 'api/Check/GetCheckTask/'+id,
    method: 'get',
  })
}



 export const startCheckByTask = (checkTaskId) => {
    return axios.request({
      url: 'api/Check/StartCheckByTask',
      data:{value:checkTaskId},
      method: 'post',
    })
  }

  export const startCheckByPackage = (checkPackageId) => {
    return axios.request({
      url: 'api/Check/StartCheckByPackage',
      data:{value:checkPackageId},
      method: 'post',
    })
  }

  
  export const saveCheck = (data) => {
    return axios.request({
      url: 'api/Check/SaveCheck',
      data:data,
      method: 'post',
    })
  }


  export const saveCheckTask = (data) => {
    return axios.request({
      url: 'api/Check/AddCheckTask',
      data:data,
      method: 'post'
    })
  }

  export const saveReCheckTask = (data) => {
    return axios.request({
      url: 'api/Check/AddReCheckTask',
      data:data,
      method: 'post'
    })
  }

  export const deleteCheckTask = (id) => {
    return axios.request({
      url: 'api/Check/DeleteCheckTask',
      data:{value:id},
      method: 'post'
    })
  }

 

  export const saveFinishPackage = (data) => {
    return axios.request({
      url: 'api/Check/SaveFinishPackage',
      data:data,
      method: 'post'
    })
  }
  
  export const saveFinishTask = (data) => {
    return axios.request({
      url: 'api/Check/SaveFinishTask',
      data:data,
      method: 'post'
    })
  }
  

  export const getOnePackage = (checkTaskId) => {
    return axios.request({
      url: 'api/Check/GetOnePackage',
      data:{id:checkTaskId},
      method: 'post'
    })
  }
  

  
  
  // export const createCheckPackage = (id) => {
  //   return axios.request({
  //     url: 'api/Check/CreateCheckPackage',
  //     data:{value:id},
  //     method: 'post'
  //   })
  // }
  

  