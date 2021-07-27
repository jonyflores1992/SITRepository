import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';

interface FetchProduccionDataState {
    empList: ProduccionData[];
    loading: boolean;
} 

export class FetchProduccion extends React.Component<RouteComponentProps<{}>, FetchProduccionDataState> {
    constructor(props) {
        super(props);
        this.state = { empList: [], loading: true };

        fetch('api/TrProduccionAPI/Index')
            .then(response => response.json() as Promise<ProduccionData[]>)
            .then(data => {
                this.setState({ empList: data, loading: false });
            });

        // This binding is necessary to make "this" work in the callback  
        this.handleDelete = this.handleDelete.bind(this);
        this.handleEdit = this.handleEdit.bind(this);

    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderProduccionTable(this.state.empList);

        return <div>
            <h1>Employee Data</h1>
            <p>This component demonstrates fetching Employee data from the server.</p>
            <p>
                <Link to="/Create">Create New</Link>
            </p>
            {contents}
        </div>;
    }

    // Handle Delete request for an employee  
    private handleDelete(id: string) {
        if (!confirm("Do you want to delete employee with Id: " + id))
            return;
        else {
            fetch('api/TrProduccionAPI/DeleteTrProduccion/' + id, {
                method: 'delete'
            }).then(data => {
                this.setState(
                    {
                        empList: this.state.empList.filter((rec) => {
                            return (rec.Id != id);
                        })
                    });
            });
        }
    }

    private handleEdit(id: string) {
        this.props.history.push("/TrProduccionAPI/edit/" + id);
    }

    // Returns the HTML table to the render() method.  
    private renderProduccionTable(empList: ProduccionData[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th></th>
                    <th>Id</th>
                    <th>Componente</th>
                    <th>Operacion</th>
                    <th>Producto</th>
                    <th>Movimiento</th>
                </tr>
            </thead>
            <tbody>
                {empList.map(emp =>
                    <tr key={emp.Id}>
                        <td></td>
                        <td>{emp.IdComponente}</td>
                        <td>{emp.IdGrupoRecurso}</td>
                        <td>{emp.IdOperacion}</td>
                        <td>{emp.IdProducto}</td>
                        <td>{emp.IdTrMovimiento}</td>
                        <td>
                            <a className="action" onClick={(id) => this.handleEdit(emp.Id)}>Edit</a>  |
                            <a className="action" onClick={(id) => this.handleDelete(emp.Id)}>Delete</a>
                        </td>
                    </tr>
                )}
            </tbody>
        </table>;
    }
}

export class ProduccionData {
    Id: string = "";
    IdProducto: string = "";
    IdComponente: string = "";
    IdOperacion: string = "";
    Cantidad: string = "";
    IdRecurso: string = "";
    IdGrupoRecurso: string = "";
    IdTrMovimiento: string = "";
}