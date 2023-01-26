<script setup>

    import AutoComplete from '../components/AutoComplete.vue';
    import { onMounted, onUnmounted, ref, computed, reactive } from "vue";
    import { useStore } from 'vuex';


    const store = useStore();
    function onSelectedCity(cityName) {
        selectedCity.value = cityName
    }
    async function onChangedSearchCity(searchTerm) {
        if (searchTerm.length > 0) {
            await store.dispatch('citiesModule/getData', { searchStr: searchTerm.toLowerCase() })
        }

    }
    const listData = computed(() => store.state.citiesModule.citiesData);
    const loading = computed(() => store.state.citiesModule.loading);
    const error = computed(() => store.state.citiesModule.error);
    const selectedCity = ref("select city...")
    async function updateList() {
        await store.dispatch('citiesModule/getData', { searchStr: "" })
    };
    onMounted(async () => {
        await updateList()
    });

</script>

<template>
    <div>Selected city : {{ selectedCity.name }}</div>
    <div v-if="error">Errors : {{error}}</div>
    <div class="container-fluid" id="data-card-wrapper">
        <div class="card" id="data-card" style="width: 58rem;height: 38rem">
            <div class="card-body">

                <auto-complete :data-url="'/AutoComplete'" :data-table="listData" @selected="onSelectedCity" @changed="onChangedSearchCity"></auto-complete>

            </div>
        </div>
    </div>

</template>

<style scoped>
    #data-card-wrapper {
        display: flex;
        align-items: center;
        justify-content: center;
        padding: 0px;
        margin-top: 5em;
    }

    #data-card {
        border: 1px solid;
        box-shadow: 5px 5px 5px 5px #888888;
    }
</style>