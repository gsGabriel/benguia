<template>
  <v-card flat tile >
    <v-card-title primary-title class="text-xs-center">
      <v-container align-center grid-list-xl>
        <v-layout row wrap>
           <v-flex xs12 class="mb-4">
            <v-card>
              <v-card-title>
                <h3 class="">{{$t('message.viagemEmAndamento')}}</h3>
              </v-card-title>
              <v-card-title>
                <v-slider v-model="value1" step="0"></v-slider>
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
        </v-layout>
      </v-container>
    </v-card-title>
  </v-card>
</template>
<script>
import TouchCallBacks from '@/touch-events-callbacks'
import { getLocationInfo } from '@/services/google-geocode'
export default {
  name: 'rota',
  data() {
    return { value1: 50 }
  },
  created() {
    const self = this

    TouchCallBacks.prototype.onTapCallBack = (local) => {
      navigator.geolocation.getCurrentPosition(({ coords }) => {
        getLocationInfo(coords.latitude, coords.longitude).then((response) => {
          let data = JSON.parse(response.data.data)
          self.$speak(data.results['0'].formatted_address)
        })
      })
    }

    TouchCallBacks.prototype.onSwipeLeftCallBack = (local) => {
      self.$router.push({ name: self.$route.meta.nextRouteName })
    }

    this.$speak(this.$t('acoes.notificacaoDeLocalizacao'))
  }
}
</script>



