import * as React from 'react';
import Logo from './../logo/logo';
import User from './../user/user';
import './header.css';

interface IProps {
  userVisibility?: boolean;
}

const Header: React.FunctionComponent<IProps> = (props) => {
  return <header className="header">
    <div className="header__content">
      <Logo/>
      {props.userVisibility && <User/>}
    </div>
  </header>;
};

export default Header;
