import * as React from 'react';
import Logo from './../logo/logo';
import './header.css';

const Header: React.FunctionComponent = () => {
  return <header className="header">
    <div className="header__content">
      <Logo />
    </div>
  </header>;
};

export default Header;
