import axios from '@/libs/api.request'

export const saveTask = (data) => {
    return axios.request({
      url: 'api/Task/Add',
      data:data,
      method: 'post'
    })
  }

  export const getAllMyTaskList = () => {
    return axios.request({
      url: 'api/Task/GetAllMyTaskList',
      params:{},
      method: 'get',
    })
  }

  export const getTask = (taskId) => {
    return axios.request({
      url: 'api/Task/Get/'+taskId,
      params:{},
      method: 'get',
    })
  }

  export const getTaskList = ({taskName,status, page,size}) => {
    const data = {
        taskName,
        status,
      page,
      size
    }
    return axios.request({
      url: 'api/Task/List',
      params:data,
      method: 'get',
    })
  }


  export const reciveTask = (taskId) => {
    return axios.request({
      url: 'api/Task/Recive',
      data:{value:taskId},
      method: 'post'
    })
  }

  export const getWaitReciveTask = ({taskName,page,size}) => {
    const data = {
      taskName,
    page,
    size
  }
    return axios.request({
      url: 'api/Task/WaitReciveList',
      params:data,
      method: 'get',
    })
  }


  export const getMyTask = ({taskName,page,size}) => {
    const data = {
      taskName,
    page,
    size
  }
    return axios.request({
      url: 'api/Task/MyList',
      params:data,
      method: 'get',
    })
  }

  export const getMyTeamTask = ({taskName,page,size}) => {
    const data = {
      taskName,
    page,
    size
  }
    return axios.request({
      url: 'api/Task/MyTeamTaskList',
      params:data,
      method: 'get',
    })
  }

  



  export const getTaskItemList = (data) => {
    return axios.request({
      url: 'api/Task/TaskItemList',
      params:data,
      method: 'get',
    })
  }

  export const getTaskPackageList = (data) => {
    return axios.request({
      url: 'api/Task/TaskPackageList',
      params:data,
      method: 'get',
    })
  }

  export const getMyPackageList = ({taskId,page,size}) => {
    const data = {
      taskId,
      page,
      size
    }
    return axios.request({
      url: 'api/Task/MyTaskPackageList',
      params:data,
      method: 'get',
    })
  }



  export const getTaskItem = (itemId) => {
    return axios.request({
      url: 'api/Task/GetTaskItem',
      params:{id:itemId},
      method: 'get',
    })
  }

  export const getTaskItemText = (itemId,number) => {
    return axios.request({
      url: 'api/Task/GetTaskItemText',
      params:{
        id:itemId,
        number:number
      },
      method: 'get',
    })
  }

  export const deleteTask = (taskId) => {
    return axios.request({
      url: 'api/Task/Delete',
      data:{value:taskId},
      method: 'post',
    })
  }

  
  export const publishTask = (taskId) => {
    return axios.request({
      url: 'api/Task/Publish',
      data:{value:taskId},
      method: 'post',
    })
  }

  export const getPackage = (taskId) => {
    return axios.request({
      url: 'api/Task/GetPackage',
      data:{value:taskId},
      method: 'post',
    })
  }

 export const startMark = (packageId) => {
    return axios.request({
      url: 'api/Mark/StartMark',
      data:{value:packageId},
      method: 'post',
    })
  }

  
 export const startReMark = (packageId) => {
  return axios.request({
    url: 'api/Mark/StartReMark',
    data:{value:packageId},
    method: 'post',
  })
}

  export const createPackage = (data) => {
    return axios.request({
      url: 'api/Task/CreatePackage',
      data:data,
      method: 'post',
    })
  }


  export const managerList = ({taskName,status,page,size}) => {
    const data = {
      taskName,
      status,
      page,
      size
    }
    return axios.request({
      url: 'api/Task/ManagerList',
      params:data,
      method: 'get',
    })
  }

  export const getMarkTaskList = () => {
    return axios.request({
      url: 'api/Task/GetWaitCheckMarkTaskList',
      params:null,
      method: 'get',
    })
  }


  export const getTaskWaitCheckInfo = (taskId) => {
    return axios.request({
      url: 'api/Task/GetTaskWaitCheckInfo/'+taskId,
      params:{},
      method: 'get',
    })
  }


  export const exprotTask = (taskId) => {
    return axios.request({
      url: 'api/File/ExportTaskMarkData',
      data:{value:taskId},
      method: 'post',
      responseType: 'blob'
    })
  }

  export const getTaskCount = (taskId) => {
    return axios.request({
      url: 'api/Task/GetTaskCount',
      params:{taskId:taskId},
      method: 'get',
    })
  }

  
  

  export const recoveryPackage = (ids) => {
    let data=[];
    for(let i in ids){
      let row={id:ids[i]};
      data.push(row);
    }
   
    return axios.request({
      url: 'api/Task/RecoveryPackage',
      data:{ids:data},
      method: 'post',
    })
  }

  export const finishTask = (taskId) => {
    return axios.request({
      url: 'api/Task/FinishTask',
      data:{value:taskId},
      method: 'post',
    })
  }

  


