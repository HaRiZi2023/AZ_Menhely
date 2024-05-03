import { useContext, useEffect, useRef } from "react";
import { useNavigate } from "react-router-dom";
import { AuthContext } from "../context/AuthContext";


function RegisterPage() {
  const emailRef = useRef(null);
  const passwordRef = useRef(null);
  const nameRef = useRef(null);
  const addressRef = useRef(null);
  const phoneRef = useRef(null);

  const navigate = useNavigate();
  const authContext = useContext(AuthContext);
  const { register, authToken } = authContext;



  useEffect(() => {
    if (authToken) {
      navigate("/");
    }
  }, [authToken, navigate]);

  const handleFormSubmit = async (event) => {
    event.preventDefault();
    const email = emailRef.current.value;
    const password = passwordRef.current.value;
    const name = nameRef.current.value;
    const address = addressRef.current.value;
    const phone = phoneRef.current.value;

    // Ellenőrizzük, hogy minden mező ki van-e töltve
    if (!email || !password || !name || !address || !phone) {
      alert("Minden mező kitöltése kötelező!");
      return;
    }

    // Ellenőrizzük, hogy a telefon szám csak számokat tartalmaz-e
    if (!/^\d+$/.test(phone)) {
      alert("A telefon szám csak számokat tartalmazhat!");
      return;
    }

    // Ellenőrizzük, hogy a jelszó legalább 8 karakter hosszú-e, tartalmaz-e kis- és nagybetűt, valamint speciális karaktert
    if (!/(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*\W).{8,}/.test(password)) {
      alert("A jelszónak legalább 8 karakter hosszúnak kell lennie, tartalmaznia kell kis- és nagybetűt, valamint speciális karaktert!");
      return;
    }


    const role = "user";
    if (await register(email, password, name, address, phone, role)) {
      navigate("/login");
    }
  };

  return (
    <form onSubmit={handleFormSubmit}>
      <h2>Regisztráció</h2>
      <div className="mb-3">
        <label className="form-label" htmlFor="email">
          E-mail:
        </label>
        <input
          className="form-control"
          type="email"
          id="email"
          placeholder="E-mail"
          ref={emailRef}
        />
      </div>
      <div className="mb-3">
        <label className="form-label" htmlFor="password">
          Jelszó
        </label>
        <input
          className="form-control"
          type="password"
          id="password"
          placeholder="Jelszó"
          ref={passwordRef}
        />
      </div>
      <div className="mb-3">
        <label className="form-label" htmlFor="name">
          Név
        </label>
        <input
          className="form-control"
          type="text"
          id="name"
          placeholder="Név"
          ref={nameRef}
        />
      </div>
      {/* Új mezők hozzáadása */}
      <div className="mb-3">
        <label className="form-label" htmlFor="address">
          Cím:
        </label>
        <input
          className="form-control"
          type="text"
          id="address"
          placeholder="Cím"
          ref={addressRef}
        />
      </div>
      <div className="mb-3">
        <label className="form-label" htmlFor="phone">
          Telefon:
        </label>
        <input
          className="form-control"
          type="tel"
          id="phone"
          placeholder="Telefon"
          ref={phoneRef}
        />
      </div>

      {/* Új mezők hozzáadása vége */}
      <button className="btn btn-primary" type="submit">Regisztráció</button>
    </form>
  );
}

export default RegisterPage;