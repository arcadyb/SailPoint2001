<script setup>
import { ref } from 'vue'

defineProps({
  title: String
})

const count = ref(0)
</script>

<template>
<nav class="navbar navbar-expand-lg bg-light">
  <div class="container-fluid">
    <button className="navbar-toggler" onClick='{()=>{document.body.style.zoom=0.8;}}' type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation" style="border-color:blue"/>
    <div class="collapse navbar-collapse" id="navbarSupportedContent">
      <ul class="navbar-nav me-auto ">
        <li class="nav-item">
         <router-link :to="'/DataView'" custom v-slot="{ navigate, href }">
          <a :href="href" @click.stop="navigate">Data</a>
        </router-link>
        </li>
        <li class="nav-item">
          <router-link :to="'/About'" custom v-slot="{ navigate, href }">
            <a :href="href" @click.stop="navigate">About</a>
          </router-link>
        </li>
      </ul>
    </div>
  </div>
</nav>
</template>

<style scoped>
.read-the-docs {
  color: #888;
}
.nav-item {
  margin-right:10%;
}
</style>
