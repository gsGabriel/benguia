<template>
  <v-card flat tile>
    <v-card-title primary-title class="text-xs-center">
      <v-container align-center grid-list-xl>
        <v-layout row wrap>
           <v-flex xs12 class="mb-4">
            <v-card>
              <v-card-title>
                <h3 style="min-width:100%">{{$t('message.viagemFinalizada')}}</h3>
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
export default {
  name: 'ViagemFinalizada',
  data() {
    return {}
  },
  created() {
    const self = this
    TouchCallBacks.prototype.onPressCallBack = (nota) => {
      self.$speak(self.$t('message.avalicaoDaViagem', { nota }))
      self.$router.push({ name: self.$route.meta.nextRouteName })
    }
    this.$speak([this.$t('audio.viagemFinalizada'), this.$t('acoes.avalicaoDaViagem')])
  }
}
</script>



