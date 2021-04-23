import * as React from 'react';
import './footer.css';

const Footer: React.FunctionComponent = () => {
  return <footer className="footer">
    <p>
      {'Copyright 2021 '}
      <a href="/#" className="footer__link">PlanPoker</a>
    </p>
  </footer>;
};

export default Footer;
