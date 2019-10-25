<template lang="pug">
    .app
        router-view
        error-bar
</template>

<script>

    import ErrorBar from "./views/components/App/ErrorBar"

    export default {
        name: 'app',
        components: {ErrorBar}
    }
</script>

<style lang="scss" scoped>

    .app {
        height: 100vh;
    }

</style>
