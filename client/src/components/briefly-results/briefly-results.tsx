import * as React from 'react';
import {IVote as IVoteView} from '../vote/vote';
import AverageValues from '../average-values/average-values';
import VoteWrapper from '../vote__wrapper/vote__wrapper';
import './briefly-results.css';
import { ICard, IRoom, IVote } from '../../store/types';

const getAllVote = (cards: Array<ICard>,  voteArray: {[key: string]: IVote | null}) => {
  const allVote: Array<IVoteView> = [];
  const tempVoteArray: Array<IVote> = [];
  for (const key in voteArray) {
    const vote = voteArray[key];
    vote && tempVoteArray.push(vote);
  }
  for (let i = 0; i < cards.length; i++) {
    const filtredVoteArray = tempVoteArray.filter((vote) => vote.card!.value === cards[i].value);
    if (filtredVoteArray.length !== 0) {
      const countPlayers = filtredVoteArray.length;
      const percents = countPlayers / tempVoteArray.length * 100;
      allVote.push({
        count: cards[i].value,
        percents: `${percents}% (${countPlayers} player(-s))`,
        color: `rgba(${Math.random() * 255}, ${Math.random() * 255}, ${Math.random() * 255}, 1)`,
      });
    }
  }
  return allVote;
};

const getAvg = (voteList: {[key: string]: IVote | null}) => {
  let count = 0;
  let sum = 0;
  const cardValues = ['0', '0.5', '1', '2', '3', '5', '8', '13', '20','40', '100']
  for (const i in voteList) {
    const vote = voteList[i];
    if (vote && vote.card && cardValues.indexOf(String(vote.card.value)) !== -1) {
      sum += parseFloat(vote.card.value);
      count++;
    }
  }
  return Math.round(sum / count * 100) / 100;
};

interface IProps {
  room: IRoom;
  voteArray: {[key: string]: IVote | null} | null;
}

const BrieflyResults: React.FunctionComponent<IProps> = (props) => {
  const voteList = props.voteArray && getAllVote(props.room.cards, props.voteArray);
  return <div className="briefly-results__wrapper">
    <div className="briefly-results">
      {props.voteArray && <AverageValues players={Object.keys(props.voteArray).length} avg={getAvg(props.voteArray)}/>}
      {voteList && <VoteWrapper allVote={voteList}/>}
    </div>
  </div>;
};

export default BrieflyResults;
