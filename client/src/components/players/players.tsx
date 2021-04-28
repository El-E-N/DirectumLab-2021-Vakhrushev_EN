import * as React from 'react';
import Player from '../player/player';
import './players.css';

interface IProps {
  players: {name: string, active: boolean}[];
}

const Players: React.FunctionComponent<IProps> = (props) => {
  return <ul className="players">
    {props.players.map((player) => {
      return <Player key={player.name} name={player.name} active={player.active}/>;
    })}
  </ul>;
};

export default Players;
