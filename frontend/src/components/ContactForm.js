import React, { useState, useEffect } from "react";
import api from "../services/api";
import styles from './contactform.module.css';

const ContactForm = ({ contatoEditando, onSave }) => {
  const [id, setId] = useState(""); // <-- ID do contato
  const [nome, setNome] = useState("");
  const [telefone, setTelefone] = useState("");
  const [email, setEmail] = useState("");
  const [dataNascimento, setDataNascimento] = useState("");
  const [enderecos, setEnderecos] = useState([""]);

  useEffect(() => {
    if (contatoEditando) {
      setId(contatoEditando.id || contatoEditando.Id || ""); // <-- garante que pega o ID certo
      setNome(contatoEditando.nome || "");
      setTelefone(contatoEditando.telefone || "");
      setEmail(contatoEditando.email || "");
      setDataNascimento(
        contatoEditando.dataNascimento
          ? contatoEditando.dataNascimento.split("T")[0]
          : ""
      );
      setEnderecos(
        contatoEditando.enderecos?.length > 0
          ? contatoEditando.enderecos
          : [""]
      );
    }
  }, [contatoEditando]);

  const handleEnderecoChange = (index, value) => {
    const novosEnderecos = [...enderecos];
    novosEnderecos[index] = value;
    setEnderecos(novosEnderecos);
  };

  const addEndereco = () => {
    setEnderecos([...enderecos, ""]);
  };

  const removeEndereco = (index) => {
    const novosEnderecos = enderecos.filter((_, i) => i !== index);
    setEnderecos(novosEnderecos.length > 0 ? novosEnderecos : [""]);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const contato = {
        id, 
        nome,
        telefone,
        email,
        dataNascimento: dataNascimento
          ? new Date(dataNascimento).toISOString()
          : null,
        enderecos: enderecos.filter((e) => e.trim() !== ""),
      };

      if (contatoEditando) {
        await api.put(`/contatos/${id}`, contato);
      } else {
        await api.post("/contatos", contato);
      }

      onSave();
      setId("");
      setNome("");
      setTelefone("");
      setEmail("");
      setDataNascimento("");
      setEnderecos([""]);
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
        onChange={(e) => setNome(e.target.value)}
        required
        className={styles.inputField}
      />
      <input
        type="text"
        placeholder="Telefone"
        value={telefone}
        onChange={(e) => setTelefone(e.target.value)}
        required
        className={styles.inputField}
      />
      <input
        type="email"
        placeholder="Email"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
        required
        className={styles.inputField}
      />
      <input
        type="date"
        value={dataNascimento}
        onChange={(e) => setDataNascimento(e.target.value)}
        className={styles.inputField}
      />

      <label>
        <strong>Endereços:</strong>
      </label>
      {enderecos.map((endereco, index) => (
        <div key={index} className={styles.enderecoRow}>
          <input
            type="text"
            placeholder={`Endereço ${index + 1}`}
            value={endereco}
            onChange={(e) => handleEnderecoChange(index, e.target.value)}
            className={styles.inputField}
          />
          <button
            type="button"
            onClick={() => removeEndereco(index)}
            className={styles.deleteButton}
          >
            Remover
          </button>
        </div>
      ))}
      <button
        type="button"
        onClick={addEndereco}
        className={styles.addButton}
      >
        + Adicionar Endereço
      </button>

      <button type="submit" className={styles.submitButton}>
        {contatoEditando ? "Atualizar" : "Adicionar"}
      </button>
    </form>
  );
};

export default ContactForm;