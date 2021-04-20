import * as React from 'react';
import Vote, {IVote} from '../vote/vote';
import './vote__wrapper.css';

interface IProps {
  allVote: Array<IVote>;
}

const VoteWrapper: React.FunctionComponent<IProps> = (props) => {
  return <ul className="vote__wrapper">
    {props.allVote.map((vote) => {
      return <Vote key={vote.count} count={vote.count} percents={vote.percents} color={vote.color}/>;
    })}
  </ul>;
};

export default VoteWrapper;
