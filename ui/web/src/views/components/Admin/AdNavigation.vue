<template lang="pug">
    
    .adnavigation
        md-toolbar(class="md-transparent" md-elevation="4")
            span Admin Menu
            .md-toolbar-section-end
                md-button(class="md-icon-button" md-dense @click="toggle")
                    md-icon keyboard_arrow_left
        md-list
            md-list-item(md-expand)
                md-icon settings
                span(class="md-list-item-text") Admin Actions
                md-list(slot="md-expand")
                    md-list-item(class="md-inset" @click="navEvent('disclaimer')")
                        md-icon list_alt
                        span(class="md-list-item-text") Disclaimer
                    md-list-item(class="md-inset" @click="navEvent('jobPosting')")
                        md-icon add
                        span(class="md-list-item-text") Add Job Postings
            md-list-item(md-expand)
                md-icon more_horiz
                span(class="md-list-item-text") Other Actions
                md-list(slot="md-expand")
                     md-list-item(class="md-inset")
                        md-icon alternate_email
                        span(class="md-list-item-text") Send Email

</template>

<script>
    export default {
        name: "AdNavigation",
        event : ["click"],
        data() {
            return {

            }
        },
         methods : {
            toggle() {
                this.$emit('click')
            },
            navEvent(component) {
                this.$router.push('/admin/' + component);
            }
        }
    }
</script>

<style scoped>

</style>