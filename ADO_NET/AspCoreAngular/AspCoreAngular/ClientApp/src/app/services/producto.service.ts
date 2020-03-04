import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Producto } from '../../models/producto';

Injectable({
    providedIn:'root'
})

export class ProductoService {

    apiUrl = '';
    //Obtener APi 
    constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.apiUrl = baseUrl + 'api/Producto/';
    }
    //Listar producto
    listarTipoProcuto() {
        return this._http.get(this.apiUrl + 'listarTipoProducto')
            .pipe(map(
                response => {
                    return response;
                }
            ));
    }
    //Listar producto
    listarProducto(){
        return this._http.get(this.apiUrl + 'Index').pipe(map(
            response => {
                return response;
            }));
    }
    //listar Prodcuto por id
    listarProdcutoXid(id: number) {
        return this._http.get(this.apiUrl + 'Details/' + id).pipe(map(
            response => {
                return response;
            }
        ));
    }

    //insertarProducto
    InsertarProducto(producto: Producto) {
        console.log(producto);
        return this._http.post(this.apiUrl + 'Create', producto).pipe(map(
            response => {
                return response;
            }));
    } 
    ModificarProducto(producto: Producto) {
        return this._http.put(this.apiUrl + 'Edit', producto).pipe(map(
            response => {
                return response;
            }));
    }

    EliminarProducto(id: number) {
        return this._http.delete(this.apiUrl + 'Delete/' + id).pipe(map(
            response => {
                return response;
            }));
    }

}
