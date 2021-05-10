import * as React from 'react';
import Player from '../player/player';
import {IRoom, IPlayer} from '../../store/types';
import './players.css';

interface IProps {
  room: IRoom | null;
  user: IPlayer | null;
  showResult: boolean;
}

const Players: React.FunctionComponent<IProps> = (props) => {
  return <ul className="players">
    {props.room && props.room.players.map((player) => {
      return props.user && player.id !== props.user.id &&
        <Player
          key={player.name}
          player={player}
          showResult={props.showResult}
        />;
    })}
  </ul>;
};

export default Players;
