import { ActivatedRoute, Router } from '@angular/router';
import { Component } from '@angular/core';
import { ProductoService } from '../services/producto.service';
import { Producto } from '../../models/producto';

@Component({
    selector: 'app-list-producto',
    templateUrl:'./list-producto.component.html'

})
export class ListProductoComponent {

    public prodList: Producto[];

    constructor(private _productoService: ProductoService) {
        this.listarProducto();
    }
    listarProducto() {
        this._productoService.listarProducto().subscribe(
            (data: Producto[]) => this.prodList = data);
    }
    eliminarproducto(productoID) {
        const ans = confirm('eliminar producto: ' + productoID);
        if (ans) {
            this._productoService.EliminarProducto(productoID).subscribe(() => {
                this.listarProducto();
            }, Error => console.error(Error));
        }
    }


}

