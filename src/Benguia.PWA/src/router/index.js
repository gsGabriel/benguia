import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home'
import Confirmacao from '@/components/Confirmacao'
import Cotacao from '@/components/Cotacao'
import Motorista from '@/components/Motorista'
import Rota from '@/components/Rota'
import ViagemConcluida from '@/components/ViagemConcluida'
import Destino from '@/components/Destino'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home,
      meta: { nextRouteName: 'Destino' }
    },
    {
      path: '/destino',
      name: 'Destino',
      component: Destino,
      meta: { nextRouteName: 'Confirmacao' }
    },
    {
      path: '/confirmacao/:local',
      name: 'Confirmacao',
      component: Confirmacao,
      meta: {
        nextRouteName: 'Cotacao',
        returnRouteName: 'Destino'
      },
      props: true
    },
    {
      path: '/cotacao/',
      name: 'Cotacao',
      component: Cotacao,
      meta: {
        nextRouteName: 'Motorista',
        returnRouteName: 'Destino'
      },
      props: true
    },
    {
      path: '/motorista/',
      name: 'Motorista',
      component: Motorista,
      meta: {
        nextRouteName: 'Rota',
        returnRouteName: 'Destino'
      }
    },
    {
      path: '/rota/',
      name: 'Rota',
      component: Rota,
      meta: {
        nextRouteName: 'Viagemconcluida',
        returnRouteName: 'Destino'
      }
    },
    {
      path: '/viagemconcluida/',
      name: 'Viagemconcluida',
      component: ViagemConcluida,
      meta: {
        nextRouteName: 'Home'
      }
    }
  ]
})
