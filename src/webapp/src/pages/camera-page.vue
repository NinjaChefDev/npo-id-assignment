<template>
  <div class="camera-home">
    <h1>Camera Location Overview</h1>
    <p>If you need to, you can go <router-link to="/">Back Home</router-link>.</p>
    <div style="display: flex; gap: 16px;">
        <div style="flex: 1;">
            <CameraList from=500 to=600 />
        </div>
        <div style="flex: 1;">
            <CameraList from=600 to=700 />
        </div>
        <div style="flex: 1;">
            <CameraList from=700 to=800 />
        </div>
    </div>
  </div>
</template>
<script setup>
// import { useAuth0 } from "@auth0/auth0-vue";

// const { getAccessTokenSilently } = useAuth0();
// const accessToken = await getAccessTokenSilently();
import CameraList from "@/components/camera-list.vue";

</script>
<style scoped>
</style>