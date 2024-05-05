import { useContext, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { AuthContext } from "../context/AuthContext";

function UserProfilePage() {
  const navigate = useNavigate();
  const authContext = useContext(AuthContext);
  const {user, authToken, logoutEverywhere} = authContext;

  useEffect(() => {
    if (!authToken) {
      navigate("/login");
    }
  }, [authToken, navigate]);

  return user ? (
    <div>
      <h2>Profil</h2>
      <h5>Név: {user.name}</h5>
      <h5>Email: {user.email}</h5>
      <h5>Lakcím: {user.address}</h5>
      <h5>Telefonszám: {user.phone}</h5>
      <h5>Jelszó: {user.password}</h5>
      <div className="d-grid gap-2">
        <button className="btn btn-primary" type="button" onClick={() => logoutEverywhere()}>
          Kijelentkezés 
        </button>
      </div>
    </div>
  ) : (
    <div>
      <h2>Adatok betöltése folyamatban...</h2>
    </div>
  );
}

export default UserProfilePage;