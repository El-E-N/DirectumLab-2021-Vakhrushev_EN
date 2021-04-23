import * as React from 'react';
import Player from '../player/player';
import './players.css';

interface IProps {
  names: Array<string>;
}

const Players: React.FunctionComponent<IProps> = (props) => {
  return <ul className="players">
    {props.names.map((name) => {
      return <Player key={name} name={name}/>;
    })}
  </ul>;
};

export default Players;
