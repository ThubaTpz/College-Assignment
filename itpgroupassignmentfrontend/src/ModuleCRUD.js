import React, { useState, useEffect, Fragment } from "react";
import Table from 'react-bootstrap/Table';
import 'bootstrap/dist/css/bootstrap.css';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import axios from 'axios';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const ModuleCRUD = () => {
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  const [id, setId] = useState('');
  const [name, setName] = useState('');
  const [credits, setCredits] = useState('');
  const [moduleCode, setModuleCode] = useState('');
  const [data, setData] = useState([]);

  useEffect(()=>{ getData(); },[]);
  const getData = () => {
    axios.get('https://localhost:7040/api/Module')
      .then(res => setData(res.data))
      .catch(err => console.error(err));
  }

  const clear = ()=>{ setId(''); setName(''); setCredits(''); setModuleCode(''); }

  const handleSave = ()=>{
    axios.post('https://localhost:7040/api/Module', { name, credits, moduleCode })
      .then(()=>{ toast.success('Module added'); getData(); clear(); })
      .catch(err => { console.error(err); toast.error('Failed to add'); });
  }

  const handleEdit = (id)=>{ handleShow(); axios.get(`https://localhost:7040/api/Module/${id}`)
    .then(res=>{ const d=res.data; setName(d.name); setCredits(d.credits); setModuleCode(d.moduleCode); setId(d.id ?? d.Id); })
    .catch(err=>{ console.error(err); toast.error('Failed to load'); }); }

  const handleUpdate = ()=>{
    if(!id){ toast.error('No module selected'); return; }
    axios.put(`https://localhost:7040/api/Module?Id=${encodeURIComponent(id)}`, { name, credits, moduleCode })
      .then(()=>{ toast.success('Updated'); getData(); handleClose(); clear(); })
      .catch(err=>{ console.error(err); toast.error('Failed to update'); });
  }

  const handleDelete = (id)=>{ if(!window.confirm('Delete module?')) return; axios.delete(`https://localhost:7040/api/Module/${id}`)
    .then(()=>{ toast.success('Deleted'); getData(); })
    .catch(err=>{ console.error(err); toast.error('Failed to delete'); }); }

  return (
    <Fragment>
      <ToastContainer />
      <Container>
        <Row className="mb-3">
          <Col><input className="form-control" placeholder="Name" value={name} onChange={e=>setName(e.target.value)}/></Col>
          <Col><input className="form-control" placeholder="Credits" value={credits} onChange={e=>setCredits(e.target.value)}/></Col>
          <Col><input className="form-control" placeholder="Module Code" value={moduleCode} onChange={e=>setModuleCode(e.target.value)}/></Col>
          <Col><button className="btn btn-primary" onClick={handleSave}>Add</button></Col>
        </Row>
        <Table striped bordered hover>
          <thead>
            <tr><th>#</th><th>Name</th><th>Credits</th><th>ModuleCode</th><th>Actions</th></tr>
          </thead>
          <tbody>
            {data && data.map((d,i)=>(<tr key={i}><td>{i+1}</td><td>{d.name}</td><td>{d.credits}</td><td>{d.moduleCode}</td>
              <td>
                <button className="btn btn-sm btn-primary me-2" onClick={()=>handleEdit(d.id ?? d.Id)}>Edit</button>
                <button className="btn btn-sm btn-danger" onClick={()=>handleDelete(d.id ?? d.Id)}>Delete</button>
              </td>
            </tr>))}
          </tbody>
        </Table>

        <Modal show={show} onHide={handleClose} dialogClassName="wide-modal">
          <Modal.Header closeButton><Modal.Title>Edit Module</Modal.Title></Modal.Header>
          <Modal.Body>
            <Row>
              <Col><input className="form-control" value={name} onChange={e=>setName(e.target.value)}/></Col>
              <Col><input className="form-control" value={credits} onChange={e=>setCredits(e.target.value)}/></Col>
              <Col><input className="form-control" value={moduleCode} onChange={e=>setModuleCode(e.target.value)}/></Col>
            </Row>
          </Modal.Body>
          <Modal.Footer>
            <Button variant="secondary" onClick={handleClose}>Close</Button>
            <Button variant="primary" onClick={handleUpdate}>Save changes</Button>
          </Modal.Footer>
        </Modal>
      </Container>
    </Fragment>
  )
}

export default ModuleCRUD;
