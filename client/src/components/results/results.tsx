import * as React from 'react';
import BrieflyResults from '../briefly-results/briefly-results';
import History from '../history/history';
import './results.css';

interface IProps {
  onShowModal?(): void;
}

const Results: React.FunctionComponent<IProps> = (props) => {
  return <div className="results">
    <BrieflyResults/>
    <History onShowModal={props.onShowModal}/>
  </div>;
};

export default Results;
