import * as React from 'react';
import Player from '../player/player';
import {IPlayer} from '../player/player';
import './players.css';

interface IProps {
  players: Array<IPlayer>;
  showResult: boolean;
}

const Players: React.FunctionComponent<IProps> = (props) => {
  return <ul className="players">
    {props.players.map((player) => {
      return <Player key={player.name} name={player.name} cardSelected={player.cardSelected} showResult={props.showResult}/>;
    })}
  </ul>;
};

export default Players;
