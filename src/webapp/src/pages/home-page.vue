<template>
    <div class="home">
        <h1>Welcome to the Camera Location API</h1>
        <p>
        This API let's you query our Camara data, but is for authenticated users
        ONLY.
        </p>
    
        <button @click="loginWithRedirect()">Log in</button>
        <p>Once logged in, you can go to the <router-link to="/camera">Camera Overview</router-link> page.</p>
        
    </div> 
</template>
<script setup>
import { useAuth0 } from "@auth0/auth0-vue";
const { loginWithRedirect } = useAuth0();

</script>
<style scoped>
</style>