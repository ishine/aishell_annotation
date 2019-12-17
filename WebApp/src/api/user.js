import axios from '@/libs/api.request'

export const login = ({ userName, password }) => {
  const data = {
    userName,
    password
  }
  console.log(data);
  return axios.request({
    url: 'api/token',
    data,
    method: 'post',
  })
}

export const simulateLogin = ({userName}) => {
  const data = {
    userName
  }
  return axios.request({
    url: 'api/User/SimulateLogin',
    data,
    method: 'post',
  })
}

export const getUserInfo = () => {
  return axios.request({
    url: 'api/User/Get',
    method: 'get'
  })
}

export const logout = () => {
  return axios.request({
    url: 'logout',
    method: 'post'
  })
}

export const getUserList = ({userName,page,size}) => {
  const data = {
    userName,
    page,
    size
  }
  return axios.request({
    url: 'api/User/List',
    params:data,
    method: 'get',
  })
}


export const getUser = (userId) => {
  return axios.request({
    url: 'api/User/Get/'+userId,
    method: 'get'
  })
}

export const getManagerList = () => {
  return axios.request({
    url: 'api/User/GetManagerList',
    method: 'get'
  })
}




export const updateUser=(userItem)=>{
  return axios.request({
    url: 'api/User/Update',
    data:userItem,
    method: 'post'
  })
}

export const saveUser = (userItem) => {
  return axios.request({
    url: 'api/User/Add',
    data:userItem,
    method: 'post'
  })
}

export const saveMultipleUser = (userItems) => {
  return axios.request({
    url: 'api/User/AddMultipleUser',
    data:userItems,
    method: 'post'
  })
}

export const deleteUser = (id) => {
  return axios.request({
    url: 'api/User/Delete',
    data:id,
    method: 'post'
  })
}



export const changePassword = ({oldPassword,password}) => {
  const data = {
    oldPassword,
    password
  }
  return axios.request({
    url: 'api/User/ChangePassword',
    data:data,
    method: 'post'
  })
}

export const getCheckUserList = (taskId) => {
  return axios.request({
    url: 'api/User/getCheckUserList/'+taskId,
    method: 'get'
  })
}

export const getMarkUserList = (taskId) => {
  return axios.request({
    url: 'api/User/getMarkUserList/'+taskId,
    method: 'get'
  })
}


export const getTaskMarkUserList = (taskIds) => {
  return axios.request({
    url: 'api/User/getMarkUserList',
    params: {taskIds:taskIds},
    method: 'get'
  })
}

