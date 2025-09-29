import React,{useState, useEffect, Fragment} from "react";
import Table from 'react-bootstrap/Table';
import 'bootstrap/dist/css/bootstrap.css';

const CollAppCRUD =() =>{

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
},[

])

    return(
        <Fragment>
            <Table striped bordered hover>
      <thead>
        <tr>
          <th>StudentID</th>
          <th>Name</th>
          <th>Surname</th>
          <th>gender</th>
          <th>dateOfBirth</th>
          <th>homeAddress</th>
          <th>Email</th>
          <th>Phone</th>
        </tr>
      </thead>
        {
            data && data.length > 0?
            data.map((items, index)=>{
                return(<tr key = {index}>
           <td>{items.StudentID}</td>
           {/* <td>{index +1}</td> */}
            <td>{items.Name}</td>
            <td>{items.Surname}</td>
            <td>{items.gender}</td>
            <td>{items.dateOfBirth}</td>
            <td>{items.homeAddress}</td>
            <td>{items.Email}</td>
            <td>{items.Phone}</td>
        </tr>)
            })
            :
            'Loading...'
}
      <tbody>
        
      </tbody>
    </Table>
        </Fragment>)
}

export default CollAppCRUD;  