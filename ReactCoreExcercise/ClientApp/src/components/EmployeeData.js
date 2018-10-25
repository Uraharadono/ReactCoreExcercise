/* eslint-disable */
export class EmployeeData {
    constructor(data) {
        this.employeeId;
        this.name;
        this.gender;
        this.city;
        this.department;

        if (data == undefined || data == null)
            return;
        this.employeeId = data.employeeId;
        this.name = data.name;
        this.gender = data.gender;
        this.city = data.city;
        this.department = data.department;
    }
}