
import { ActivatedRoute, Router } from '@angular/router';
import { Component } from '@angular/core';
import { EmployeeService } from '../services/employee.service';
import { Employee } from '../../models/employee';

@Component({
    selector: 'app-fetch-employee',
    templateUrl: './fetch-employee.component.html',
    //error proviider service correccion
    //providers: [EmployeeService]
    //styleUrls: ['./fetch-employee.component']
    
})
export class FetchEmployeeComponent {

    public empList: Employee[];

    constructor(private _employeeService: EmployeeService) {
        this.getEmployees();
    }

    getEmployees() {
        this._employeeService.getEmployees().subscribe(
            (data: Employee[]) => this.empList = data
        );
    }

    delete(employeeID) {
        const ans = confirm('Do you want to delete employee with Id: ' + employeeID);
        if (ans) {
            this._employeeService.deleteEmployee(employeeID).subscribe(() => {
                this.getEmployees();
            }, error => console.error(error));
        }
    }
}
