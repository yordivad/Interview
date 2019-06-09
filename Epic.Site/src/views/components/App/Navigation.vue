<template lang="pug">
    .navigation
        md-toolbar(class="md-transparent" md-elevation="4")
            span Navigation
            .md-toolbar-section-end
                md-button(class="md-icon-button" md-dense @click="toggle")
                    md-icon keyboard_arrow_left
        md-list
            md-list-item
                md-icon send
                span(class="md-list-item-text") Send Email

</template>

<script>
    export default {
        name: "Navigation",
        event : ["click"],
        data() {
            return {

            }
        },
         methods : {
            toggle() {
                this.$emit('click')
            }
        }
    }
</script>

<style scoped>

</style>