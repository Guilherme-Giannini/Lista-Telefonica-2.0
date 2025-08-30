import React, { useEffect, useState } from "react";
import api from "../services/api";
import styles from './contactlist.module.css'; 

const ContactList = ({ onEdit, reload }) => {
  const [contatos, setContatos] = useState([]);

  const fetchContatos = () => {
    console.log("Carregando contatos...");
    api.get("/contatos")
      .then(response => {
        console.log("Contatos carregados:", response.data);
        setContatos(response.data);
      })
      .catch(error => console.error("Erro ao buscar contatos:", error));
  };

  useEffect(() => {
    fetchContatos();
  }, [reload]);

  const handleDelete = async (id) => {
    const confirmar = window.confirm("Tem certeza que deseja excluir este contato?");
    if (!confirmar) return;

    try {
      await api.delete(`/contatos/${id}`);
      fetchContatos(); 
    } catch (error) {
      console.error("Erro ao deletar contato:", error);
    }
  };

  return (
    <div>
      <h2 className={styles.contactListTitle}>Contatos:</h2>
      <ul className={styles.contactList}>
        {contatos.map(contato => (
          <li key={contato.id} className={styles.contactItem}>
            <p><strong>Nome:</strong> {contato.nome}</p>
            <p><strong>Telefone:</strong> {contato.telefone}</p>
            <p><strong>Email:</strong> {contato.email}</p>
            <p><strong>Data de Nascimento:</strong> {contato.dataNascimento 
              ? new Date(contato.dataNascimento).toLocaleDateString("pt-BR") 
              : "—"}
            </p>
            <p><strong>Endereços:</strong> {contato.enderecos && contato.enderecos.length > 0 
              ? contato.enderecos.join(", ") 
              : "—"}
            </p>
            <div className={styles.buttonGroup}>
              <button 
                className={styles.editButton} 
                onClick={() => onEdit(contato)}
              >
                Editar
              </button>
              <button 
                className={styles.deleteButton} 
                onClick={() => handleDelete(contato.id)}
              >
                Deletar
              </button>
            </div>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default ContactList;