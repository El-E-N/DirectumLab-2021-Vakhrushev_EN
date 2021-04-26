import * as React from 'react';
import {Link} from 'react-router-dom';
import logo from './../../images/headerIcon.svg';
import {RoutePath} from '../../routes';
import './logo.css';

interface IProps {
  onClick?(): void;
}

const Logo: React.FunctionComponent<IProps> = (props) => {
  return <Link to={RoutePath.INDEX} onClick={props.onClick} className="logo">
    <img className="logo__icon" alt="logo__icon" src={logo} />
    <h1 className="logo__name">PlanPoker</h1>
  </Link>;
};

export default Logo;
