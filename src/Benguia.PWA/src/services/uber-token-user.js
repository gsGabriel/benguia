import axios from 'axios'
import { URL_PROXY_UBER, URL_BASE } from '../consts/common-consts'

export const getUserToken = (token) =>
  axios.get(URL_PROXY_UBER + 'UberToken?token=' + token + '&redirectUrl=' + URL_BASE)
