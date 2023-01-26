import 'bootstrap/dist/css/bootstrap.css'
import { createApp } from 'vue'
import router from './router';
import './style.css'
import App from './App.vue'
import VueGoogleCharts from "vue3-googl-chart";
import store from './store';


import 'bootstrap/dist/js/bootstrap.js'



createApp(App).use(store).use(router).use(VueGoogleCharts).mount('#app')
