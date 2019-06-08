<template>
    <md-app md-waterfall md-mode="reveal">
      <md-app-toolbar class="md-primary" >
        <div class="md-toolbar-row">
          <div class="md-toolbar-section-start">
            <md-button class="md-icon-button" @click="toogle">
              <md-icon>menu</md-icon>
            </md-button>
            <span class="md-title">Application</span>
          </div>
          <div class="md-toolbar-section-end">
            <md-button class="md-icon-button">
              <md-icon>more_vert</md-icon>
            </md-button>
          </div>
        </div>


      </md-app-toolbar>
      <md-app-drawer  :md-active.sync="menuVisible" md-persistent="mini"  >
        <navigation @click="toogle"/>
      </md-app-drawer>
      <md-app-content>
        <opening></opening>
      </md-app-content>
    </md-app>
</template>

<script>
import Navigation from  "./components/App/Navigation.vue"
import Opening from "./components/Opening.vue"


export default {
  name: 'app',
  components:{
    Opening,
    Navigation
  },
  data: () => ({
    menuVisible : false
  }),
  methods : {
    toogle() {
      this.menuVisible = !this.menuVisible;
    }
  }
}
</script>

<style lang="scss" scoped>
  .md-drawer {
    width: 230px;
    max-width: calc(100vw - 125px);
  }
  .md-app {
    min-height: 100vh;
  }
</style>
