import { createStore } from 'vuex';
import citiesModule from './CitiesModule/index';

export default createStore({
    state: {},
    mutations: {},
    actions: {},
    getters: {},
    modules: {
        citiesModule: citiesModule
    }
});
// https://next.vuex.vuejs.org/guide/modules.html#accessing-global-assets-in-namespaced-modules
// https://stackoverflow.com/questions/63216740/use-mapactions-or-mapgetters-with-vuex-4-and-vue-3