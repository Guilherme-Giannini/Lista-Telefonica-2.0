import React, { useState } from "react";
import ContactList from "../components/ContactList";
import ContactForm from "../components/ContactForm";
import styles from './home.module.css';


import logo from '../assets/Logo.png'; 

const Home = () => {
  const [contatoEditando, setContatoEditando] = useState(null);
  const [reload, setReload] = useState(false);

  const handleSave = () => {
    setReload(prev => !prev); 
    setContatoEditando(null);
  };

  return (
    <div className={styles.container}>
      <header className={styles.header}>
        <img src={logo} alt="Logo Smart Consig" className={styles.logo} />
        <h1 className={styles.title}>Lista Telefônica</h1>
      </header>
      <div className={styles.content}>
        <ContactForm contatoEditando={contatoEditando} onSave={handleSave} />
        <ContactList onEdit={setContatoEditando} reload={reload} />
      </div>
    </div>
  );
};

export default Home;