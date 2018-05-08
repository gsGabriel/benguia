import axios from 'axios'
import { URL_PROXY_MAPS } from './../consts/common-consts'

export const getLocationInfo = (latitude, longitude) =>
  axios.get(URL_PROXY_MAPS + 'GoogleGeocode?latitude=' + latitude + '&longitude=' + longitude)
