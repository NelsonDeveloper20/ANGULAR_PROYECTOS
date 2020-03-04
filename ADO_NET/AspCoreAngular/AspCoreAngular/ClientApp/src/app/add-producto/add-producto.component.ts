import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductoService } from '../services/producto.service';
import {TipoProducto} from '../../models/TipoProducto'
import { Producto } from '../../models/producto';

@Component({
    selector: 'app-add-producto',
    templateUrl: './add-producto.component.html'
})

export class AddProductoComponent implements OnInit {

    productoForm: FormGroup;
    title = 'Create';
    idProducto: number;
    errorMessaje: any;
    tipoProdList: TipoProducto[];

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _productoService: ProductoService, private _router: Router) {
        if (this._avRoute.snapshot.params['id']) {
            this.idProducto = this._avRoute.snapshot.params['id'];
        }
        this.productoForm = this._fb.group({
            idProducto: 0,
            nombre: ['', [Validators.required]],
            precio: ['', [Validators.required]],
            imagen: ['', [Validators.required]],
            idTipoProducto: [0, [Validators.required]]

        })
    }

    ngOnInit() {
        this._productoService.listarTipoProcuto().subscribe(
            (data: TipoProducto[]) => this.tipoProdList = data);
        if (this.idProducto > 0) {
            this.title = 'Edit',
                this._productoService.listarProdcutoXid(this.idProducto)
                    .subscribe((response: Producto) => {
                        this.productoForm.setValue(response);
                    }, error => console.error(error));
        }
    }

    guardar() {

        if (!this.productoForm.valid) {
            return;
        }
        if (this.title === 'Create') {
            this._productoService.InsertarProducto(this.productoForm.value)
                .subscribe(() => {
                    this._router.navigate(['/list-producto']);
                }, error => console.error(error));
        } else if (this.title === 'Edit') {
            this._productoService.ModificarProducto(this.productoForm.value)
                .subscribe(() => {
                    this._router.navigate(['/list-producto']);
                }, error => console.error(error));
        }

    }        



    cancelar() {
        this._router.navigate(['/list-producto']);
    }

    get nombre() { return this.productoForm.get('nombre'); }
    get precio() { return this.productoForm.get('precio'); }
    get imagen() { return this.productoForm.get('imagen'); }
    get idTipoProducto() { return this.productoForm.get('idTipoProducto');}




}
