import * as React from 'react';
import Player from '../player/player';
import {IRoom, IPlayer, IVote} from '../../store/types';
import './players.css';

interface IProps {
  room: IRoom | null;
  user: IPlayer | null;
  showResult: boolean;
  // eslint-disable-next-line no-unused-vars
  getVote(user: IPlayer): IVote | null;
}

const Players: React.FunctionComponent<IProps> = (props) => {
  return <ul className="players">
    {props.room && props.room.players.map((player) => {
      return props.user && player.id !== props.user.id &&
        <Player
          key={player.name}
          player={player}
          showResult={props.showResult}
          vote={props.getVote(player)}
        />;
    })}
  </ul>;
};

export default Players;
