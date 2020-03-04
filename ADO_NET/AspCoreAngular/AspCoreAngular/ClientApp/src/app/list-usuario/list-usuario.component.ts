import { ActivatedRoute, Router } from '@angular/router';
import { Component } from '@angular/core';
import { UsuarioService } from '../services/usuario.service';
import { Usuario } from '../../models/usuario';

@Component({
    selector: 'app-list-usuario',
    templateUrl: './list-usuario.component.html'
})

export class ListUsuarioComponent {
    public userList: Usuario[];

    constructor(private _usuarioService: UsuarioService) {
        this.listarUsuario();
    }

    listarUsuario() {
        this._usuarioService.listarUsuario().subscribe((
            data: Usuario[]) => this.userList = data);
    }
    eliminarUsuario(idUsuario) {
        const ans = confirm('Eliminar Usuario:' + idUsuario)
        if (ans) {
            this._usuarioService.eliminarUsuario(idUsuario).subscribe(
                () => {
                    this.listarUsuario();
                }, error => console.error(error));
        }
    }
}
