import * as React from 'react';
import Logo from './../logo/logo';
import User from './../user/user';
import './header.css';

interface IProps {
  name?: string;
}

const Header: React.FunctionComponent<IProps> = (props) => {
  return <header className="header">
    <div className="header__content">
      <Logo/>
      {props.name && <User name={props.name}/>}
    </div>
  </header>;
};

export default Header;
