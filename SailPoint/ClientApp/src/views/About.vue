<script setup>

</script>

<template>
<div class="container-fluid" id="about-card-wrapper" >
<div class="card" id="about-card" style="width: 18rem;">
    <div class="card-body">
        <h5 class="card-title">Test project v1.0.0</h5>
        <h6 class="card-subtitle mb-2 text-muted">Backend:</h6>
        <p class="card-text">ASPNET 5.0</p>
        <p class="card-text">EF 5.0.17</p>
        <p class="card-text">SQLite DB</p>
        <h6 class="card-subtitle mb-2 text-muted">Frontend:</h6>
        <p class="card-text">Vite + Vue 3.2</p>

    </div>
</div>
</div>
</template>

<style scoped>
#about-card-wrapper {
  display: flex;
  align-items: center;
  justify-content: center;

  padding: 0px;
  margin-top: 5em;
 
}
#about-card {
  border: 1px solid;
  box-shadow: 5px 5px 5px 5px #888888;
}
</style>