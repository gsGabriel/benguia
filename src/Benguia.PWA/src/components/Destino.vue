<template>
  <v-card flat tile>
    <v-card-title primary-title class="text-xs-center">
      <v-container align-center>
        <v-flex sm12>
          <div class="box" style="overflow:hidden">
            <div class="container"></div>
            <div class="int"></div>
            <div class="circle"></div>
          </div>
        </v-flex>
        <v-flex sm12>
          <p class="mt-2">{{$t('acoes.solicitacaoDeTransporte')}}</p>
        </v-flex>
      </v-container>
    </v-card-title>
  </v-card>
</template>
<script>
import { mapState } from 'vuex'
import TouchCallBacks from '@/touch-events-callbacks'

export default {
  name: 'Destino',
  data() {
    return {}
  },
  computed: {
    ...mapState(['audioParam'])
  },
  created() {
    const self = this
    TouchCallBacks.prototype.onPressCallBack = (local) => {
      if (local) self.$router.push({ name: self.$route.meta.nextRouteName, params: { local } })
    }

    this.$speak(this.$t('acoes.solicitacaoDeTransporte'))
  }
}
</script>
<style>
.mic-size {
  width: 140px !important;
  height: 140px !important;
}
</style>


