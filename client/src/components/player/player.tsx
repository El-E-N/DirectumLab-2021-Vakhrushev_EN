import * as React from 'react';
import playerIcon from './../../images/userIcon.svg';
import check from './../../images/check.svg';
import './player.css';

interface IProps {
  name: string;
}

const Player: React.FunctionComponent<IProps> = (props) => {
  return <li className="player">
    <div className="player__wrapper">
      <img className="player__icon" alt={'playerIcon'} src={playerIcon}/>
      <span className="player__name">{props.name}</span>
    </div>
    <img className="checked" alt={'checked'} src={check}/>
  </li>;
};

export default Player;
