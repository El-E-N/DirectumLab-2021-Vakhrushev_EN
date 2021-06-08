import * as React from 'react';
import Player from '../player/player';
import {IRoom, IPlayer, IVote, IDiscussion} from '../../store/types';
import './players.css';

interface IProps {
  room: IRoom;
  user: IPlayer;
  discussion: IDiscussion;
  showResult: boolean;
  getVote(user: IPlayer): IVote | null;
}

const Players: React.FunctionComponent<IProps> = (props) => {
  const players = props.discussion.players;

  return <ul className="players">
    {players.map((player) => {
      return player.id !== props.user.id ?

        <Player
          key={player.name}
          player={player}
          showResult={props.showResult}
          room={props.room}
          getVote={props.getVote}
        /> :

        null;
    })}
  </ul>;
};

export default Players;
