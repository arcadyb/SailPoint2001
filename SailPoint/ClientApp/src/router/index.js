import { createRouter, createWebHistory } from 'vue-router';
import DataView  from '../views/DataView.vue';
import About  from '../views/About.vue';

const routes = [
    
    { path: '/', name: 'Home', component: DataView },
    { path: '/DataView', name: 'DataView', component: DataView },
    { path: '/About', name: 'About', component: About }
];

const router = createRouter({
    history: createWebHistory(),
    routes
});
export default router;
