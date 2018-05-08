/* eslint-disable */
const SpeechRecognition = SpeechRecognition || window.webkitSpeechRecognition
const recognition = new SpeechRecognition()
const SpeechGrammarList = SpeechGrammarList || webkitSpeechGrammarList
const SpeechRecognitionEvent = SpeechRecognitionEvent || webkitSpeechRecognitionEvent
const Synth = window.speechSynthesis
let recognitionStarted = false

recognition.onspeechend = function() {
  recognition.stop()
  recognitionStarted = false
}

recognition.onerror = function(event) {
  console.log('Error occurred in recognition: ' + event.error)
  recognitionStarted = false
}

function talk(txt) {
  let arr = []
  if (!Array.isArray(txt)) arr.push(txt)
  else arr.push(...txt)

  arr.map((t) => {
    const utterThis = new SpeechSynthesisUtterance(t)
    utterThis.lang = 'pt-Br'
    utterThis.localService = true
    utterThis.name = 'Google português do Brasil'
    utterThis.voiceURI = 'urn:moz-tts:sapi:Microsoft Zira Desktop - English (United States)?en-US'
    utterThis.pitch = 1.1
    utterThis.rate = 1
    Synth.speak(utterThis)
  })
}

function shutUp() {
  Synth.cancel()
}

function record(callbackSucess) {
  let speechRecognitionList = new SpeechGrammarList()
  recognition.lang = 'pt-BR'
  recognition.interimResults = false
  recognition.maxAlternatives = 1
  if (!recognitionStarted) {
    recognition.start()
    recognitionStarted = true
    recognition.onresult = (event) => {
      let speechResult = event.results[0][0].transcript
      if (callbackSucess) callbackSucess(speechResult)
    }
  }
}

function stopRecord(callbackSucess) {
  recognition.abort()
}

export default {
  talk,
  record,
  stopRecord,
  shutUp
}
