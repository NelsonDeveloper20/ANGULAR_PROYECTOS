import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Usuario } from '../../models/usuario'; 

Injectable({
    providedIn:'root'
})

export class UsuarioService {
    apiUrl = '';

    constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.apiUrl = baseUrl + 'api/Usuario/';
    }

    listarUsuario() {
        return this._http.get(this.apiUrl + 'Index').pipe(map(
            response => {
                return response;
            }));
    }
    listarUsuarioXid(id: number) {
        return this._http.get(this.apiUrl + 'Detalle/' + id).pipe(map(
            response => {
                return response;
            }
        ));
    }
    listarTipoUsuario() {
        return this._http.get(this.apiUrl + 'listTipoUsuario').pipe(map(
            response => {
                return response;
            }));
    }

    insertarUsuario(usuario:Usuario) {
        return this._http.post(this.apiUrl + 'Create', usuario).pipe(map(
            response => {
                return response;
            }));
    }
    ModificarUsuario(usuario: Usuario) {
        return this._http.put(this.apiUrl + 'Edit', usuario).pipe(map(
            response => {
                return response;
            }
        ));
    }
    eliminarUsuario(id: number) {
        return this._http.delete(this.apiUrl + 'Delete/' + id).pipe(map(
            response => {
                return response;
            }));
    }
   
}
