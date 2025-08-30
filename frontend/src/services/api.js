import axios from "axios";

const api = axios.create({
  baseURL: "http://localhost:5211/", 
});

export default api;