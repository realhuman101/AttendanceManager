import { BrowserRouter, Routes, Route } from "react-router-dom";

import Navbar from './assets/Navbar';
import Home from './pages/Home'
import Login from './pages/Login';

function App() {
  return (
    <>
      <Navbar navItems={['Item']} navRedirect={['/']}/>

      <BrowserRouter>
        <Routes>
          <Route index element={<Home/>}/>
          <Route path="/login" element={<Login/>}/>
        </Routes>
      </BrowserRouter>
    </>
  )
}

export default App
