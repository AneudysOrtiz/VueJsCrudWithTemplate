import Vue from 'vue'
import axios from 'axios'
import { Component } from "vue-property-decorator/lib/vue-property-decorator";
import { Marca } from "../../Entites";


@Component
export default class MarcasComponent extends Vue {
    marca: Marca = new Marca();


    guardar() {


    }

}
