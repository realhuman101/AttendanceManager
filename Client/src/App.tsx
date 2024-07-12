import { BrowserRouter, Routes, Route } from "react-router-dom";
import './App.css'

import Home from './pages/Home'
import Navbar from './assets/Navbar';

function App() {
  return (
    <>
      <Navbar navItems={['Item']}/>

      <BrowserRouter>
        <Routes>
          <Route index element={<Home/>}/>
        </Routes>
      </BrowserRouter>
    </>
  )
}

export default App
