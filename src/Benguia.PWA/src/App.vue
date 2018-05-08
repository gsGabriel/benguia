<template>
  <v-touch tag="v-app" v-on:tap="onTap" @swipeleft="onSwipeLeft" @swiperight="onSwipeRight" @press="onPress" @pressup="onPressUp">
    <v-content>
      <v-container fluid fill-height>
        <v-layout justify-center align-center>
          <v-flex xs12 sm8 md4 shrink>
            <router-view></router-view>
          </v-flex>
        </v-layout>
      </v-container>
    </v-content>
  </v-touch>
</template>

<script>
import { mapActions, mapState } from 'vuex'

export default {
  name: 'app',
  computed: {
    ...mapState(['appBg'])
  },
  methods: {
    ...mapActions(['globalClick', 'setAudioParam']),
    onSwipeLeft() {
      console.log('onSwipeLeft')
      this.$touchCallBacks.onSwipeLeftCallBack()
    },
    onTap() {
      console.log('onTap')
      this.$touchCallBacks.onTapCallBack()
    },
    onSwipeRight() {
      console.log('onSwipeRight')
      this.$touchCallBacks.onSwipeRightCallBack()
    },
    onPress() {
      console.log('onPress')
      this.$record(this.$touchCallBacks.onPressCallBack)
    },
    onPressUp() {
      console.log('pressup')
      this.$stopRecord()
    }
  }
}
</script>
<style>
.card-bordas-arredondadas {
  border-radius: 15px;
}
.card {
  background-color: #fafafa !important;
}
.box {
  width: 220px;
  height: 350px;
  position: relative;
  margin: auto;
  margin-top: 50px;
  text-align: center;

  overflow: hidden;
}
.box:hover .int {
  width: 80px;
  height: 80px;
  -webkit-animation: cortana-3 1s infinite 0.1s ease-in-out;
  animation: cortana-3 1s infinite 0.1s ease-in-out;
}
.box:hover .container {
  -webkit-animation: cortana-3 1s infinite 0.1s ease-in-out;
  animation: cortana-3 1s infinite 0.1s ease-in-out forwards;
  width: 100px;
  height: 100px;
}
.box:hover .circle {
  -webkit-animation: cortana-3 1s infinite ease-in-out;
  animation: cortana-3 1s infinite ease-in-out;
}
.box .container {
  position: absolute;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  margin: auto;
  width: 80px;
  height: 80px;
  border-radius: 50%;
  background: #ce808c;
  z-index: 0;
  -webkit-animation-name: cortana-2b;
  animation-name: cortana-2b;
  -webkit-animation-iteration-count: infinite;
  animation-iteration-count: infinite;
  -webkit-animation-duration: 1.5s;
  animation-duration: 1.5s;
  -webkit-animation-direction: alternate;
  animation-direction: alternate;
}
.box .int {
  display: block;
  position: absolute;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  margin: auto;
  background: #15014a;
  border-radius: 50%;
  width: 10px;
  height: 10px;
}

.circle {
  width: 80px;
  height: 80px;
  position: absolute;
  border-radius: 50%;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  margin: auto;
  background: #e63d57;
  z-index: 2;
  -webkit-animation-name: cortana-2;
  animation-name: cortana-2;
  -webkit-animation-iteration-count: infinite;
  animation-iteration-count: infinite;
  -webkit-animation-duration: 1.5s;
  animation-duration: 1.5s;
  -webkit-animation-delay: 3s;
  animation-delay: 3s;
  -webkit-animation-direction: alternate;
  animation-direction: alternate;
}
.circle:after {
  display: block;
  content: '';
  width: 80%;
  height: 80%;
  border-radius: 50%;
  margin: auto;
  position: absolute;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  background: #15014a;
}

@-webkit-keyframes cortana-2 {
  0% {
    -webkit-transform: scale(1);
    transform: scale(1);
  }
  100% {
    -webkit-transform: scale(1.2);
    transform: scale(1.2);
  }
}
@keyframes cortana-2 {
  0% {
    -webkit-transform: scale(1);
    transform: scale(1);
  }
  100% {
    -webkit-transform: scale(1.2);
    transform: scale(1.2);
  }
}
@-webkit-keyframes cortana-2b {
  0% {
    -webkit-transform: scale(1.6);
    transform: scale(1.6);
  }
  100% {
    -webkit-transform: scale(1.4);
    transform: scale(1.4);
  }
}
@keyframes cortana-2b {
  0% {
    -webkit-transform: scale(1.6);
    transform: scale(1.6);
  }
  100% {
    -webkit-transform: scale(1.4);
    transform: scale(1.4);
  }
}
@-webkit-keyframes cortana-3 {
  0% {
    -webkit-transform: rotateY(0deg);
    transform: rotateY(0deg);
  }
  30% {
    -webkit-transform: rotateY(180deg);
    transform: rotateY(180deg);
  }
  100% {
    -webkit-transform: rotateY(180deg);
    transform: rotateY(180deg);
  }
}
@keyframes cortana-3 {
  0% {
    -webkit-transform: rotateY(0deg);
    transform: rotateY(0deg);
  }
  30% {
    -webkit-transform: rotateY(180deg);
    transform: rotateY(180deg);
  }
  100% {
    -webkit-transform: rotateY(180deg);
    transform: rotateY(180deg);
  }
}
</style>



