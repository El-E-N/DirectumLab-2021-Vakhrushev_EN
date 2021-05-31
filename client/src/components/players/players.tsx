import * as React from 'react';
import Player from '../player/player';
import {IRoom, IPlayer, IVote, IDiscussion} from '../../store/types';
import './players.css';

interface IProps {
  room: IRoom;
  user: IPlayer;
  discussions: Array<IDiscussion>;
  showResult: boolean;
  getVote(discussionId: string, discussions: Array<IDiscussion>, user: IPlayer): IVote | null;
}

const Players: React.FunctionComponent<IProps> = (props) => {
  return <ul className="players">
    {props.room && props.room.players.map((player) => {
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
