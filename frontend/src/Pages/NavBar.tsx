import React from 'react';
import { Link, Outlet } from 'react-router-dom';

const NavBar = () => {
    return (
        <div className='navBar'>
            <div className='home'>
                <Link to="/">Login</Link>
            </div>
            <div className='user'>
                <Link to="/user">User</Link>
            </div>
            <div className='chat'>
                <Link to="/chat">Chat</Link>
            </div>
            <Outlet />
        </div>
        
    )
}

export default NavBar;