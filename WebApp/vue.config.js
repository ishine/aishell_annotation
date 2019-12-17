
const path = require('path')
const Timestamp = new Date().getTime();
const resolve = dir => {
  return path.join(__dirname, dir)
}
module.exports = {
  publicPath: '/',

  pwa:{
    iconPaths:{
      favicon32:'favicon.ico'
    }
  },

  chainWebpack: config => {
    config.resolve.alias
      .set('_c', resolve('src/components')) // key,value自行定义，比如.set('@@', resolve('src/components'))
  },

  css: {
    loaderOptions: {
        less: {
            javascriptEnabled: true,
        }
    }
},

  configureWebpack: { // webpack 配置
    output: { // 输出重构  打包编译后的 文件名称  【模块名称.版本号.时间戳】
      filename: `[name].${Timestamp}.js`,
      chunkFilename: `[name].${Timestamp}.js`
    },
  }
}