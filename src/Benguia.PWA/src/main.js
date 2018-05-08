// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import VueI18n from 'vue-i18n'
import Vuetify from 'vuetify'
import VueTouch from 'vue-touch'

import App from './App'
import router from './router'
import speech from './speech'
import store from './store'
import TouchEventsCallback from './touch-events-callbacks'

import locale from './i18n'
import 'material-design-icons/iconfont/material-icons.css'
import 'vuetify/dist/vuetify.min.css'
import 'vue2-animate/dist/vue2-animate.min.css'

Vue.use(VueTouch, { name: 'v-touch' })
Vue.use(VueI18n)
Vue.use(Vuetify, {
  theme: {
    primary: '#2A2E43',
    secondary: '#4D4D4D',
    accent: '#E6E6E6',
    error: '#b71c1c'
  }
})

Vue.config.productionTip = false
const i18n = new VueI18n(locale)

router.beforeEach((to, from, next) => {
  speech.shutUp()
  TouchEventsCallback.prototype.onPressCallBack = function() {}
  TouchEventsCallback.prototype.onSwipeLeftCallBack = function() {}
  TouchEventsCallback.prototype.onTapCallBack = function() {}
  TouchEventsCallback.prototype.onSwipeRightCallBack = function() {}
  TouchEventsCallback.prototype.onPressUpCallBack = function() {}
  next()
})

Vue.mixin({
  methods: {
    $record(expectedCommand, callbackMatch, callbackNoMatch) {
      speech.record(expectedCommand, callbackMatch, callbackNoMatch)
    },
    $speak(txt) {
      speech.talk(txt)
    },
    $shutUp() {
      speech.shutUp()
    },
    $stopRecord() {
      speech.stopRecord()
    }
  }
})

Vue.prototype.$touchCallBacks = new TouchEventsCallback()

/* eslint-disable no-new */
new Vue({
  el: '#app',
  i18n,
  router,
  store,
  template: '<App/>',
  components: { App }
})
