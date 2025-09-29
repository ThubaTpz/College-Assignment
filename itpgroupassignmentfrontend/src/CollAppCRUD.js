import React,{useState, useEffect, Fragment} from "react";
import Table from 'react-bootstrap/Table';
import 'bootstrap/dist/css/bootstrap.css';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

const CollAppCRUD =() =>{

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
        },{
            StudentID:'7102171B-B33B-426E-88FE-08DDFB6A3615',
            Name:'Diarra',
            Surname:'Diongue',
            gender:'F',
            dateOfBirth:'2005-09-24',
            homeAddress:'VP',
            Email:'dee@gmail.com',
            Phone:'0896754532'
        },{
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
    setData(studentData);
},[])

const handleEdit = (StudentID)=>{
//alert(StudentID);
handleShow();

}

const handleDelete = (StudentID)=>{
    if(window.confirm("Are you sure you want to delete this student?"))
        {
    //alert(StudentID);

handleShow();

    }

}

const handleUpdate = (StudentID) => {
    
  }

    return(
        <Fragment>
            <br/><br/>
            <Container>
      
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
        <Col>
        <button className="btn btn-primary">Submit</button>
        </Col>
      </Row>
    </Container>
    <br/><br/>

            <Table striped bordered hover>
      <thead>
            <tr>
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
            <td>{items.Name}</td>
            <td>{items.Surname}</td>
            <td>{items.gender}</td>
            <td>{items.dateOfBirth}</td>
            <td>{items.homeAddress}</td>
            <td>{items.Email}</td>
            <td>{items.Phone}</td>
            <td colSpan={2}>
                 <button className="btn btn-primary" onClick={()=>handleEdit(items.StudentID)}>Edit</button> &nbsp;
                 <button className="btn btn-danger" onClick={()=>handleDelete(items.StudentID)}>Delete</button>
            </td>
        </tr>)
            })
            :
            'Loading...'
}
      <tbody>
        
      </tbody>
    </Table>
    <Modal show={show} onHide={handleClose}>
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

export default CollAppCRUD;  
