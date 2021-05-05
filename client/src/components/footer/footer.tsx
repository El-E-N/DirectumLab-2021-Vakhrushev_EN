import * as React from 'react';
import {Link} from 'react-router-dom';
import {RoutePath} from '../../routes';
import './footer.css';

const Footer: React.FunctionComponent = () => {
  return <footer className="footer">
    <p>
      {'Copyright 2021 '}
      <Link to={RoutePath.INDEX} className="footer__link">PlanPoker</Link>
    </p>
  </footer>;
};

export default Footer;
