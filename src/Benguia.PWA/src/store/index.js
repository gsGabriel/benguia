import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

const debug = process.env.NODE_ENV !== 'production'

export default new Vuex.Store({
  strict: debug,
  state: {
    appClick: false,
    destino: {
      name: '',
      formatted_address: '',
      geometry: {
        location: { lat: null, lgn: null },
        viewport: {
          northeast: {
            lat: null,
            lgn: null
          },
          southwest: {
            lat: null,
            lgn: null
          }
        }
      }
    }
  },
  actions: {
    globalClick(context) {
      context.commit('globalClick')
    },
    setDestino(context, destino) {
      context.commit('setDestino', destino)
    }
  },
  mutations: {
    globalClick(state) {
      state.appClick = !state.appClick
    },
    setDestino(state, destino) {
      state.destino = destino
    }
  }
})
