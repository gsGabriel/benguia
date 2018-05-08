<template>
  <v-layout wrap class="text-xs-center" style="padding-top:10vh">
    <div class="bg-home" :style="`background-image: url(\'${require('./../assets/bg-home.jpg')}\') ;`"></div>
    <v-flex xs12>
      <h3 class="primary--text">{{ $t("message.bemVindo") }}</h3>
    </v-flex>
    <v-flex xs12>
      <p>{{$t('descricaoDoSistema')}}</p>
      <p>{{$t('acoes.continuar')}}</p>
    </v-flex>
  </v-layout>
</template>
<script>
import TouchCallBacks from '@/touch-events-callbacks'
import { clearInterval, setInterval } from 'timers'
export default {
  name: 'Home',
  data() {
    return {
      timeoutId: null
    }
  },
  created() {
    const self = this
    TouchCallBacks.prototype.onSwipeLeftCallBack = (local) => {
      self.$router.push({ name: self.$route.meta.nextRouteName })
    }

    this.timeoutId = setInterval(
      () => self.$router.push({ name: self.$route.meta.nextRouteName }),
      5000
    )
  },
  beforeDestroy() {
    clearInterval(this.timeoutId)
  }
}
</script>
<style scoped>
h3 {
  font-size: 44px;
  font-weight: normal;
}
.bg-home {
  width: 100%;
  height: 33vh;
  position: absolute;
  top: 0%;
  left: 0%;
  background-repeat: repeat-x;
}
</style>


