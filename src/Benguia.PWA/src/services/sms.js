import axios from 'axios'
import { URL_PROXY_SMS } from '../consts/common-consts'

export const postSms = (name, number) =>
  axios.post(URL_PROXY_SMS + 'Sms', {
    name: name,
    number: number
  })
