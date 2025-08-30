import React, { useState, useEffect } from "react";
import api from "../services/api";
import styles from './contactform.module.css';

const ContactForm = ({ contatoEditando, onSave }) => {
  const [nome, setNome] = useState("");
  const [telefone, setTelefone] = useState("");
  const [email, setEmail] = useState("");
  const [dataNascimento, setDataNascimento] = useState("");
  const [enderecos, setEnderecos] = useState("");

  useEffect(() => {
    if (contatoEditando) {
      setNome(contatoEditando.nome || "");
      setTelefone(contatoEditando.telefone || "");
      setEmail(contatoEditando.email || "");
      setDataNascimento(contatoEditando.dataNascimento 
        ? contatoEditando.dataNascimento.split("T")[0] 
        : ""
      );
      setEnderecos(contatoEditando.enderecos ? contatoEditando.enderecos.join(", ") : "");
    }
  }, [contatoEditando]);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const contato = {
        nome,
        telefone,
        email,
        dataNascimento: dataNascimento ? new Date(dataNascimento).toISOString() : null,
        enderecos: enderecos ? enderecos.split(",").map(e => e.trim()) : []
      };

      if (contatoEditando) {
        await api.put(`/contatos/${contatoEditando.id}`, contato);
      } else {
        await api.post("/contatos", contato);
      }

      onSave();
      setNome("");
      setTelefone("");
      setEmail("");
      setDataNascimento("");
      setEnderecos("");
    } catch (error) {
      console.error("Erro ao salvar contato:", error);
    }
  };

  return (
    <form onSubmit={handleSubmit} className={styles.formContainer}>
      <input 
        type="text" 
        placeholder="Nome" 
        value={nome} 
        onChange={e => setNome(e.target.value)} 
        required 
        className={styles.inputField}
      />
      <input 
        type="text" 
        placeholder="Telefone" 
        value={telefone} 
        onChange={e => setTelefone(e.target.value)} 
        required 
        className={styles.inputField}
      />
      <input 
        type="email" 
        placeholder="Email" 
        value={email} 
        onChange={e => setEmail(e.target.value)} 
        required 
        className={styles.inputField}
      />
      <input 
        type="date" 
        value={dataNascimento} 
        onChange={e => setDataNascimento(e.target.value)} 
        className={styles.inputField}
      />
      <input 
        type="text" 
        placeholder="Endereços (separar por vírgula)" 
        value={enderecos} 
        onChange={e => setEnderecos(e.target.value)} 
        className={styles.inputField}
      />
      <button type="submit" className={styles.submitButton}>
        {contatoEditando ? "Atualizar" : "Adicionar"}
      </button>
    </form>
  );
};

export default ContactForm;