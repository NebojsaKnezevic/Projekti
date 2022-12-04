import React, { useEffect, useState } from "react"
import axios from "axios"
import SweetAlert from 'react-bootstrap-sweetalert'

let LibraComponent = () => {
    const [items, setItems] = useState([]);

    // SEARCH
    let [searchValue, setSearchValue] = useState([]);
    let handleSearching = (e) => {
        setSearchValue(e.target.value.toString());
        console.log(searchValue);
    }

    let searchForItems = () => {
        let URL = searchValue != "" ? (`https://localhost:5111/api/Libra/SearchByName?name=` + searchValue) : `https://localhost:5111/api/Libra/GetAll`
        axios.get(URL).then(response => {
            response.data.map(item => item.isEditting = false)
            setItems(response.data)
        }).catch(error => {setAlertErrorMessage(error.message); setShowError(true)});
    }


    // UPDATE
    let handleLibraInputchange = (Libra, Input) => {
        let libraNewReference = [...items];
        const index = libraNewReference.findIndex((item) => item.name == Libra.name)
        const {name, value} = Input.target;  
        libraNewReference[index] = { ...Libra, [name]: value};
        setItems(libraNewReference);
    }

    let editLibra = (Libra, isEdited) => {
        try{
            let libraNewReference = [...items];
            const index = libraNewReference.findIndex(item => item.name == Libra.name)
            libraNewReference[index].isEditting = isEdited;
            // libraNewReference[-1].isEditting = isEdited;
            setItems(libraNewReference);
        }catch(error){
            setAlertErrorMessage(error.message); 
            setShowError(true);
        }
        
    }

    let confirmUpdate = (Libra) => {
        axios.put('https://localhost:5111/api/Libra/Update', Libra).then(response =>{
            let libraNewReference = [...items];
            const index = libraNewReference.findIndex(item => item.name == Libra.name)
            libraNewReference[index] = Libra;
            libraNewReference[index].isEditting = false;
            setItems(libraNewReference);
        
        }).catch(error => {setAlertErrorMessage(error.message); setShowError(true)});
    }
    console.log(items);

    // INSERT/ADD

    const [libraToAdd, setLibraToAdd] = useState({name: '', address: '', telephone: ''});
    const handleInsertChange = (input) => {
        const {name, value} = input.target;
        let libraToAddNewReference = {...libraToAdd, [name]: value};
        setLibraToAdd(libraToAddNewReference);
    }

    const confirmNewLibra = () => {
        axios.post('https://localhost:5111/api/Libra/Create', libraToAdd).then(response => {
            let libraToAddNewReference = [...items];
            libraToAddNewReference.push(response.data);
            setItems(libraToAddNewReference);
            setLibraToAdd({name: '', address: '', telephone: ''});
            setShowAlert(true)
        }).catch(error => {setAlertErrorMessage(error.message); setShowError(true)});
    }

    // DELETE

    const deleteLibra = (Libra) => {
        axios.delete(`https://localhost:5111/api/Libra/Delete?id=${Libra.id}`).then(response => {
            let libraNewReference = [...items];
            const index = libraNewReference.findIndex(item => item.name == Libra.name);
            libraNewReference.splice(index,1);
            setItems(libraNewReference);
        }).catch(error => {setAlertErrorMessage(error.message); setShowError(true)});
    }

    // ALERTS

    const [showAlert, setShowAlert] = useState(false);
    const [showError, setShowError] = useState(false);
    const [alertErrorMessage, setAlertErrorMessage] = useState();
    return (
        <div>
            <hr />

            <div className="row">
                <div className="col-md-4">
                    <div className="card border border-secondary shadow-0">
                        <div className="card-header bg-secondary text-white"><b>Search</b> Libra<span className="glyphicon glyphicon-search"></span></div>
                        <div className="card-body">
                            <div className="row">
                                <div className="col-md-7">
                                    <label className="form-label">name</label>
                                    <input className="form-control" placeholder="Enter name" name="name" type="text" value={searchValue} onChange={handleSearching}/>
                                </div>
                                <div className="col-md-5">
                                    <label className="form-label">&nbsp;</label>
                                    <div className="btn-toolbar">
                                        <button type="button" className="btn btn-primary form-control" onClick={searchForItems.bind(this)}>Search</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div className="col-md-8">
                    <div className="card border border-secondary shadow-0">
                        <div className="card-header bg-secondary text-white"><b>New</b> Libra</div>
                        <div className="card-body">
                            <div className="row">
                                <div className="col-md-3">
                                    <label className="form-label">name</label>
                                    <input className="form-control" placeholder="Enter name" name="name" type="text" value={libraToAdd.name} onChange={handleInsertChange.bind(this)}/>
                                </div>
                                <div className="col-md-4">
                                    <label className="form-label">address</label>
                                    <input className="form-control" placeholder="Enter address" name="address" type="text" value={libraToAdd.address} onChange={handleInsertChange.bind(this)}/>
                                </div>
                                <div className="col-md-3">
                                    <label className="form-label">telephone</label>
                                    <input className="form-control" placeholder="Enter telephone" name="telephone" type="text" value={libraToAdd.telephone} onChange={handleInsertChange.bind(this)}/>
                                </div>
                                <div className="col-md-2">
                                    <label className="form-label">&nbsp;</label>
                                    <button type="button" className="btn btn-success form-control" onClick={confirmNewLibra.bind(this)}>Add</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                
                
            </div>

            <br />
            <div className="card border border-secondary shadow-0">
                        <div className="card-header bg-secondary text-white"><b>Display</b> List</div>
                        <div className="card-body">
                    <div className="table table-striped">
                                <thead>
                                    <tr>
                                        <th>Name</th>
                                        <th>Address</th>
                                        <th>Telephone</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {items.map(item => 
                                        <tr >
                                        <td ><input className="form-control" name="name" onChange={handleLibraInputchange.bind(this, item)} placeholder="Enter Name" value={item.name} type="text" disabled={!item.isEditting} /></td>
                                        <td><input className="form-control" name="address" onChange={handleLibraInputchange.bind(this, item)} placeholder="Enter Address" value={item.address} type="text" disabled={!item.isEditting}/></td>
                                        <td><input className="form-control" name="telephone" onChange={handleLibraInputchange.bind(this, item)} placeholder="Enter Telephone" value={item.telephone} type="text" disabled={!item.isEditting}/></td>
                                        <td>
                                            <div className="btn-toolbar">
                                                <button className="btn btn-info mx-1" onClick={editLibra.bind(this, item, true)} style={{display: item.isEditting ? 'none' : 'block'}}>Edit</button>
                                                <button className="btn btn-warning mx-1" onClick={editLibra.bind(this, item, false)} style={{display: item.isEditting ? 'block' : 'none'}}>Cancel</button>
                                                <button className="btn btn-success mx-1" onClick={confirmUpdate.bind(this, item)} style={{display: item.isEditting ? 'block' : 'none'}}>Save</button>
                                                <button className="btn btn-danger mx-1" onClick={deleteLibra.bind(this, item)} style={{display: item.isEditting ? 'none' : 'block'}}>Delete</button>
                                            </div>
                                        </td>
                                    </tr>
                                    )}


                                    {/* <tr>
                                        <td><input className="form-control" placeholder="Enter Name" value="Name" type="text"/></td>
                                        <td><input className="form-control" placeholder="Enter Address" value="Address" type="text"/></td>
                                        <td><input className="form-control" placeholder="Enter Telephone" value="Telephone" type="text"/></td>
                                        <td>
                                            <div className="btn-toolbar">
                                                <button className="btn btn-info mr-22">Update</button>
                                                <button className="btn btn-success mr-2">Save</button>
                                                <button className="btn btn-danger mr-2">Delete</button>
                                            </div>
                                        </td>
                                    </tr> */}
                                </tbody>
                            </div>
                        </div>
                    </div>
                    {showAlert && 
                        <SweetAlert
                            success
                            confirmBtnText='Ok'
                            confirmBtnBsStyle='success'
                            title='item successfully added'
                            onConfirm={()=> setShowAlert(false)}
                        >Pls click "ok" to close</SweetAlert>
                    }

                    {showError && 
                        <SweetAlert
                            warning
                            confirmBtnText='Ok'
                            confirmBtnBsStyle='warning'
                            title='Something went wrong'
                            onConfirm={()=> setShowError(false)}
                        >{alertErrorMessage}</SweetAlert>
                    }
        </div>
        )
}

export default LibraComponent;