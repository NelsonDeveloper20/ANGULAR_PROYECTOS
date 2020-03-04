import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UsuarioService } from '../services/usuario.service';
import { TipoUsuario } from '../../models/tipousuario'
import { Usuario } from '../../models/usuario';

@Component({
    selector: 'app-add-usuario',
    templateUrl: './add-usuario.component.html'
})

export class AddUsuarioComponent implements OnInit {

    usuarioForm: FormGroup;
    title = 'Create';
    idUsuario: number;
    errorMessaje: any;
    tipoUserList: TipoUsuario[];

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _usuarioService: UsuarioService, private _router: Router) {
        if (this._avRoute.snapshot.params['id']) {
            this.idUsuario = this._avRoute.snapshot.params['id'];
        }  

        this.usuarioForm = this._fb.group({
            idUsuario: 0,
            nombre: ['', [Validators.required]],
            apellido: ['', [Validators.required]],
            email: ['', [Validators.required]],
            clave: ['', [Validators.required]],
            imagen: ['', [Validators.required]],
            idTipoUsuario: [0, [Validators.required]]

        })
    }

    ngOnInit() {
        this._usuarioService.listarTipoUsuario().subscribe(
            (data: TipoUsuario[]) => this.tipoUserList = data);
        if (this.idUsuario > 0) {
            this.title = 'Edit',
                this._usuarioService.listarUsuarioXid(this.idUsuario)
                    .subscribe((response: Usuario) => {
                        this.usuarioForm.setValue(response);
                    }, error => console.error(error));
        }
    }

    guardar() {

        if (!this.usuarioForm.valid) {
            return;
        }
        if (this.title === 'Create') {
            this._usuarioService.insertarUsuario(this.usuarioForm.value)
                .subscribe(() => {
                    this._router.navigate(['/list-usuario']);
                }, error => console.error(error));
        } else if (this.title === 'Edit') {
            this._usuarioService.ModificarUsuario(this.usuarioForm.value)
                .subscribe(() => {
                    this._router.navigate(['/list-usuario']);
                }, error => console.error(error));
        }

    }



    cancelar() {
        this._router.navigate(['/list-usuario']);
    }

    get nombre() { return this.usuarioForm.get('nombre'); }
    get apellido() { return this.usuarioForm.get('apellido'); }
    get email() { return this.usuarioForm.get('email'); }
    get clave() { return this.usuarioForm.get('clave'); }
    get imagen() { return this.usuarioForm.get('imagen'); }
    get idTipoUsuario() { return this.usuarioForm.get('idTipoUsuario'); }




}
