<template>
  <v-card flat tile raised>
    <v-card-title primary-title class="text-xs-left">
      <v-container align-center>
        <v-layout row wrap>
          <v-flex xs12 class="mb-1">
            <v-card>
              <v-card-title>
                <h3 style="min-width:100%">{{destino.name}}</h3>
                <p>{{destino.formatted_address}}</p>
              </v-card-title>
            </v-card>
          </v-flex>
          <v-flex sm12>
            <div class="box" style="overflow:hidden">
              <div class="container"></div>
              <div class="int"></div>
              <div class="circle"></div>
            </div>
          </v-flex>
          <v-flex xs12 class="text-xs-center">
            <p>{{$t('acoes.confirmacaoDeDestino')}}</p>
            <p>{{$t('acoes.alteracaoDeDestino')}}</p>
          </v-flex>
        </v-layout>
      </v-container>
    </v-card-title>
  </v-card>
</template>
<script>
import { getPlace } from './../services/google-places'
import { mapState, mapActions } from 'vuex'
import TouchCallBacks from '@/touch-events-callbacks'

export default {
  name: 'confirmacao',
  props: ['local'],
  data() {
    return {}
  },
  methods: {
    ...mapActions(['setDestino'])
  },
  computed: {
    ...mapState(['destino'])
  },
  watch: {
    appClick(val) {
      this.$router.push({ name: 'Cotacao' })
    },
    appDbClick(val) {
      this.$router.push({ name: 'Home' })
    }
  },
  created() {
    const self = this

    TouchCallBacks.prototype.onSwipeRightCallBack = () => {
      self.$router.push({ name: self.$route.meta.returnRouteName })
    }
    TouchCallBacks.prototype.onSwipeLeftCallBack = () => {
      self.$router.push({ name: self.$route.meta.nextRouteName })
    }

    getPlace(this.local).then((response) => {
      let data = JSON.parse(response.data.data).results[0]
      if (data) {
        this.setDestino({
          name: data.name ? data.name : null,
          formatted_address: data.formatted_address,
          geometry: {
            location: {
              lat: data.geometry.location.lat,
              lng: data.geometry.location.lng
            }
          }
        })
        this.$speak(
          this.$t('message.descricaoDestino', {
            local: this.destino.name,
            endereco: this.destino.formatted_address
          })
        )
        this.$speak([this.$t('acoes.alteracaoDeDestino'), this.$t('acoes.confirmacaoDeDestino')])
      } else {
        this.$speak(this.$t('error.pesquisaEndereco'))
      }
    })
  }
}
</script>
<style>

</style>


