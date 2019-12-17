import {
  getBreadCrumbList,
  setTagNavListInLocalstorage,
  getMenuByRouter,
  getTagNavListFromLocalstorage,
  getHomeRoute,
  getNextRoute,
  routeHasExist,
  routeEqual,
  getRouteTitleHandled,
  localSave,
  localRead
} from '@/libs/util'
import beforeClose from '@/router/before-close'
import {addOperate} from '@/api/operate'
import router from '@/router'
import routers from '@/router/routers'
import config from '@/config'

const { homeName } = config

const closePage = (state, route) => {
  const nextRoute = getNextRoute(state.tagNavList, route)
  state.tagNavList = state.tagNavList.filter(item => {
    return !routeEqual(item, route)
  })
  router.push(nextRoute)
}

export default {
  state: {
    breadCrumbList: [], //面包屑列表
    tagNavList: [],   //页面选项卡列表
    homeRoute: getHomeRoute(routers, homeName),
    local: localRead('local'), //管理本地化语言
    operationLog:[], //用户操作记录
  },
  getters: {
    menuList: (state, getters, rootState) => getMenuByRouter(routers, rootState.user.role),
  },
  mutations: {
    setBreadCrumb (state, route) {
      state.breadCrumbList = getBreadCrumbList(route, state.homeRoute)
    },
    setTagNavList (state, list) {
      let tagList = []
      if (list) {
        tagList = [...list]
      } else tagList = getTagNavListFromLocalstorage() || []
      if (tagList[0] && tagList[0].name !== homeName) tagList.shift()
      let homeTagIndex = tagList.findIndex(item => item.name === homeName)
      if (homeTagIndex > 0) {
        let homeTag = tagList.splice(homeTagIndex, 1)[0]
        tagList.unshift(homeTag)
      }
      state.tagNavList = tagList
      setTagNavListInLocalstorage([...tagList])
    },
    closeTag (state, route) {
      let tag = state.tagNavList.filter(item => routeEqual(item, route))
      route = tag[0] ? tag[0] : null
      if (!route) return
      if (route.meta && route.meta.beforeCloseName && route.meta.beforeCloseName in beforeClose) {
        new Promise(beforeClose[route.meta.beforeCloseName]).then(close => {
          if (close) {
            closePage(state, route)
          }
        })
      } else {
        closePage(state, route)
      }
    },
    addTag (state, { route, type = 'unshift' }) {
      let router = getRouteTitleHandled(route)
      if (!routeHasExist(state.tagNavList, router)) {
        if (type === 'push') state.tagNavList.push(router)
        else {
          if (router.name === homeName) state.tagNavList.unshift(router)
          else state.tagNavList.splice(1, 0, router)
        }
       // setTagNavListInLocalstorage([...state.tagNavList])
      }
    },
    setLocal (state, lang) {
      localSave('local', lang)
      state.local = lang
    },
  
   
    //添加用户行为到列表
    addOperate(state,operate){
      state.operateList.push(operate);
    },
    //清空用户行为列表
    clearOperate(state){
      state.operateList=[];
    },
  },
  actions: {
    addOperateEvent({commit,},operate){
   
      commit("addOperate",operate);
    },
    //上传用户行为
    uploadOperate({commit,state}){
      if(state.operateList.length>0){
        addOperate(state.operateList).then(res=>{
           //上传成功后清空本地的列表
          commit('clearOperate');
        }).catch(err=>{
          console.log(err);
        });
      }
    },

    

    // addErrorLog ({ commit, rootState }, info) {
    //   if (!window.location.href.includes('error_logger_page')) commit('setHasReadErrorLoggerStatus', false)
    //   const { user: { token, userId, userName } } = rootState
    //   let data = {
    //     ...info,
    //     time: Date.parse(new Date()),
    //     token,
    //     userId,
    //     userName
    //   }
    //   saveErrorLogger(info).then(() => {
    //     commit('addError', data)
    //   })
    // }
  }
}
