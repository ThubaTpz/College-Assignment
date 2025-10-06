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

const LecturerCRUD = () => {
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  const [lecturerId, setLecturerId] = useState('');
  const [name, setName] = useState('');
  const [surname, setSurname] = useState('');
  const [gender, setGender] = useState('');
  const [dateOfBirth, setDateOfBirth] = useState('');
  const [homeAddress, setHomeAddress] = useState('');
  const [email, setEmail] = useState('');
  const [phone, setPhone] = useState('');

  const [data, setData] = useState([]);

  useEffect(() => { getLecturers(); }, []);

  const getLecturers = () => {
    axios.get('https://localhost:7040/api/Lecturer')
      .then(res => setData(res.data))
      .catch(err => console.error('Get lecturers error', err));
  }

  const clear = () => {
    setLecturerId('');
    setName('');
    setSurname('');
    setGender('');
    setDateOfBirth('');
    setHomeAddress('');
    setEmail('');
    setPhone('');
  }

  const handleSave = () => {
    const url = 'https://localhost:7040/api/Lecturer';
    const payload = {
      name, surname, gender, dateOfBirth, homeAddress, email, phoneNumber: phone
    };
    axios.post(url, payload)
      .then(() => { getLecturers(); clear(); toast.success('Lecturer added'); })
      .catch(err => { console.error(err); toast.error('Failed to add lecturer'); });
  }

  const handleEdit = (id) => {
    handleShow();
    axios.get(`https://localhost:7040/api/Lecturer/${id}`)
      .then(res => {
        const d = res.data;
        setName(d.name);
        setSurname(d.surname);
        setGender(d.gender);
        setDateOfBirth(d.dateOfBirth);
        setHomeAddress(d.homeAddress);
        setEmail(d.email);
        setPhone(d.phoneNumber);
        setLecturerId(d.id ?? d.Id ?? d.lecturerID);
      })
      .catch(err => { console.error('Fetch lecturer error', err); toast.error('Failed to load lecturer'); });
  }

  const handleDelete = (id) => {
    if (!window.confirm('Delete lecturer?')) return;
    axios.delete(`https://localhost:7040/api/Lecturer/${id}`)
      .then(() => { toast.success('Deleted'); getLecturers(); })
      .catch(err => { console.error('Delete error', err); toast.error('Failed to delete'); });
  }

  const handleUpdate = () => {
    if(!lecturerId){ toast.error('No lecturer selected for update'); return; }
    axios.put(`https://localhost:7040/api/Lecturer?Id=${encodeURIComponent(lecturerId)}`, {
      name, surname, gender, dateOfBirth, homeAddress, email, phoneNumber: phone
    })
      .then(() => { toast.success('Updated'); getLecturers(); handleClose(); clear(); })
      .catch(err => { console.error(err); toast.error('Failed to update'); });
  }

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
                  <button className="btn btn-sm btn-primary me-2" onClick={()=>handleEdit(item.id ?? item.Id ?? item.LecturerID)}>Edit</button>
                  <button className="btn btn-sm btn-danger" onClick={()=>handleDelete(item.id ?? item.Id ?? item.LecturerID)}>Delete</button>
                </td>
              </tr>
            ))}
          </tbody>
        </Table>

        <Modal show={show} onHide={handleClose} dialogClassName="wide-modal">
          <Modal.Header closeButton>
            <Modal.Title>Edit Lecturer</Modal.Title>
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

export default LecturerCRUD;
