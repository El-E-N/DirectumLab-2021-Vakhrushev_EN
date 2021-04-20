import * as React from 'react';
import BrieflyResults from '../briefly-results/briefly-results';
import History from '../history/history';
import './results.css';

const Results: React.FunctionComponent = () => {
  return <div className="results">
    <BrieflyResults/>
    <History count={5}/>
  </div>;
};

export default Results;
