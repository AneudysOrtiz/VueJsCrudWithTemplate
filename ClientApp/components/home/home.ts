
import Vue from 'vue';
import axios from 'axios';
import { Vehiculo, Marca, Modelo } from '../../Entites';
import { Component } from "vue-property-decorator/lib/vue-property-decorator";
import swal from 'sweetalert2';

@Component
export default class HomeComponent extends Vue {
    vehiculos: Array<Vehiculo> = new Array < Vehiculo>();
    vehiculo: Vehiculo = new Vehiculo();
    marcas: Array<Marca> = new Array<Marca>();
    modelos: Array<Modelo> = new Array<Modelo>();

    mounted() {
        this.cargar();
        
    }

    cargar() {
        var that = this;
        axios.get('/api/Vehiculos/')
            .then(function (response) {
                that.vehiculos = response.data;
            }).catch(function (error) {
                console.log(error)
            });


        axios.get('/api/Vehiculos/Marcas/')
            .then(function (response) {
                that.marcas = response.data;

                console.log(response);
            }).catch(function (error) {
                console.log(error)
            })
    }

    getModelos() {
        debugger
        var that = this;
        var id = that.vehiculo.marcaId;
        axios.get('/api/Vehiculos/Modelos/' + id )
            .then(function (response) {
                that.modelos = response.data;
                console.log(response);

            }).catch(function (error) {
                console.log(error)
            })
    }


    editar(vehiculoSelected: Vehiculo) {
        this.vehiculo = vehiculoSelected;
        this.getModelos();
        this.vehiculo = vehiculoSelected;
        console.log(vehiculoSelected);
    }


    guardar() {

        debugger
        var that = this;
        var Entity = that.vehiculo;

        if (this.vehiculo.id == 0) {
           

            axios.post('/api/Vehiculos/', Entity)
                .then(function (response) {
                    console.log(that.vehiculo)

                    console.warn(response);

                    that.vehiculo.id = response.data.id;
                    that.vehiculo.marcaNombre = response.data.marcaNombre;
                    that.vehiculo.modeloNombre = response.data.modeloNombre;

                    that.vehiculos.push(that.vehiculo);

                    swal(
                        'Muy bien!',
                        'Registro Guardado!',
                        'success'
                    )

                    that.vehiculo = new Vehiculo();

                }).catch(function (error) {
                    console.log(error);
                })

        } else {


            Entity.marcaNombre = "";
            Entity.modeloNombre = "";

            axios.put('/api/Vehiculos/' + that.vehiculo.id, Entity)
                .then(function (response) {
                    console.log(that.vehiculo)

                    console.warn(response);

                    that.vehiculo.id = response.data.id;
                    that.vehiculo.marcaNombre = response.data.marcaNombre;
                    that.vehiculo.modeloNombre = response.data.modeloNombre;

                    that.vehiculos.push(that.vehiculo);

                    swal(
                        'Muy bien!',
                        'Registro Actualizado!',
                        'warning'
                    )

                    that.vehiculo = new Vehiculo();
                    that.cargar();

                }).catch(function (error) {
                    console.log(error);
                })


        }

     
       
    }

    eliminar(vehiculoSelected: Vehiculo) {
        var that = this;

        swal({
            title: 'Esta Seguro?',
            text: "No podra revertir este cambio!",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si',
            cancelButtonText: 'No',
            confirmButtonClass: 'btn btn-success',
            cancelButtonClass: 'btn btn-danger',
            buttonsStyling: false,
            reverseButtons: true
        }).then((result) => {
            if (result.value) {

                axios.delete('/api/Vehiculos/' + vehiculoSelected.id)
                    .then(function (reponse) {

                        swal(
                            'Eliminado!',
                            'Este registro fue eliminado',
                            'success'
                        )
                        that.cargar();
                    }).catch(function (error) {
                        console.log(error)
                    })


               
                // result.dismiss can be 'cancel', 'overlay',
                // 'close', and 'timer'
            }
        })
    }




}