import React,{useState, useEffect, Fragment} from "react";
import Table from 'react-bootstrap/Table';
import 'bootstrap/dist/css/bootstrap.css';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import axios from "axios";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const StudentCRUD =() =>{

    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const [editStudentID, setEditStudentID] = useState('');
    const [editName, setEditName] = useState('');
    const [editSurname, setEditSurname] = useState('');
    const [editgender, setEditGender] = useState('');
    const [editdateOfBirth, setEditDateOfBirth] = useState('');
    const [edithomeAddress, setEditHomeAddress] = useState('');
    const [editEmail, setEditEmail] = useState('');
    const [editPhone, setEditPhone] = useState('');

    const studentData = [
        {
            StudentID:'7102171B-B33B-426E-88FE-08DDFB6A3615',
            Name:'Diarra',
            Surname:'Diongue',
            gender:'F',
            dateOfBirth:'2005-09-24',
            homeAddress:'VP',
            Email:'dee@gmail.com',
            Phone:'0896754532'
        }
    ]

const [data, setData] = useState([]);

useEffect(()=>{
getStudentData();
},[])

const getStudentData =() =>
{
  axios.get('https://localhost:7040/api/Student')
  .then((results) => 
    {setData(results.data)})
  .catch((error) => {
    console.log(error)})
  }


const handleSave = () =>
  {
    const url = 'https://localhost:7040/api/Student'
    const data = {
      "name": editName,
      "surname": editSurname,
      "gender": editgender,
      "dateOfBirth": editdateOfBirth,
      "homeAddress": edithomeAddress,
      "email": editEmail,
      "phoneNumber": editPhone
    }
    axios.post(url, data)
    .then((results)=>{
      getStudentData()
      clear();
      toast.success('Student Added Successfully!');
    })
    .catch((error)=>{
      toast.error(error);
    })
}

const clear=()=>{
  setEditStudentID('');
  setEditName('');
  setEditSurname('');
  setEditGender('');
  setEditDateOfBirth('');
  setEditHomeAddress('');
  setEditEmail('');
  setEditPhone('');
}

const handleEdit = (id)=>{
  handleShow();
  axios.get(`https://localhost:7040/api/Student/${id}`)
  .then((results) => 
      {
          setEditName(results.data.name);
          setEditSurname(results.data.surname);
          setEditGender(results.data.gender);
          setEditDateOfBirth(results.data.dateOfBirth);
          setEditHomeAddress(results.data.homeAddress);
          setEditEmail(results.data.email);
          setEditPhone(results.data.phoneNumber);
          setEditStudentID(results.data.id ?? results.data.Id ?? results.data.studentID);
      })
      .catch((error) => 
        {
      console.log(error)
    })
}

const handleDelete = (id) =>
  {
    if(window.confirm("Are you sure you want to delete this student?") === true)
        {
          axios.delete(`https://localhost:7040/api/Student/${id}`)
          .then((result)=>{
            if(result.status === 200 || result.status === 204)
            {
              toast.success("Student Deleted Successfully!");
              getStudentData();
            }
          })
          .catch((error)=>{
            toast.error(error);
          })
        }

  }



const handleUpdate = (StudentID) => {
    const url = `https://localhost:7040/api/Student?Id=${encodeURIComponent(editStudentID)}`
    const data = {
      "name": editName,
      "surname": editSurname,
      "gender": editgender,
      "dateOfBirth": editdateOfBirth,
      "homeAddress": edithomeAddress,
      "email": editEmail,
      "phoneNumber": editPhone
    }
    
    axios.put(url, data)
    .then((results)=>{
      getStudentData()
      clear();
      handleClose();
      toast.success('Student Updated Successfully!');
    })
    .catch((error)=>{
      toast.error(error);
    })
  }

    return(
        <Fragment>
            <ToastContainer /> 
            <br/><br/>
            <Container>
      
      <Row>
        <Col>
        <input type="text" placeholder="Enter Name" className="form-control" 
        value={editName} onChange={(e)=>setEditName(e.target.value)}/>
        </Col>
        <Col>
        <input type="text" placeholder="Enter Surname" className="form-control" 
        
        value={editSurname}  onChange={(e)=>setEditSurname(e.target.value)}/>
        </Col>
        <Col>
        <input type="text" placeholder="Enter Gender" className="form-control" 
        value={editgender} onChange={(e)=>setEditGender(e.target.value)}/>
        </Col>
        <Col>
        <input type="date" placeholder="Enter dateOfBirth" className="form-control" 
        value={editdateOfBirth} onChange={(e)=>setEditDateOfBirth(e.target.value)}/>
        </Col>
        <Col>
        <input type="text" placeholder="Enter homeAddress" className="form-control" 
        value={edithomeAddress} onChange={(e)=>setEditHomeAddress(e.target.value)}/>
        </Col>
        <Col>
        <input type="email" placeholder="Enter Email" className="form-control" 
        value={editEmail} onChange={(e) => setEditEmail(e.target.value)}/>
        </Col>
        <Col>
        <input type="text" placeholder="Enter Phone" className="form-control" 
        value={editPhone} onChange={(e) => setEditPhone(e.target.value)}/>
        </Col>
        <Col>
        <button className="btn btn-primary" onClick={()=>handleSave()}>Submit</button>
        </Col>
      </Row>
    </Container>
    <br/><br/>

            <Table striped bordered hover>
      <thead>
            <tr>
              <th>#</th>
            <th>Name</th>
            <th>Surname</th>
            <th>gender</th>
            <th>dateOfBirth</th>
            <th>homeAddress</th>
            <th>Email</th>
            <th>Phone</th>
            <td>Actions</td>
        </tr>
      </thead>
        {
            data && data.length > 0?
            data.map((items, index)=>{
                return(<tr key = {index}>
           {/* <td>{index +1}</td> */}
            <td>{index +1}</td>
            <td>{items.name}</td>
            <td>{items.surname}</td>
            <td>{items.gender}</td>
            <td>{items.dateOfBirth}</td>
            <td>{items.homeAddress}</td>
            <td>{items.email}</td>
            <td>{items.phoneNumber}</td>
            <td colSpan={2}>
                <button className="btn btn-primary" onClick={()=>handleEdit(items.id ?? items.Id ?? items.StudentID)}>Edit</button> &nbsp;
                <button className="btn btn-danger" onClick={()=>handleDelete(items.id ?? items.Id ?? items.StudentID)}>Delete</button>
            </td>
        </tr>)
            })
            :
            'Loading...'
}
      <tbody>
        
      </tbody>
    </Table>   
  <Modal show={show} onHide={handleClose} dialogClassName="wide-modal">
        <Modal.Header closeButton>
          <Modal.Title>Edit Student Details</Modal.Title>
        </Modal.Header>
        <Modal.Body>
            <Row>
                <Col>
                <input type="text" placeholder="Enter Name" className="form-control" value={editName} onChange={(e)=>setEditName(e.target.value)}/>
                </Col>
                <Col>
                <input type="text" placeholder="Enter Surname" className="form-control" value={editSurname}  onChange={(e)=>setEditSurname(e.target.value)}/>
                </Col>
                <Col>
                <input type="text" placeholder="Enter Gender" className="form-control" value={editgender} onChange={(e)=>setEditGender(e.target.value)}/>
                </Col>
                <Col>
                <input type="date" placeholder="Enter dateOfBirth" className="form-control" value={editdateOfBirth} onChange={(e)=>setEditDateOfBirth(e.target.value)}/>
                </Col>
                <Col>
                <input type="text" placeholder="Enter homeAddress" className="form-control" value={edithomeAddress} onChange={(e)=>setEditHomeAddress(e.target.value)}/>
                </Col>
                <Col>
                <input type="email" placeholder="Enter Email" className="form-control" value={editEmail} onChange={(e) => setEditEmail(e.target.value)}/>
                </Col>
                <Col>
                <input type="text" placeholder="Enter Phone" className="form-control" value={editPhone} onChange={(e) => setEditPhone(e.target.value)}/>
                </Col>
                
            </Row>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Close
          </Button>
          <Button variant="primary" onClick={handleUpdate}>
            Save Changes
          </Button>
        </Modal.Footer>
      </Modal>
        </Fragment>)
}

export default StudentCRUD;
