import Navbar from "./Navbar";
import { Outlet } from "react-router-dom";
import { useContext } from "react";
import { AuthContext } from "../context/AuthContext";

function Layout() {
  const authContext = useContext(AuthContext);
  const { authToken, logout } = authContext;
  const navbarLeftSide = [];
  const navbarRightSide = [];
  const navbarRightSideOthers = [];

  navbarLeftSide.push({to: "/", text: "Rólunk"});
  if (authToken) {
    navbarLeftSide.push({to: "/AdoptionHomePet", text: "Találj új családtagot!"});
    navbarLeftSide.push({to: "/about", text: "Rólunk"});
    navbarRightSide.push({to: "/user-profile", text: "Saját profil"});
    navbarRightSideOthers.push(
      <button className="nav-link" onClick={() => logout()}>Kijelentkezés</button>
    );
  } else {
    navbarLeftSide.push({to: "/about", text: "Rólunk"});
    navbarRightSide.push({to: "/foundlook", text: "Találtam / Keresem"});
    navbarRightSide.push({to: "/canbeadopt", text: "Örökbefogadható"});
    navbarRightSide.push({to: "/contact", text: "Kapcsolat"})
    navbarRightSide.push({to: "/donative", text: "Adomány"});
    navbarRightSide.push({to: "/register", text: "Regisztráció"});
    navbarRightSide.push({to: "/login", text: "Bejelentkezés"});
  }
  
  return (
    <>
      <Navbar leftSide={navbarLeftSide} rightSide={navbarRightSide} rightSideOthers={navbarRightSideOthers}/>
      <main className="container mt-2">
        <Outlet />
      </main>
    </>
  );
}

export default Layout;
