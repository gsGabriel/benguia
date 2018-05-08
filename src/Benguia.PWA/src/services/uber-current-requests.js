import axios from 'axios'
import { URL_PROXY_UBER } from '../consts/common-consts'
export const getCurrentRequest = (token) =>
  axios.get(URL_PROXY_UBER + 'UberCurrentRequests?token=' + token)
