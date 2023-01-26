
export const Mutations = {

    SET_DATA(state, { searchTerm , data }) {
        console.log('SET_DATA : ' +  data); 
        state.citiesData = data;
        state.loading = false;
    },
    SET_ERROR(state, { error }) {
        console.log('SET_ERROR : ' + error);
        state.error = 'ERROR : ' + error;
    }
};