<template>
  <v-card flat tile>
    <v-card-title primary-title class="text-xs-center">
      <v-container align-center>
        <v-layout row wrap>
          <v-flex xs12 class="mb-4">
            <v-card>
              <v-card-title>
                <h3 style="min-width:100%">{{status}}</h3>
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
// import { postSms } from './../services/sms'

export default {
  name: 'motorista',
  props: ['local'],
  data() {
    return {
      status: this.$t('message.procurandoMotorista'),
      nomeMotorista: ''
    }
  },
  created: function() {
    this.$speak(this.$t('message.procurandoMotorista'))
    this.timer = setInterval(this.driverRequest, 5000)
  },
  methods: {
    driverRequest() {
      this.status = this.$t('message.motoristaEncontrado')
      this.nomeMotorista = 'Gabriel César'

      // Chamada comentada devido a erro de licenciamento da api de SMS
      // Aqui será feita a notificação do motorista informando sobre as necessidades especiais do usuário
      // postSms('Fulano', '+5561991399170')

      this.$speak([
        this.$t('audio.motoristaEncontrado'),
        this.$t('audio.infoMotoristaEncontrado', { motorista: 'Gabriel César' }),
        this.$t('audio.aguardeMotoristaEncontrado')
      ])

      clearInterval(this.timer)

      // this.$router.push({ name: this.$route.meta.nextRouteName })//Ta chamando isso antes de falar tudo
    }
  }
}
</script>


