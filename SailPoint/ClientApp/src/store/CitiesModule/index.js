import { Actions } from './citiesActions';
import { Mutations } from './citiesMutations';
import { Getters } from './citiesGetters';

const citiesData = [
    { id: 1, name:"abc" },
    { id: 2, name:"abcd" },
    { id: 3, name:"efgh" }
];

const initState = {

    loading: true,
    error: null,
    citiesData: citiesData,
    searchTerm:"a"
};
export default {
    namespaced: true,
    state: initState,
    mutations: Mutations,
    actions: Actions,
    getters: Getters
};