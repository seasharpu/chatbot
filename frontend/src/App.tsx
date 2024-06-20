import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import Login from './Components/Login'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import NavBar from './Pages/NavBar'
import User from './Pages/User'
import Chat from './Pages/Chat'

function App() {


  return (
    <BrowserRouter>
    <Routes>
      <Route path="/" element={<NavBar />}>
        <Route index element={<Login />} />
        <Route path="/user" element={<User />} />
        <Route path="/chat" element={<Chat />} />
       {/* <Route path="*" element={<Fourohfour />} /> */}
      </Route>
    </Routes>
  </BrowserRouter>
  )
}

export default App
