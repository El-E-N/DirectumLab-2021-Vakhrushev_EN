import * as React from 'react';
import {Link} from 'react-router-dom';
import {RoutePath} from '../../routes';
import './footer.css';

interface IProps {
  onClick?(): void;
}

const Footer: React.FunctionComponent<IProps> = (props) => {
  return <footer className="footer">
    <p>
      {'Copyright 2021 '}
      <Link to={RoutePath.INDEX} className="footer__link" onClick={props.onClick}>PlanPoker</Link>
    </p>
  </footer>;
};

export default Footer;
