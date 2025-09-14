import CameraPage from "@/pages/camera-page.vue";
import CallbackPage from "@/pages/callback-page.vue";
import HomePage from "@/pages/home-page.vue";
import { authGuard } from "@auth0/auth0-vue";
import { createRouter, createWebHashHistory } from "vue-router";

const routes = [
  {
    path: "/",
    name: "home",
    component: HomePage,
  },
  {
    path: "/camera",
    name: "camera",
    component: CameraPage,
    beforeEnter: authGuard,
  },
  {
    path: "/callback",
    name: "callback",
    component: CallbackPage,
  }
];

const router = createRouter({
  history: createWebHashHistory(),
  routes,
});

export default router;