<template>
    <div class="navigation">
        <md-toolbar class="md-transparent" md-elevation="4">
            <span>Navigation</span>
            <div class="md-toolbar-section-end">
                <md-button class="md-icon-button md-dense" @click="toogle">
                    <md-icon>keyboard_arrow_left</md-icon>
                </md-button>
            </div>
        </md-toolbar>
        <md-list>
            <md-list-item>
                <md-icon >send</md-icon>
                <span class="md-list-item-text">Send Mail</span>
                <md-badge class="md-primary md-square" md-content="6" />
            </md-list-item>
            <md-list-item>
                <md-icon >delete</md-icon>
                <span class="md-list-item-text">Trash</span>
            </md-list-item>
        </md-list>
        </div>
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
            toogle() {
                this.$emit('click')
            }
        }
    }
</script>

<style scoped>

</style>