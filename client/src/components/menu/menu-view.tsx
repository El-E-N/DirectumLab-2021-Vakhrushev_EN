import * as React from 'react';
import Players from '../players/players';
import Button from '../button/button';
import Input from '../input/input';
import EnterStory from '../enter-story/enter-story';
import Player from '../player/player';
import {IRoom, IPlayer} from '../../store/types';
import './menu.css';

export interface IMenuProps {
  addEnter: boolean;
  onClick?(): void;
}

interface IProps extends IMenuProps {
  room: IRoom | null,
  player: IPlayer | null,
}

interface IState {
  selectedCard: string | null;
}

class MenuView extends React.Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);
    this.state = {
      selectedCard: props.room && props.room.selectedCard,
    };
  }

  render() {
    const {player, room} = this.props;
    const showButton = player && room && player.id === room.hostId;
    return <div className="menu">
      <span className="menu__header">Story voting completed</span>
      <h3 className="menu__title">Players:</h3>
      {room !== null && <Players room={room} user={this.props.player} showResult={this.props.addEnter}/>}
      {room && <Player player={this.props.player} showResult={this.props.addEnter}/>}
      {this.props.addEnter ?
        <EnterStory/> :
        showButton && <Button className={'menu__button'} value={'Finish voting'} onClick={this.props.onClick}/>}
      <span className="menu__link-name">Invite a teammate</span>
      <Input
        className={'menu__link'}
        type={'text'}
        name={'menuLink'}
        readOnly
        value={window.location.href}
      />
    </div>;
  }
}

export default MenuView;
