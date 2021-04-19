import * as React from 'react';
import Logo from './../logo/logo';
import User from './../user/user';
import './header.css';

interface IProps {
  addUser?: boolean;
}

const Header: React.FunctionComponent<IProps> = (props) => {
  return (props.addUser || false) ?
    <header className="header">
      <div className="header__content">
        <Logo />
        <User/>
      </div>
    </header>
    :
    <header className="header">
      <div className="header__content">
        <Logo />
      </div>
    </header>;
};

export default Header;
