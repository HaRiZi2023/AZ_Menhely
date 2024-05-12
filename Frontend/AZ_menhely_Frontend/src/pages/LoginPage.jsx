import { useContext, useEffect, useRef } from "react";
import { useNavigate } from "react-router-dom";
import { AuthContext } from "../context/AuthContext";
import styles from '../styles/FormStyles.module.css';

function LoginPage() {
  const emailRef = useRef(null);
  const passwordRef = useRef(null);
  const navigate = useNavigate();
  const authContext = useContext(AuthContext);
  const { login, authToken } = authContext;

  const handleFormSubmit = (event) => {
    event.preventDefault();
    const email = emailRef.current.value;
    const password = passwordRef.current.value;
    login(email, password);
  };

  useEffect(() => {
    if (authToken) {
      navigate("/user-profile")
    }
  }, [authToken, navigate]);

  return (
    <div className="container">
      <div className="row justify-content-center">
        <div className="col-lg-5 col-md-8 col-sm-12 mb-4">
          <h2 className="mt-4 text-center">Bejelentkezés</h2>
          <form onSubmit={handleFormSubmit} className="mt-4">
            <div className="mb-3">
              <label className="form-label" htmlFor="loginEmail">E-mail:</label>
              <input className="form-control" type="email" id="loginEmail" placeholder="E-mail" ref={emailRef} />
            </div>
            <div className="mb-3">
              <label className="form-label" htmlFor="loginPassword">Jelszó</label>
              <input className="form-control" type="password" id="loginPassword" placeholder="Jelszó" ref={passwordRef} />
            </div>
            <div className="mb-3 text-center">
              <button className="btn btn-primary" type="submit">Bejelentkezés</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
}

export default LoginPage;
