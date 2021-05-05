import * as React from 'react';
import {withRouter} from 'react-router-dom';
import './no-match-page.css';

const NoMatchPage: React.FunctionComponent = () => {
  return <main className="room no-match-page">Oops!!!</main>;
};

export default withRouter(NoMatchPage);
