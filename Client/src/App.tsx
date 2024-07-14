import { BrowserRouter, Routes, Route } from "react-router-dom";
import { useEffect, useState } from "react";

import * as API from './api/index'
import Navbar from './components/Navbar';
import Home from './pages/Home'
import Login from './pages/Login';

function App() {
  const [loggedIn, setLogIn] = useState(false);

  useEffect(() => {
    async function logInCheck() {
      const logIn = await API.Auth.checkLogIn();

      if (logIn == null) {
        console.log("ERROR")
        return
      }

      setLogIn(logIn);

      if (!logIn && location.href.split(location.host)[1] !== "/login")
        window.location.href = '/login';

      else if (logIn && location.href.split(location.host)[1] === "/login")
        window.location.href = '/';
    }

    logInCheck();

    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  return (
    <>
      <Navbar navItems={['Home']} navRedirect={['/']} loggedIn={loggedIn}/>

      <BrowserRouter>
        <Routes>
          {loggedIn && <Route index element={<Home/>}/>}
          {!loggedIn && <Route path="/login" element={<Login onLogIn={() => {setLogIn(true)}}/>}/>}
        </Routes>
      </BrowserRouter>
    </>
  )
}

export default App
