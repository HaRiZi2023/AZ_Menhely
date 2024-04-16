import './App.css'
import LoginForm from './components/LoginForm';

import RegisterForm from './components/RegisterForm';
import UserProfile from './components/UserProfile';

function App() {
  const loggedIn = false;
  return ( <main>
    {loggedIn ?
      <UserProfile />
      :
      <>
        < RegisterForm />
        < LoginForm />
      </>
    }

  </main> );
}

export default App;
