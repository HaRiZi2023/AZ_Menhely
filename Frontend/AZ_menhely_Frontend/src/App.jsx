import "./App.css";
import "bootstrap/dist/css/bootstrap.css";  /* npm install react - bootstrap@5 */
import "bootstrap/dist/js/bootstrap.bundle";  /*npm install react-bootstrap */
import LoginPage from "./pages/LoginPage";
import RegisterPage from "./pages/RegisterPage";
import UserProfilePage from "./pages/UserProfilePage";
import { RouterProvider, createBrowserRouter } from "react-router-dom";   /*npm install react-router-dom */
import Layout from "./components/Layout";
import HomePage from "./pages/HomePage";
import { AuthProvider } from "./context/AuthContext";
import AboutPage from "./pages/AboutPage";
import AdoptionHomePetPage from "./pages/AdoptionHomePetPage";
import DonativePage from "./pages/DonativePage";
import CanBeAdoptPage from "./pages/CanBeAdoptPage";
import ContactPage from "./pages/ContactPage";
import FoundLookPage from "./pages/FoundLookPage";
import LookForPage from "./pages/LookForPage";
import FoundPage from "./pages/FoundPage";


function App() {
  const router = createBrowserRouter([
    {
      path: "/",
      element: <Layout />,
      children: [
        {
          path: "/",
          element: <AboutPage />,
        },
        {
          path: "/user-profile",
          element: <UserProfilePage />,
        },
        {
          path: "/register",
          element: <RegisterPage />,
        },
        {
          path: "/login",
          element: <LoginPage />,
        },
        {
          path: "/AdoptionHomePet",
          element: <AdoptionHomePetPage />,
        },
        {
          path: "/donative",
          element: <DonativePage />,
        },
        {
          path: "/canbeadopt",
          element: <CanBeAdoptPage />,
        },
        {
          path: "/contact",
          element: <ContactPage />,
        },
        {
          path: "/foundlook",
          element: <FoundLookPage />,
        },
        {
          path: "/look-for",
          element: <LookForPage />,
        },
        {
          path: "/found",
          element: <FoundPage />,
        },


      ],
    },
  ]);

  return (
    <AuthProvider>
      <RouterProvider router={router} />
    </AuthProvider>
  );
}

export default App;
