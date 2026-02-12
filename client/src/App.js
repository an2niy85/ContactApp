import React, { useState } from 'react';
import TableContact from './layout/TableContact/TableContact';
import FormContact from './layout/FormContact/FormContact';

const App = () => {

  const [contacts, setContacts] = useState(
    [
    {id:1, name:'Имя Фамилия 1', email: 'q1@e.rt'},
    {id:2, name:'Имя Фамилия 2', email: 'q2@e.rt'},
    {id:3, name:'Имя Фамилия 3', email: 'q3@e.rt'},
    ]
  );

  const addContact = () => {
    const newId = Math.max(...contacts.map(e => e.id)) + 1;

    const item = {
      id: newId, 
      name:'Имя Фамилия 3', 
      email: 'q3@e.rt'
    };
    setContacts([...contacts, item]);    
  }

  return (
    <div className='container mt-5'>
      <div className='card'>
        <div className='card-header'>
          <h1>Список контактов</h1>
        </div>
        <div className='card-body'>
          <TableContact contacts={contacts} />
          <div>
            <FormContact addContact={addContact} />
            
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;
