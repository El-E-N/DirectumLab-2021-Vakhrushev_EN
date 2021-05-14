import * as React from 'react';
import Players from '../players/players';
import Button from '../button/button';
import Input from '../input/input';
import EnterStory from '../enter-story/enter-story';
import Player from '../player/player';
import {IRoom, IPlayer, IVote} from '../../store/types';
import './menu.css';

export interface IMenuProps {
  addEnter: boolean;
  onClick?(): void;
}

interface IProps extends IMenuProps {
  room: IRoom | null,
  player: IPlayer | null,
  getVote(user: IPlayer): IVote | null;
}

class Menu extends React.Component<IProps, unknown> {
  constructor(props: IProps) {
    super(props);
  }

  render() {
    const {player, room} = this.props;
    const showButton = player && room && player.id === room.hostId;
    return <div className="menu">
      <span className="menu__header">Story voting completed</span>
      <h3 className="menu__title">Players:</h3>
      {room &&
      <Players
        room={room}
        user={this.props.player}
        showResult={this.props.addEnter}
        getVote={this.props.getVote}
      />}
      {room && this.props.player &&
      <Player
        player={this.props.player}
        showResult={this.props.addEnter}
        vote={this.props.getVote(this.props.player)}
      />}
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

export default Menu;
