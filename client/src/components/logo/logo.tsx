import * as React from 'react';
import logo from './../../images/headerIcon.svg';
import './logo.css';

const Logo: React.FunctionComponent = () => {
  return <a href="/#" className="logo">
    <img className="logo__icon" alt="logo__icon" src={logo} />
    <h1 className="logo__name">PlanPoker</h1>
  </a>;
};

export default Logo;
