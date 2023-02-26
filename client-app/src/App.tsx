
import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';

import axios from 'axios';

function App() {
  const [toDos, setToDos] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:5000/api/ToDos')
      .then(response => {
        setToDos(response.data);
      })
  }, [])


  return (
    <div className="App">
      <h3  style={{margin: '10px 50px', textAlign: 'left'}} >To Do</h3>
      <table border={1} style={{margin: '10px 50px', textAlign: 'left'}} >
        <tr>          
            <th>Si. no</th>
            <th>Title</th>          
        </tr>
        {toDos.map((todo: any) => (
            <tr key={todo.id}>
              <td style={{width: '40px',paddingLeft:'10px' }}>{todo.id}</td>
              <td style={{width: '250px',paddingLeft:'10px' }} >{todo.title}</td>
            </tr>
          ))}
      </table>    
    </div>
  );
}

export default App;