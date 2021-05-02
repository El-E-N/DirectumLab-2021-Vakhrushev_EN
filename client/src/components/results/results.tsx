import * as React from 'react';
import BrieflyResults from '../briefly-results/briefly-results';
import History from '../history/history';
import {mockState} from '../../mock/mock';
import './results.css';

interface IProps {
  onShowModal?(): void;
}

const Results: React.FunctionComponent<IProps> = (props) => {
  return <div className="results">
    <BrieflyResults/>
    <History stories={mockState.stories} onShowModal={props.onShowModal}/>
  </div>;
};

export default Results;
