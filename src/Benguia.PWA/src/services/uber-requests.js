import axios from 'axios'
import { URL_PROXY_UBER } from '../consts/common-consts'
export const postRequests = (
  productId,
  startLatitude,
  startLongitude,
  endLatitude,
  endLongitude,
  fareId,
  token
) =>
  axios.post(URL_PROXY_UBER + 'UberRequests', {
    productId: productId,
    startLatitude: startLatitude,
    startLongitude: startLongitude,
    endLatitude: endLatitude,
    endLongitude: endLongitude,
    fareId: fareId,
    token: token
  })
