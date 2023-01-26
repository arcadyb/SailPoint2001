<template>
    <div class="form-group auto-complete">
        <input class="form-control bs-autocomplete" type="text" v-model="searchIn" @keydown.tab.prevent="complete()" @keyup.down="onArrowDown" @keyup.up="onArrowUp" @keyup.enter="onEnter" @focus="focus(true)" @blur="focus(false)">
        <ul class="list-group" v-if="!selected">
            <template v-for="item in props.dataTable">
                <li class="list-group-item" :key="item.id" v-if="filter(item)" @mousedown="complete(item.id)" :class="{ 'is-active': i === arrowCounter }">
                    {{ item.name }}
                </li>
            </template>
        </ul>
    </div>
</template>
<script setup>
    import { onMounted, onUnmounted, ref, toRefs, computed, reactive , watch } from "vue";
    import { useStore } from 'vuex';

    const props = defineProps({
        dataTable: {
            type: Array,
            default: () => []
        },

        dataUrl: String
    })

    const emit = defineEmits(['selected', 'changed'])


    let searchIn = ref("")
    let arrowCounter = 1
    let selected = ref(false)
    let selectedItems = reactive([])
    let focused = ref(false)
    
    watch(searchIn, (newValue, oldValue) => {
        selected.value = false;
        emit("changed", newValue);
    })
    function complete(id) {
        if (id !== undefined) {
            selectedItems = props.dataTable.filter(function (v, i) {
                return v.id == id;
            });
        }

        if (selectedItems.length > 0)
            select(selectedItems[0]);

    }

    function select(row) {
        if (row) {
            searchIn.value = row.name;
            selected.value = true;
            emit("selected", row);
            // searchIn = "";
        }
    }

    const filter = (row) => {
        if (row && searchIn.value && searchIn)
            return row.name.toLowerCase().indexOf(searchIn.value.toLowerCase()) != -1
        else
            return false;
    }

    function focus(f) {
        focused = f
    }
    onMounted(async () => {
        console.log('mounted : ' + props.dataTable[0].name);

    });

    function onArrowDown(evt) {
        if (arrowCounter < props.dataTable.length - 1) {
            arrowCounter = arrowCounter + 1;
        }
    }
    function onArrowUp() {
        if (arrowCounter > 0) {
            arrowCounter = arrowCounter - 1;
        }
    }
    function onEnter() {
        var s = props.dataTable[arrowCounter];
        select(s);
        arrowCounter = -1;
    }
    function distinctResults(result) {
        var prop = "name";
        var mapped = result.map(function (obj) { return obj[prop]; });
        this.props.dataTable = result.filter(function (v, i) {
            return mapped.indexOf(v[prop]) == i;
        });
    }


    onMounted(async () => {
        console.log('mounted : ' + props.dataTable[0].name);
    });

</script>
<style scoped>
    .auto-complete ul {
        height: 300px;
        overflow-y: auto;
    }

    .auto-complete li {
        cursor: pointer
    }


    .auto-complete ul li {
        background: white;
    }

    .auto-complete ul li:hover,
    .auto-complete ul .is-active {
        background: #2196F3 !important;
        color: white;
    }

    .auto-complete ul li:nth-child(even) {
        background: #EEE;
    }
</style>
