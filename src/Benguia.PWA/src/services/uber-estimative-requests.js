import axios from 'axios'
import { URL_PROXY_UBER } from '../consts/common-consts'
export const getEstimativeRequests = (
  productId,
  startLatitude,
  startLongitude,
  endLatitude,
  endLongitude,
  token
) =>
  axios.get(
    URL_PROXY_UBER +
      'UberEstimativeRequests?productId=' +
      productId +
      '&startLatitude=' +
      startLatitude +
      '&startLongitude=' +
      startLongitude +
      '&endLatitude=' +
      endLatitude +
      '&endLongitude=' +
      endLongitude +
      '&token=' +
      token
  )
