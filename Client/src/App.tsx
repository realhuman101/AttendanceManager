import { BrowserRouter, Routes, Route } from "react-router-dom";
import { useEffect, useState } from "react";

import * as API from './api/index'
import Navbar from './components/Navbar';
import Home from './pages/Home'
import Login from './pages/Login';

function App() {
  const [loggedIn, setLogIn] = useState(false);

  useEffect(() => {
    const response = API.Users.currUser();
    console.log(response);

    if (!loggedIn && location.href.split(location.host)[1] !== "/login")
      window.location.href = '/login';

    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  return (
    <>
      <Navbar navItems={['Home']} navRedirect={['/']}/>

      <BrowserRouter>
        <Routes>
          <Route index element={<Home/>}/>
          <Route path="/login" element={<Login onLogIn={() => {setLogIn(true)}}/>}/>
        </Routes>
      </BrowserRouter>
    </>
  )
}

export default App
