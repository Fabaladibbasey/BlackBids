import React from 'react'
import Search from './Search';
import Logo from './Logo';
import UserActions from './UserActions';
import LoginButton from './LoginButton';
import { getCurrentUser } from '../actions/authActions';

export default async function Navbar() {
  const user = await getCurrentUser();
  console.log(user);
  return (
    <header className='
  sticky top-0 z-50 flex flex-wrap justify-center lg:justify-between bg-white p-5 items-center text-gray-800 shadow-md
'>

      <div className='order-1'>
        <Logo />
      </div>

      <div className='order-3 w-full lg:order-2 lg:w-1/2'>
        <Search />
      </div>

      <div className='order-2 lg:order-3'>
        {user ? (
          <UserActions user={user} />
        ) : (
          <LoginButton />
        )}
      </div>
    </header>

  )
}