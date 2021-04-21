import * as React from 'react';
import {IVote} from '../vote/vote';
import AverageValues from '../average-values/average-values';
import VoteWrapper from '../vote__wrapper/vote__wrapper';
import './briefly-results.css';

const colors = {
  'yellow': '#f8e71d',
  'blue': '#225378',
  'black': '#000000',
  'red': 'rgba(255, 0, 0, 1)',
  'green': 'rgba(0, 255, 0, 1)',
};

const allVote: Array<IVote> = [
  {count: 3, percents: '50% (1 player)', color: colors.yellow},
  {count: 1, percents: '50% (1 player)', color: colors.blue},
  {count: 3, percents: '50% (1 player)', color: colors.black},
  {count: 1, percents: '50% (1 player)', color: colors.red},
  {count: 3, percents: '50% (1 player)', color: colors.green},
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
