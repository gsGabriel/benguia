import axios from 'axios'
import { URL_PROXY_UBER } from '../consts/common-consts'

export const getEstimativePrices = (startLatitude, startLongitude, endLatitude, endLongitude) =>
  axios.get(
    URL_PROXY_UBER +
      'UberEstimativePrices?startLatitude=' +
      startLatitude +
      '&startLongitude=' +
      startLongitude +
      '&endLatitude=' +
      endLatitude +
      '&endLongitude=' +
      endLongitude
  )
