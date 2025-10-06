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

const AdminCRUD = () => {
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  const [id, setId] = useState('');
  const [name, setName] = useState('');
  const [surname, setSurname] = useState('');
  const [gender, setGender] = useState('');
  const [dateOfBirth, setDateOfBirth] = useState('');
  const [homeAddress, setHomeAddress] = useState('');
  const [email, setEmail] = useState('');
  const [phone, setPhone] = useState('');
  const [data, setData] = useState([]);

  useEffect(()=>{ getData(); },[]);
  const getData = () => { axios.get('https://localhost:7040/api/Admin').then(res=>setData(res.data)).catch(err=>console.error(err)); }
  const clear = ()=>{ setId(''); setName(''); setSurname(''); setGender(''); setDateOfBirth(''); setHomeAddress(''); setEmail(''); setPhone(''); }

  const handleSave = ()=>{ axios.post('https://localhost:7040/api/Admin', { name, surname, gender, dateOfBirth, homeAddress, email, phoneNumber: phone })
    .then(()=>{ toast.success('Admin added'); getData(); clear(); })
    .catch(err=>{ console.error(err); toast.error('Failed to add'); }); }

  const handleEdit = (id)=>{ handleShow(); axios.get(`https://localhost:7040/api/Admin/${id}`)
    .then(res=>{ const d=res.data; setName(d.name); setSurname(d.surname); setGender(d.gender); setDateOfBirth(d.dateOfBirth); setHomeAddress(d.homeAddress); setEmail(d.email); setPhone(d.phoneNumber); setId(d.id ?? d.Id); })
    .catch(err=>{ console.error(err); toast.error('Failed to load'); }); }

  const handleUpdate = ()=>{ if(!id){ toast.error('No admin selected'); return; } axios.put(`https://localhost:7040/api/Admin?Id=${encodeURIComponent(id)}`, { name, surname, gender, dateOfBirth, homeAddress, email, phoneNumber: phone })
    .then(()=>{ toast.success('Updated'); getData(); handleClose(); clear(); })
    .catch(err=>{ console.error(err); toast.error('Failed to update'); }); }

  const handleDelete = (id)=>{ if(!window.confirm('Delete admin?')) return; axios.delete(`https://localhost:7040/api/Admin/${id}`)
    .then(()=>{ toast.success('Deleted'); getData(); })
    .catch(err=>{ console.error(err); toast.error('Failed to delete'); }); }

  return (
    <Fragment>
      <ToastContainer />
      <Container>
        <Row className="mb-3">
          <Col><input className="form-control" placeholder="Name" value={name} onChange={e=>setName(e.target.value)}/></Col>
          <Col><input className="form-control" placeholder="Surname" value={surname} onChange={e=>setSurname(e.target.value)}/></Col>
          <Col><input className="form-control" placeholder="Gender" value={gender} onChange={e=>setGender(e.target.value)}/></Col>
          <Col><input className="form-control" type="date" placeholder="DOB" value={dateOfBirth} onChange={e=>setDateOfBirth(e.target.value)}/></Col>
          <Col><input className="form-control" placeholder="Address" value={homeAddress} onChange={e=>setHomeAddress(e.target.value)}/></Col>
          <Col><input className="form-control" type="email" placeholder="Email" value={email} onChange={e=>setEmail(e.target.value)}/></Col>
          <Col><input className="form-control" placeholder="Phone" value={phone} onChange={e=>setPhone(e.target.value)}/></Col>
          <Col><button className="btn btn-primary" onClick={handleSave}>Add</button></Col>
        </Row>

        <Table striped bordered hover>
          <thead>
            <tr>
              <th>#</th>
              <th>Name</th>
              <th>Surname</th>
              <th>Gender</th>
              <th>DOB</th>
              <th>Address</th>
              <th>Email</th>
              <th>Phone</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {data && data.map((item, i) => (
              <tr key={i}>
                <td>{i+1}</td>
                <td>{item.name}</td>
                <td>{item.surname}</td>
                <td>{item.gender}</td>
                <td>{item.dateOfBirth}</td>
                <td>{item.homeAddress}</td>
                <td>{item.email}</td>
                <td>{item.phoneNumber}</td>
                <td>
                  <button className="btn btn-sm btn-primary me-2" onClick={()=>handleEdit(item.id ?? item.Id ?? item.adminID)}>Edit</button>
                  <button className="btn btn-sm btn-danger" onClick={()=>handleDelete(item.id ?? item.Id ?? item.adminID)}>Delete</button>
                </td>
              </tr>
            ))}
          </tbody>
        </Table>

        <Modal show={show} onHide={handleClose} dialogClassName="wide-modal">
          <Modal.Header closeButton>
            <Modal.Title>Edit Admin</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <Row>
              <Col><input className="form-control" value={name} onChange={e=>setName(e.target.value)}/></Col>
              <Col><input className="form-control" value={surname} onChange={e=>setSurname(e.target.value)}/></Col>
              <Col><input className="form-control" value={gender} onChange={e=>setGender(e.target.value)}/></Col>
              <Col><input className="form-control" type="date" value={dateOfBirth} onChange={e=>setDateOfBirth(e.target.value)}/></Col>
              <Col><input className="form-control" value={homeAddress} onChange={e=>setHomeAddress(e.target.value)}/></Col>
              <Col><input className="form-control" type="email" value={email} onChange={e=>setEmail(e.target.value)}/></Col>
              <Col><input className="form-control" value={phone} onChange={e=>setPhone(e.target.value)}/></Col>
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

export default AdminCRUD;
