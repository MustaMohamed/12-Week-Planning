import React, { FC } from 'react';
import Navbar from './Navbar';

const Layout: FC = (props) => {
  return (
    <>
      <Navbar/>
      {props.children}
    </>
  );
};

export default Layout;