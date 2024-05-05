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
    <div className="container">
      <div className="row justify-content-center">
        <div className="col-md-6">
          <header className="text-center">
            <h2>Profil</h2>
          </header>
          <main>
            <form onSubmit={handleUpdate}>
              <div className="mb-3">
                <label className="form-label" htmlFor="name">
                  Név:
                </label>
                <input
                  className="form-control"
                  type="text"
                  id="name"
                  defaultValue={user.name}
                  ref={nameRef}
                />
              </div>
              <div className="mb-3">
                <label className="form-label" htmlFor="address">
                  Lakcím:
                </label>
                <input
                  className="form-control"
                  type="text"
                  id="address"
                  defaultValue={user.address}
                  ref={addressRef}
                />
              </div>
              <div className="mb-3">
                <label className="form-label" htmlFor="phone">
                  Telefonszám:
                </label>
                <input
                  className="form-control"
                  type="text"
                  id="phone"
                  defaultValue={user.phone}
                  ref={phoneRef}
                />
              </div>
              <div className="mb-3">
                <label className="form-label" htmlFor="email">
                  Email:
                </label>
                <input
                  className="form-control"
                  type="text"
                  id="email"
                  defaultValue={user.email}
                  ref={emailRef}
                />
              </div>
              <div className="mb-3 text-center">
                <button className="btn btn-primary" type="submit">
                  Adatok módosítása
                </button>
              </div>
            </form>
            <form onSubmit={handleChangePassword}>
              <div className="mb-3">
                <label className="form-label" htmlFor="oldPassword">
                  Régi jelszó:
                </label>
                <input
                  className="form-control"
                  type="password"
                  id="oldPassword"
                  ref={oldPasswordRef}
                />
              </div>
              <div className="mb-3">
                <label className="form-label" htmlFor="newPassword">
                  Új jelszó:
                </label>
                <input
                  className="form-control"
                  type="password"
                  id="newPassword"
                  ref={newPasswordRef}
                />
              </div>
              <div className="mb-3 text-center">
                <button className="btn btn-primary" type="submit">
                  Jelszó módosítása
                </button>
              </div>
            </form>
          </main>
          <footer>
            <br />
            <div className="d-grid gap-2">
              <button className="btn btn-primary" type="button" onClick={() => logoutEverywhere()}>
                Kijelentkezés 
              </button>
            </div>
            <br />
            <br />
          </footer>
        </div>
      </div>
    </div>
  ) : (
    <div>
      <h2>Adatok betöltése folyamatban...</h2>
    </div>
  );
}

export default UserProfilePage;