import axios from 'axios'
import { URL_PROXY_MAPS } from './../consts/common-consts'

export const getPlace = (place) =>
  axios.get(URL_PROXY_MAPS + 'GooglePlaces?place=' + encodeURIComponent(place))
