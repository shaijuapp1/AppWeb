
import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';

import axios from 'axios';

function App() {
  const [toDos, setToDos] = useState([]);
  const [test, setTest] = useState("");


  useEffect(() => {
    axios.get( process.env.REACT_APP_API_URL + "/ToDos")
      .then(response => {
        setToDos(response.data);
      })

    axios.get( process.env.REACT_APP_API_URL + "/ToDos/TestReq")
      .then(response => {
        debugger;
        const toDo = response as any
        setTest(toDo.data.title );
      })

  }, [])

  return (
    <div className="App">
      
      <h3  style={{margin: '10px 50px', textAlign: 'left'}} >To Do - {test}</h3>
      <h3  style={{margin: '10px 50px', textAlign: 'left'}} >To Do List</h3>
      <table border={1} style={{margin: '10px 50px', textAlign: 'left'}} >
        <tr>          
            <th>SiNo.</th>
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
