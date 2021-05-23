import * as React from 'react';
import {IVote as IVoteView} from '../vote/vote';
import AverageValues from '../average-values/average-values';
import VoteWrapper from '../vote__wrapper/vote__wrapper';
import './briefly-results.css';
import { ICard, IRoom, IVote } from '../../store/types';

const getAllVote = (cards: Array<ICard>, voteArray: Array<IVote>) => {
  const allVote: Array<IVoteView> = [];
  for (let i = 0; i < cards.length; i++) {
    const filtredVoteArray = voteArray.filter((vote) => vote.card == cards[i]);
    if (filtredVoteArray.length !== 0) {
      const countPlayers = filtredVoteArray.length;
      const percents = countPlayers / voteArray.length * 100;
      allVote.push({
        count: cards[i].value,
        percents: `${percents}% (${countPlayers} player(-s))`,
        color: `rgba(${Math.random() * 255}, ${Math.random() * 255}, ${Math.random() * 255}, 1)`,
      });
    }
  }
  return allVote;
};

interface IProps {
  room: IRoom;
  voteArray: Array<IVote>;
}

const BrieflyResults: React.FunctionComponent<IProps> = (props) => {
  return <div className="briefly-results__wrapper">
    <div className="briefly-results">
      <AverageValues players={props.voteArray.length} avg={4}/>
      <VoteWrapper allVote={getAllVote(props.room.cards, props.voteArray)}/>
    </div>
  </div>;
};

export default BrieflyResults;
