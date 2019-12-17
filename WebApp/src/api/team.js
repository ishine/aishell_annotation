import axios from '@/libs/api.request'
export const saveTeam = (teamItem) => {
    return axios.request({
      url: 'api/Team/Add',
      data:teamItem,
      method: 'post'
    })
  }

  export const deleteTeam = (id) => {
    return axios.request({
      url: 'api/Team/DeleteTeam',
      data:{value:id},
      method: 'post'
    })
  }

  

  export const getTeamList = (query) => {
    return axios.request({
      url: 'api/Team/List',
      params:query,
      method: 'get'
    })
  }

  export const getMyTeamList = (query) => {
    return axios.request({
      url: 'api/Team/MyTeamList',
      params:query,
      method: 'get'
    })
  }

  export const getMyBelongTeamList = (query) => {
    return axios.request({
      url: 'api/Team/MyBelongTeamList',
      params:query,
      method: 'get'
    })
  }



  export const getTeamListByManager = (id) => {
    return axios.request({
      url: 'api/Team/ManagerList/'+id,
  
      method: 'get'
    })
  }


  export const getTaskTeamList = (taskIds) => {
    return axios.request({
      url: 'api/Team/TaskTeamList',
      params:{taskIds:taskIds},
      method: 'get'
    })
  }

  export const addMember = (data) => {
      console.log(data);
  return axios.request({
    url: 'api/Team/AddMember',
    data:data,
    method: 'post'
  })
}

export const getMemberList = (teamId) => {
    return axios.request({
      url: 'api/Team/GetMemberList',
      params:{id:teamId},
      method: 'get'
    })
  }

  export const removeMember = (id) => {
    return axios.request({
      url: 'api/Team/RemoveMember',
      data:{value:id},
      method: 'post'
    })
  }

  export const setManager = (id) => {
    return axios.request({
      url: 'api/Team/SetManager',
      data:{value:id},
      method: 'post'
    })
  }

  export const saveReviceTeam = (data) => {
    return axios.request({
      url: 'api/Team/SaveReviceTeam',
      data:data,
      method: 'post'
    })
  }



  
  