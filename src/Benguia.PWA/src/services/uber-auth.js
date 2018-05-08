import axios from 'axios'
import { URL_PROXY_UBER, URL_BASE } from '../consts/common-consts'

export const getUberAuth = (token) => axios.get(URL_PROXY_UBER + 'UberAuth?redirectUrl=' + URL_BASE)
