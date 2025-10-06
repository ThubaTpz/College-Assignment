import React from 'react';
import { BrowserRouter, Routes, Route, NavLink, useLocation } from 'react-router-dom';
import './App.css';
import StudentCRUD from './StudentCRUD';
import LecturerCRUD from './LecturerCRUD';
import CourseCRUD from './CourseCRUD';
import ModuleCRUD from './ModuleCRUD';
import TaskItemCRUD from './TaskItemCRUD';
import AdminCRUD from './AdminCRUD';

function Page(){
  const location = useLocation();
  const map = {
    '/': 'Students',
    '/students': 'Students',
    '/lecturers': 'Lecturers',
    '/courses': 'Courses',
    '/modules': 'Modules',
    '/tasks': 'Tasks',
    '/admins': 'Admins'
  };
  const title = map[location.pathname] || 'Dashboard';
  return (
    <div className="App container py-3">
      <nav className="mb-3">
        <NavLink className={({isActive}) => `nav-link me-3 ${isActive? 'active' : ''}`} to="/students">Students</NavLink>
        <NavLink className={({isActive}) => `nav-link me-3 ${isActive? 'active' : ''}`} to="/lecturers">Lecturers</NavLink>
        <NavLink className={({isActive}) => `nav-link me-3 ${isActive? 'active' : ''}`} to="/courses">Courses</NavLink>
        <NavLink className={({isActive}) => `nav-link me-3 ${isActive? 'active' : ''}`} to="/modules">Modules</NavLink>
        <NavLink className={({isActive}) => `nav-link me-3 ${isActive? 'active' : ''}`} to="/tasks">Tasks</NavLink>
        <NavLink className={({isActive}) => `nav-link me-3 ${isActive? 'active' : ''}`} to="/admins">Admins</NavLink>
      </nav>
      <h4 className="mb-3">{title}</h4>
      <Routes>
        <Route path="/" element={<StudentCRUD/>} />
        <Route path="/students" element={<StudentCRUD/>} />
        <Route path="/lecturers" element={<LecturerCRUD/>} />
        <Route path="/courses" element={<CourseCRUD/>} />
        <Route path="/modules" element={<ModuleCRUD/>} />
        <Route path="/tasks" element={<TaskItemCRUD/>} />
        <Route path="/admins" element={<AdminCRUD/>} />
      </Routes>
    </div>
  )
}

function App(){
  return (
    <BrowserRouter>
      <Page />
    </BrowserRouter>
  );
}

export default App;
