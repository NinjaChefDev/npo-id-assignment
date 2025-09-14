<template>
    <div>
        <p v-show="showHeader">Camera's {{ from }} - {{ to }}</p>
        <ul v-if="cameraList.length">
            <li v-for="camera in cameraList" :key="camera.id">
                {{ camera.camera }}
            </li>
        </ul>
        <div v-else>No cameras loaded.</div>
    </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'

const cameraList = ref([])
const props = defineProps({
    showHeader: {
        type: Boolean,
        default: true
    },
    from: {
        type: Number,
        required: true
    },
    to: {
        type: Number,
        required: true
    }
})
const from = props.from
const to = props.to
const API_URL = import.meta.env.VITE_API_SERVER_URL + '/cameras/range'

async function fetchCameraList() {

    try {
        const response = await fetch(`${API_URL}?from=${from}&to=${to}`)
        if (!response.ok) throw new Error('API error')
        const data = await response.json()
        cameraList.value = data
    } catch (error) {
        cameraList.value = []
        console.error(error)
    }
}

onMounted(fetchCameraList)
</script>
