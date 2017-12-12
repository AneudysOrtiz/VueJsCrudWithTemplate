export class Vehiculo{

    id: number;
    chasis: string;
    marcaId: number;
    marcaNombre: string;
    modeloId: number;
    modeloNombre: string;
    color: string;
    ano: string;
    fecha: Date;

    constructor() {
        this.id = 0;
        this.modeloId = 0;
        this.marcaId = 0;
        this.chasis = "";
        this.marcaNombre = "";
        this.color = "";
        this.modeloNombre = "";
        this.ano = "";
    }


}

export class Marca {
    id: number;
    nombre: string;

}

export class Modelo {
    id: number;
    nombre: string;
    marcaId: number;


}