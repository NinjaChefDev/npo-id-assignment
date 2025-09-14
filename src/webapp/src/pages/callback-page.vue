<template>
  <div v-if="error">
    <h1>Error</h1>
    <div class="content__body">
        <p id="page-description">
            <span>{{ error.message }}</span>
        </p>
    </div>
  </div>
  <div v-else>
    <h1>Login Successful</h1>
    <p>You can now <router-link to="/camera">View Cameras</router-link>.</p>
    <p>If you need to, you can go <router-link to="/">Back Home</router-link>.</p>
  </div>
  
</template>

<script setup>
import { useAuth0 } from "@auth0/auth0-vue";

const { error } = useAuth0();
</script>