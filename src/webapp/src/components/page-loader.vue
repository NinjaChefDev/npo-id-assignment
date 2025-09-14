<template>
  <div class="loader">
    <img :src="loaderImg" alt="Loading..." />
  </div>
</template>

<script setup>
import loaderImg from '@/assets/loader.svg';
</script>

<style scoped>
.loader {
  height: 5rem;
  width: 5rem;

  margin: auto;

  animation: spin 2s infinite linear;
}

@keyframes spin {
  from {
    transform: rotate(0deg);
  }
  to {
    transform: rotate(360deg);
  }
}
</style>