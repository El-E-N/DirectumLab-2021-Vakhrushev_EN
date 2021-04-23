import * as React from 'react';
import Logo from './../logo/logo';
import User from './../user/user';
import './header.css';

interface IProps {
  addUser?: boolean;
}

const Header: React.FunctionComponent<IProps> = (props) => {
  return <header className="header">
    <div className="header__content">
      <Logo />
      {props.addUser && <User/>}
    </div>
  </header>;
};

export default Header;
