/* eslint-disable */
// import * as React from 'react';
import React, { Component } from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';
import { EmployeeData } from './EmployeeData';

export class AddEmployee extends Component {
    constructor(props) {
        super(props);
        this.state = { title: "", loading: true, cityList: [], empData: new EmployeeData };

        fetch('api/Employee/GetCityList')
            .then(response => response.json())
            .then(data => {
                this.setState({ cityList: data });
            });
        var empid = this.props.match.params["empid"];
        console.log(empid);
        // This will set state for Edit employee  
        if (empid > 0) {
            fetch('api/Employee/Details/' + empid)
                .then(response => response.json())
                .then(data => {
                    console.log(data);
                    this.setState({ title: "Edit", loading: false, empData: data });
                });
        }
        // This will set state for Add employee  
        else {
            console.log("else")
            this.state = { title: "Create", loading: false, cityList: [], empData: new EmployeeData };
        }
        console.log("izvan");
        // This binding is necessary to make "this" work in the callback  
        this.handleSave = this.handleSave.bind(this);
        this.handleCancel = this.handleCancel.bind(this);
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderCreateForm(this.state.cityList);
        return <div>
            <h1>{this.state.title}</h1>
            <h3>Employee</h3>
            <hr />
            {contents}
        </div>;
    }

    // This will handle the submit form event.  
    handleSave(event) {
        event.preventDefault();
        const data = new FormData(event.target);
        console.log(data);
        // PUT request for Edit employee.  
        if (this.state.empData.employeeId) {
            console.log("put");
            fetch('api/Employee/Edit', {
                method: 'PUT',
                body: data,
            }).then((response) => response.json())
                .then((responseJson) => {
                    this.props.history.push("/fetchemployee");
                })
        }
        // POST request for Add employee.  
        else {
            console.log("post");
            fetch('api/Employee/Create', {
                method: 'POST',
                body: data,
            }).then((response) => response.json())
                .then((responseJson) => {
                    console.log(responseJson);
                    this.props.history.push("/fetchemployee");
                })
        }
    }

    // This will handle Cancel button click event.  
    handleCancel(e) {
        e.preventDefault();
        this.props.history.push("/fetchemployee");
    }

    // Returns the HTML Form to the render() method.  
    renderCreateForm(cityList) {
        return (
            <form onSubmit={this.handleSave} >
                <div className="form-group row" >
                    <input type="hidden" name="employeeId" value={this.state.empData.employeeId} />
                </div>
                < div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="Name">Name</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="name" defaultValue={this.state.empData.name} required />
                    </div>
                </div >
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="Gender">Gender</label>
                    <div className="col-md-4">
                        <select className="form-control" data-val="true" name="gender" defaultValue={this.state.empData.gender} required>
                            <option key="0" value="">-- Select Gender --</option>
                            <option key="1" value="Male">Male</option>
                            <option key="2" value="Female">Female</option>
                        </select>
                    </div>
                </div >
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="Department" >Department</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="Department" defaultValue={this.state.empData.department} required />
                    </div>
                </div>
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="City">City</label>
                    <div className="col-md-4">
                        <select className="form-control" data-val="true" name="City" defaultValue={this.state.empData.city} required>
                            <option key="-1" value="">-- Select City --</option>
                            {cityList.map(city =>
                                <option key={city.cityId} value={city.cityName}>{city.cityName}</option>
                            )}
                        </select>
                    </div>
                </div >
                <div className="form-group">
                    <button type="submit" className="btn btn-default">Save</button>
                    <button className="btn" onClick={this.handleCancel}>Cancel</button>
                </div >
            </form >
        )
    }
}