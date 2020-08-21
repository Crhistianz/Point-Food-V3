import Axios from 'axios';
import IdentityProxy from './IdentityProxy';
import UserProxy from './UserProxy';
import ClientProxy from '@/proxies/ClientProxy'
import RestaurantOwnerProxy from '@/proxies/RestaurantOwnerProxy'
import RestaurantProxy from '@/proxies/RestaurantProxy'
import CategoryProxy from '@/proxies/CategoryProxy'
import ProductProxy from '@/proxies/ProductProxy'
import ProductTypeProxy from '@/proxies/ProductTypeProxy'
import OrderProxy from '@/proxies/OrderProxy'

Axios.defaults.headers.common.Accept = 'application/json';

Axios.interceptors.request.use(
    config => {
        let token = localStorage.getItem('access_token');

        if (token) {
            config.headers.Authorization = `Bearer ${token}`;
        }

        return config;
    },
    error => Promise.reject(error)
);

//TODO: Test
Axios.interceptors.response.use(
    response => response,
    error => {
        const { status } = error.response;

        if (status === 401) {
            localStorage.removeItem('access_token');
            window.location.reload(true);
        }

        return Promise.reject(error);
    }
);

let url = 'http://localhost:7000/';

export default {
    identityProxy: new IdentityProxy(Axios,url),
    userProxy: new UserProxy(Axios, url),
    clientProxy: new ClientProxy(Axios, url),
    restaurantOwnerProxy: new RestaurantOwnerProxy(Axios, url),
    restaurantProxy: new RestaurantProxy(Axios, url),
    categoryProxy: new CategoryProxy(Axios, url),
    productProxy: new ProductProxy(Axios, url),
    productTypeProxy: new ProductTypeProxy(Axios, url),
    orderProxy: new OrderProxy(Axios, url)
}