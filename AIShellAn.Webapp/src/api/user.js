import axios from '@/libs/api.request'
//与用户相关的api

export default {
    //登录
    login({ userName, password }) {
        const data = {
            userName,
            password
        }
        return axios.request({
            url: 'api/token',
            data,
            method: 'post',
        })
    },
    //获取用户信息
    getUserInfo() {
        return axios.request({
            url: 'api/User/Get',
            method: 'get'
        })
    }
}


