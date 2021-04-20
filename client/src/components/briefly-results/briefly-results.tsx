import * as React from 'react';
import {IVote} from '../vote/vote';
import AverageValues from '../average-values/average-values';
import VoteWrapper from '../vote__wrapper/vote__wrapper';
import './briefly-results.css';

const allVote: Array<IVote> = [
  {count: 3, percents: '50% (1 player)', color: 'yellow'},
  {count: 1, percents: '50% (1 player)', color: 'blue'},
  {count: 3, percents: '50% (1 player)', color: 'yellow'},
  {count: 1, percents: '50% (1 player)', color: 'blue'},
  {count: 3, percents: '50% (1 player)', color: 'yellow'},
  {count: 1, percents: '50% (1 player)', color: 'blue'},
  {count: 3, percents: '50% (1 player)', color: 'yellow'},
];

const BrieflyResults: React.FunctionComponent = () => {
  return <div className="briefly-results__wrapper">
    <div className="briefly-results">
      <AverageValues players={5} avg={4}/>
      <VoteWrapper allVote={allVote}/>
    </div>
  </div>;
};

export default BrieflyResults;
