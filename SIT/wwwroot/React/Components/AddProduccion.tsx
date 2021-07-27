import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';
import { ProduccionData } from './FetchProduccion';

interface AddProduccionDataState {
    title: string;
    loading: boolean;
    GrupoRecursoList: Array<any>;
    empData: ProduccionData;
}

export class AddProduccion extends React.Component<RouteComponentProps<{}>, AddProduccionDataState> {
    constructor(props) {
        super(props);

        this.state = { title: "", loading: true, GrupoRecursoList: [], empData: new ProduccionData };

        fetch('api/GrupoRecursoesAPI/GetGrupoRecurso?tokens=55C3444C-D463-4FE9-8F9D-93EBCAF69788')
            .then(response => response.json() as Promise<Array<any>>)
            .then(data => {
                this.setState({ GrupoRecursoList: data });
            });

        var empid = this.props.match.params["id"];

        // This will set state for Edit employee  
        if (empid > 0) {
            fetch('api/TrProduccionAPI/Details/' + empid)
                .then(response => response.json() as Promise<ProduccionData>)
                .then(data => {
                    this.setState({ title: "Edit", loading: false, empData: data });
                });
        }

        // This will set state for Add employee  
        else {
            this.state = { title: "Create", loading: false, GrupoRecursoList: [], empData: new ProduccionData };
        }

        // This binding is necessary to make "this" work in the callback  
        this.handleSave = this.handleSave.bind(this);
        this.handleCancel = this.handleCancel.bind(this);
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderCreateForm(this.state.GrupoRecursoList);

        return <div>
            <h1>{this.state.title}</h1>
            <h3>Produccion</h3>
            <hr />
            {contents}
        </div>;
    }

    // This will handle the submit form event.  
    private handleSave(event) {
        event.preventDefault();
        const data = new FormData(event.target);

        // PUT request for Edit employee.  
        if (this.state.empData.Id) {
            fetch('api/TrProduccionAPI/Edit', {
                method: 'PUT',
                body: data,

            }).then((response) => response.json())
                .then((responseJson) => {
                    this.props.history.push("/fetchproduccion");
                })
        }

        // POST request for Add employee.  
        else {
            fetch('api/TrProduccionAPI/Create', {
                method: 'POST',
                body: data,

            }).then((response) => response.json())
                .then((responseJson) => {
                    this.props.history.push("/fetchproduccion");
                })
        }
    }

    // This will handle Cancel button click event.  
    private handleCancel(e) {
        e.preventDefault();
        this.props.history.push("/fetchproduccion");
    }

    // Returns the HTML Form to the render() method.  
    private renderCreateForm(gruporecursoList: Array<any>) {
        return (
            <form onSubmit={this.handleSave} >
                <div className="form-group row" >
                    <input type="hidden" name="Id" value={this.state.empData.Id} />
                </div>
                < div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="Name">Componente</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="name" defaultValue={this.state.empData.IdComponente} required />
                    </div>
                </div >
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="Gender">Grupo</label>
                    <div className="col-md-4">
                        <select className="form-control" data-val="true" name="gender" defaultValue={this.state.empData.IdGrupoRecurso} required>
                            <option value="">-- Select Gender --</option>
                            <option value="Male">Male</option>
                            <option value="Female">Female</option>
                        </select>
                    </div>
                </div >
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="Department" >Operacion</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="Department" defaultValue={this.state.empData.IdOperacion} required />
                    </div>
                </div>
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="City">Producto</label>
                    <div className="col-md-4">
                        <select className="form-control" data-val="true" name="City" defaultValue={this.state.empData.IdGrupoRecurso} required>
                            <option value="">-- Select City --</option>
                            {gruporecursoList.map(grupo =>
                                <option key={grupo.Id} value={grupo.Grupo}>{grupo.Grupo}</option>
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