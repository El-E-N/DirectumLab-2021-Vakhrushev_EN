import * as React from 'react';
import Players from '../players/players';
import Button from '../button/button';
import Input from '../input/input';
import EnterStory from '../enter-story/enter-story';
import Player from '../player/player';
import {IRoom, IPlayer, IVote, IDiscussion} from '../../store/types';
import './menu.css';

export interface IMenuProps {
  addEnter: boolean;
  onClick?(): void;
}

interface IProps extends IMenuProps {
  room: IRoom,
  player: IPlayer,
  discussions: Array<IDiscussion>;
  getVote(discussionId: string, discussions: Array<IDiscussion>, user: IPlayer): IVote | null;
  loadingRoom(hash: string): IRoom;
  createDiscussion(roomId: string): void;
  showPlanning(): void;
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
        user={player}
        showResult={this.props.addEnter}
        discussions={this.props.discussions}
        getVote={this.props.getVote}
      />}
      {(player !== null && player !== undefined) ?
      <Player
        player={player}
        showResult={this.props.addEnter}
        room={room}
        discussions={this.props.discussions}
        getVote={this.props.getVote}
      /> :
      null}
      {this.props.addEnter ?
        <EnterStory 
        discussions={this.props.discussions}
          room={this.props.room} 
          showPlanning={this.props.showPlanning} 
          createDiscussion={this.props.createDiscussion} 
          loadingRoom={this.props.loadingRoom}/> :
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
