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

const TaskItemCRUD = () => {
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  const [id, setId] = useState('');
  const [name, setName] = useState('');
  const [dueDate, setDueDate] = useState('');
  const [data, setData] = useState([]);

  useEffect(()=>{ getData(); },[]);
  const getData = () => {
    axios.get('https://localhost:7040/api/TaskItem')
      .then(res => setData(res.data))
      .catch(err => console.error(err));
  }

  const clear = ()=>{ setId(''); setName(''); setDueDate(''); }

  const handleSave = ()=>{
    axios.post('https://localhost:7040/api/TaskItem', { name, dueDate })
      .then(()=>{ toast.success('Task added'); getData(); clear(); })
      .catch(err => { console.error(err); toast.error('Failed to add'); });
  }

  const handleEdit = (id)=>{ handleShow(); axios.get(`https://localhost:7040/api/TaskItem/${id}`)
    .then(res=>{ const d=res.data; setName(d.name); setDueDate(d.dueDate); setId(d.id ?? d.Id); })
    .catch(err=>{ console.error(err); toast.error('Failed to load'); }); }

  const handleUpdate = ()=>{
    if(!id){ toast.error('No task selected'); return; }
    axios.put(`https://localhost:7040/api/TaskItem?Id=${encodeURIComponent(id)}`, { name, dueDate })
      .then(()=>{ toast.success('Updated'); getData(); handleClose(); clear(); })
      .catch(err=>{ console.error(err); toast.error('Failed to update'); });
  }

  const handleDelete = (id)=>{ if(!window.confirm('Delete task?')) return; axios.delete(`https://localhost:7040/api/TaskItem/${id}`)
    .then(()=>{ toast.success('Deleted'); getData(); })
    .catch(err=>{ console.error(err); toast.error('Failed to delete'); }); }

  return (
    <Fragment>
      <ToastContainer />
      <Container>
        <Row className="mb-3">
          <Col><input className="form-control" placeholder="Name" value={name} onChange={e=>setName(e.target.value)}/></Col>
          <Col><input className="form-control" type="date" placeholder="Due" value={dueDate} onChange={e=>setDueDate(e.target.value)}/></Col>
          <Col><button className="btn btn-primary" onClick={handleSave}>Add</button></Col>
        </Row>
        <Table striped bordered hover>
          <thead>
            <tr><th>#</th><th>Name</th><th>DueDate</th><th>Actions</th></tr>
          </thead>
          <tbody>
            {data && data.map((d,i)=>(<tr key={i}><td>{i+1}</td><td>{d.name}</td><td>{d.dueDate}</td>
              <td>
                <button className="btn btn-sm btn-primary me-2" onClick={()=>handleEdit(d.id ?? d.Id)}>Edit</button>
                <button className="btn btn-sm btn-danger" onClick={()=>handleDelete(d.id ?? d.Id)}>Delete</button>
              </td>
            </tr>))}
          </tbody>
        </Table>

        <Modal show={show} onHide={handleClose} dialogClassName="wide-modal">
          <Modal.Header closeButton><Modal.Title>Edit Task</Modal.Title></Modal.Header>
          <Modal.Body>
            <Row>
              <Col><input className="form-control" value={name} onChange={e=>setName(e.target.value)}/></Col>
              <Col><input className="form-control" type="date" value={dueDate} onChange={e=>setDueDate(e.target.value)}/></Col>
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

export default TaskItemCRUD;
