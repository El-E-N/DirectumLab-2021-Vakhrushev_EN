import * as React from 'react';
import Player from '../player/player';
import './players.css';

interface IProps {
  names: {name: string, active: boolean}[];
}

const Players: React.FunctionComponent<IProps> = (props) => {
  return <ul className="players">
    {props.names.map((array) => {
      return <Player key={array.name} name={array.name} active={array.active}/>;
    })}
  </ul>;
};

export default Players;
