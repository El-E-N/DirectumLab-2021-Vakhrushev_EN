import * as React from 'react';
import Player from '../player/player';
import {IRoom, IPlayer, IVote, IDiscussion} from '../../store/types';
import './players.css';
import { discussionByIdSelector } from '../../store/discussions/discussions-selectors';

interface IProps {
  room: IRoom;
  user: IPlayer;
  discussions: Array<IDiscussion>;
  showResult: boolean;
  getVote(discussionId: string, discussions: Array<IDiscussion>, user: IPlayer): IVote | null;
}

const Players: React.FunctionComponent<IProps> = (props) => {
  const discussion = props.room.currentDiscussionId && discussionByIdSelector(props.room.currentDiscussionId, props.discussions);
  const players = discussion && discussion.players;
  return <ul className="players">
    {players && players.map((player) => {
      return props.user && player.id !== props.user.id &&
        <Player
          key={player.name}
          player={player}
          showResult={props.showResult}
          room={props.room}
          discussions={props.discussions}
          getVote={props.getVote}
        />;
    })}
  </ul>;
};

export default Players;
