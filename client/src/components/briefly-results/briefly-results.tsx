import * as React from 'react';
import {IVote as IVoteView} from '../vote/vote';
import AverageValues from '../average-values/average-values';
import VoteWrapper from '../vote__wrapper/vote__wrapper';
import './briefly-results.css';
import { ICard, IDiscussion, IRoom, IVote } from '../../store/types';
import { discussionByIdSelector } from '../../store/discussions/discussions-selectors';

const getAllVote = (cards: Array<ICard>,  voteArray: {[key: string]: IVote | null}) => {
  const allVote: Array<IVoteView> = [];
  const tempVoteArray: Array<IVote> = [];
  for (const key in voteArray) {
    const vote = voteArray[key];
    vote && tempVoteArray.push(vote);
  }
  for (let i = 0; i < cards.length; i++) {
    const filtredVoteArray = tempVoteArray.filter((vote) => vote.card && vote.card.value === cards[i].value);
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

interface IProps {
  room: IRoom;
  voteArray: {[key: string]: IVote | null} | null;
  discussions: Array<IDiscussion>;
}

const BrieflyResults: React.FunctionComponent<IProps> = (props) => {
  const voteList = props.voteArray && getAllVote(props.room.cards, props.voteArray);
  const discussion = props.room.currentDiscussionId !== null ? 
    discussionByIdSelector(props.room.currentDiscussionId, props.discussions) :
    null;
  const avg = discussion !== null ? discussion.average : 0;
  return <div className="briefly-results__wrapper">
    <div className="briefly-results">
      {props.voteArray && <AverageValues players={Object.keys(props.voteArray).length} avg={avg}/>}
      {voteList && <VoteWrapper allVote={voteList}/>}
    </div>
  </div>;
};

export default BrieflyResults;
