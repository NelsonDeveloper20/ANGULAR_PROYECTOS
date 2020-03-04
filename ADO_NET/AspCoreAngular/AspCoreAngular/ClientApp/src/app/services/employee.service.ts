 
import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Employee } from '../../models/employee';

Injectable({
    providedIn:'root'
})
export class EmployeeService {

    apiurl = '';

     

    constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.apiurl = baseUrl + 'api/Employee/';
    }
    getCityList() {
        return this._http.get(this.apiurl + 'GetCityList')
            .pipe(map(
                response => {
                    return response;
                }));
    }

    getEmployees() {
        return this._http.get(this.apiurl + 'Index').pipe(map(
            response => {
                return response;
            }));
    }

    getEmployeeById(id: number) {
        return this._http.get(this.apiurl + 'Details/' + id)
            .pipe(map(
                response => {
                    return response;
                }));
    }

    saveEmployee(employee: Employee) {
        return this._http.post(this.apiurl + 'Create', employee)
            .pipe(map(
                response => {
                    return response;
                }));
    }

    updateEmployee(employee: Employee) {
        return this._http.put(this.apiurl + 'Edit', employee)
            .pipe(map(
                response => {
                    return response;
                }));
    }

    deleteEmployee(id: number) {
        return this._http.delete(this.apiurl + 'Delete/' + id)
            .pipe(map(
                response => {
                    return response;
                }));
    }
}
