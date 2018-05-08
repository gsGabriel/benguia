import axios from 'axios'
import { URL_PROXY_MAPS } from './../consts/common-consts'

export const getDistance = (startLatitude, startLongitude, endLatitude, endLongitude) =>
  axios.get(
    URL_PROXY_MAPS +
      'GoogleDistanceMatrix?startLatitude=' +
      startLatitude +
      '&startLongitude=' +
      startLongitude +
      '&endLatitude=' +
      endLatitude +
      '&endLongitude=' +
      endLongitude
  )
