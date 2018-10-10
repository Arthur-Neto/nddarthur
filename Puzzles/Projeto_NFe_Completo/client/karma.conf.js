const webpackConfig = require('./webpack.config')({ isTest: true });

module.exports = (config) => config.set({
  basePath: '',
  frameworks: ['jasmine'],
  browsers: ['Chrome'],
  files: [
    {
      pattern: './karma-shim.js',
      watched: false
    }
  ],
  exclude: [],
  preprocessors: {
    './karma-shim.js': ['webpack', 'sourcemap']
  },
  reporters: ['mocha'],
  proxies: {
    "/app/": "/base/src/app/"
  },
  webpack: webpackConfig,
  webpackMiddleware: {
    noInfo: true
  },
  logLevel: config.LOG_WARN, // config.LOG_DISABLE || _ERROR || _WARN || _INFO || _DEBUG
  singleRun: true,
  autoWatch: false,
  colors: true,
  concurrency: Infinity,
  port: 9876,
  browserNoActivityTimeout: 100000,
});