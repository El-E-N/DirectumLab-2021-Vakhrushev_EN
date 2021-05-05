import * as React from 'react';
import Player from '../player/player';
import {IRoom, IUser} from '../../store/types';
import './players.css';

interface IProps {
  room: IRoom | null;
  user: IUser | null;
  showResult: boolean;
}

const Players: React.FunctionComponent<IProps> = (props) => {
  return <ul className="players">
    {props.room && props.room.users.map((usr) => {
      return usr.id !== props.user!.id &&
        <Player
          key={usr.name}
          user={usr}
          cardSelected={props.room && props.room.selectedCard}
          showResult={props.showResult}
        />;
    })}
  </ul>;
};

export default Players;
