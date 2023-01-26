<template>
     <div class="form-group auto-complete">
        <ul>
            <li v-for="item in dataSrc" :key="item.id">
                {{ item.name }}
            </li>
        </ul>
 </div>
</template>
<script setup>
    import { onMounted, onUnmounted, ref, toRefs , computed, reactive } from "vue";
    import { useStore } from 'vuex';

    const props = defineProps({
        dataTable: {
            type: Array,
            default: () => []
        },
        
        dataUrl: String
    })
    //const { dataTable } = toRefs(props)
    
    const emit = defineEmits(['selected'])

    let searchIn = ref("")
    let arrowCounter = 1
    let dataSrc = reactive([])
    function complete(i) {
        if (i == undefined) {
            for (let row of props.dataTable) {
                if (this.filter(row)) {
                    this.select(row)
                    return
                }
            }
        }

        this.select(props.dataTable[i]);

    }

    function select(row) {
        if (row) {
            this.searchIn = row.name;
            this.selected = true;
            this.$emit("selected", row);
            this.searchIn = "";
        }
     }

    function filter(row) {
        if (row)
            return row.name.toLowerCase().indexOf(this.searchIn.toLowerCase()) != -1
        else
            return false;
    }

    function focus(f) {
        this.focused = f
    }
    onMounted(async () => {
        console.log('mounted : ' + props.dataTable[0].name);
        dataSrc.value = [{ id: 1, name: 'Item 1' }, { id: 2, name: 'Item 2' }];//props.dataTable.slice();
        console.log('mounted : ' + dataSrc.value[0].name);
    });
 
    function onArrowDown(evt) {
        if (this.arrowCounter < this.props.dataTable.length - 1) {
            this.arrowCounter = this.arrowCounter + 1;
        }
    }
    function onArrowUp() {
        if (this.arrowCounter > 0) {
            this.arrowCounter = this.arrowCounter - 1;
        }
    }
    function onEnter() {
        var s = this.props.dataTable[this.arrowCounter];
        this.select(s);
        this.arrowCounter = -1;
    }
    function distinctResults(result) {
        var prop = "name";
        var mapped = result.map(function (obj) { return obj[prop]; });
        this.props.dataTable = result.filter(function (v, i) {
            return mapped.indexOf(v[prop]) == i;
        });
    }


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
