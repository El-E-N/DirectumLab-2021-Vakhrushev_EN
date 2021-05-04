import * as React from 'react';
import Players from '../players/players';
import Button from '../button/button';
import Input from '../input/input';
import EnterStory from '../enter-story/enter-story';
import Player from '../player/player';
import {IRoom, IUser} from '../../store/types';
import './menu.css';

export interface IMenuProps {
  addEnter: boolean;
  onClick?(): void;
}

interface IProps extends IMenuProps {
  room: IRoom,
  user: IUser | null,
}

const MenuView: React.FunctionComponent<IProps> = (props) => {
  const {user, room} = props;
  const showButton = user && user.id === room.ownerId;
  return <div className="menu">
    <span className="menu__header">Story voting completed</span>
    <h3 className="menu__title">Players:</h3>
    <Players room={props.room} user={props.user} showResult={props.addEnter}/>
    <Player user={props.user} cardSelected={props.room.selectedCard} showResult={props.addEnter}/>
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

export default MenuView;
