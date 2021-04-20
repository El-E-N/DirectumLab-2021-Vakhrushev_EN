import * as React from 'react';
import './vote.css';

export interface IVote {
  count: number;
  percents: string;
  color: string;
}

const Vote: React.FunctionComponent<IVote> = (props) => {
  return <li className="vote">
    <div className="vote__info-wrapper">
      <div className={'vote__round ' + props.color}/>
      <span className="vote__count">{props.count}</span>
    </div>
    <span className="vote__percents">{props.percents}</span>
  </li>;
};

export default Vote;
