 
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { EmployeeService } from './services/employee.service';
import { ProductoService } from './services/producto.service';
import { UsuarioService } from './services/usuario.service';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { FetchEmployeeComponent } from './fetch-employee/fetch-employee.component';
import { AddEmployeeComponent } from './add-employee/add-employee.component'; 
import { ListProductoComponent } from './list-producto/list-producto.component';
import { ReactiveFormsModule } from '@angular/forms'
import { AddProductoComponent } from './add-producto/add-producto.component';
import { ListUsuarioComponent } from './list-usuario/list-usuario.component';
import { AddUsuarioComponent } from './add-usuario/add-usuario.component';
/*
NullInjectorError: No provider for FormBuilder! NullInjectorError: StaticInjectorError(AppModule)
solucion:
import { ReactiveFormsModule } from '@angular/forms'
import { FormsModule } from '@angular/forms';

*/
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
        FetchEmployeeComponent,
        AddEmployeeComponent,
        ListProductoComponent,
        AddProductoComponent,
        ListUsuarioComponent,
        AddUsuarioComponent
  ],
  imports: [
      BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }), 
      ReactiveFormsModule, 
      FormsModule   ,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
        { path: 'fetch-data', component: FetchDataComponent },

        { path: 'fetch-employee', component: FetchEmployeeComponent }, 
        { path: 'register-employee', component: AddEmployeeComponent },
        { path: 'employee/edit/:id', component: AddEmployeeComponent },
        { path: 'list-producto', component: ListProductoComponent },

        { path: 'add-producto', component: AddProductoComponent },
        { path: 'producto/edit/:id', component: AddProductoComponent },
        { path: 'registrar-producto', component: AddProductoComponent },

        { path: 'list-usuario', component: ListUsuarioComponent },
        { path: 'add-usuario', component: AddUsuarioComponent },
        { path: 'usuario/edit/:id',component:AddUsuarioComponent}
    ])
  ],
    providers: [EmployeeService, ProductoService, UsuarioService],
  bootstrap: [AppComponent]
})
export class AppModule { }
