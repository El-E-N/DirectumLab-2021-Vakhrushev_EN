import * as React from 'react';
import Players from '../players/players';
import Button from '../button/button';
import Input from '../input/input';
import EnterStory from '../enter-story/enter-story';
import Player, {IPlayer} from '../player/player';
import {IRoom, IUser} from '../../store/types';
import './menu.css';

export const players: Array<IPlayer> = [
  {name: 'test', cardSelected: '8'},
  {name: 'test 2', cardSelected: '2'},
  {name: 'test 3', cardSelected: '0.5'},
];

interface IProps {
  room: IRoom,
  user: IUser | null,
  addEnter: boolean;
  onClick?(): void;
  newName?: string;
  cardSelected: string | null;
}

const Menu: React.FunctionComponent<IProps> = (props) => {
  const {user, room} = props;
  const showButton = user && user.id === room.ownerId;
  return <div className="menu">
    <span className="menu__header">Story voting completed</span>
    <h3 className="menu__title">Players:</h3>
    <Players players={players} showResult={props.addEnter}/>
    <Player name={props.newName!} cardSelected={props.cardSelected} showResult={props.addEnter}/>
    {props.addEnter ?
      <EnterStory/> :
      showButton && <Button className={'menu__button'} value={'Finish voting'} onClick={props.onClick}/>}
    <span className="menu__link-name">Invite a teammate</span>
    <Input
      className={'menu__link'}
      type={'text'}
      name={'menuLink'}
      readOnly
      value={window.location.href}
    />
  </div>;
};

export default Menu;
