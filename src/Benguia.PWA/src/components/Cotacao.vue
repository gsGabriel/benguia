<template>
  <v-container fluid style="min-height: 0;" grid-list-lg>
    <v-layout row wrap>
      <v-flex xs12 :key="`${index}u`" v-for="(item, index) in items">
        <v-card class="card-bordas-arredondadas">
          <v-container fill-height style="min-height: 0;" grid-list-lg>
            <v-layout row justify-center align-center>
              <v-flex xs3>
                <img :src="item.image" contain height="50px" />
              </v-flex>
              <v-flex xs8 offset-xs1>
                <h3>{{item.localizedDisplayName}}</h3>
                <p>{{destino.name}}</p>
              </v-flex>
            </v-layout>
            <v-layout row>
              <v-flex xs12 class="text-xs-right">
                {{item.estimate}}
              </v-flex>
            </v-layout>
          </v-container>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>
<script>
import { mapState } from 'vuex'
import { getEstimativePrices } from './../services/uber-estimative-prices'
import TouchCallBacks from '@/touch-events-callbacks'

const novenovelogo = require('./../assets/99.png')
const cabifylogo = require('./../assets/cabify.png')
const easytaxilogo = require('./../assets/easy-taxy.png')
const uberlogo = require('./../assets/uber.png')

export default {
  name: 'cotacao',
  data() {
    return {
      items: [],
      mocks: [
        { localizedDisplayName: '99 pop', image: novenovelogo, estimate: '23.00' },
        { localizedDisplayName: 'Cabify', image: cabifylogo, estimate: '23.00' },
        { localizedDisplayName: 'Easy taxi', image: easytaxilogo, estimate: '23.00' }
      ]
    }
  },
  computed: {
    ...mapState(['destino'])
  },
  methods: {},
  watch: {
    appClick(val) {
      this.$record((local) => this.$router.push({ name: 'motorista' }))
    }
  },
  created() {
    const self = this
    TouchCallBacks.prototype.onPressCallBack = (text) => {
      if (text.indexOf(self.$t('opcao')) >= 0) {
        self.$router.push({ name: self.$route.meta.nextRouteName })
      }
    }
    TouchCallBacks.prototype.onSwipeRightCallBack = () => {
      self.$router.push({ name: self.$route.meta.returnRouteName })
    }

    this.items = this.mocks
    navigator.geolocation.getCurrentPosition((position) => {
      getEstimativePrices(-15.7837174, -47.8773616, -15.7836852, -47.877266).then((response) => {
        let data = JSON.parse(response.data.data)
        const uberCotacao = []
        data.prices.forEach((e, i) => {
          const valores = e.estimate
            .replace('R$', '')
            .replace('-', ' ')
            .split(' ')
          uberCotacao.push({
            opcao: i,
            productId: e.product_id,
            estimate: e.estimate,
            localizedDisplayName: e.localized_display_name,
            image: uberlogo
          })

          this.$speak(
            this.$t('audio.cotacaoes', {
              opcao: i + 1,
              descricao: e.localized_display_name,
              min: valores[0],
              max: valores[1]
            })
          )
          this.items = [].concat(...uberCotacao).concat(this.mocks)
        })
      })
    })
  }
}
</script>


