import * as React from 'react';
import Players from '../players/players';
import Button from '../button/button';
import Input from '../input/input';
import EnterStory from '../enter-story/enter-story';
import Player from '../player/player';
import {IRoom, IPlayer, IVote, IDiscussion} from '../../store/types';
import './menu.css';

export interface IMenuProps {
  showResults: boolean;
  onCloseDiscussion(): void;
}

interface IProps extends IMenuProps {
  room: IRoom,
  player: IPlayer,
  discussion: IDiscussion;
  getVote(user: IPlayer): IVote | null;
  loadingRoom(hash: string, choosedDiscussionId: string | null): void;
  createDiscussion(roomId: string): void;
}

const Menu: React.FunctionComponent<IProps> = (props) => {
  const {player, room} = props;
  const showButton = player.id === room.hostId;

  return <div className="menu">
    <span className="menu__header">Story voting completed</span>
    <h3 className="menu__title">Players:</h3>
    <Player
      player={player}
      showResult={props.showResults}
      room={room}
      getVote={props.getVote}
    />
    <Players
      room={room}
      user={player}
      showResult={props.showResults}
      discussion={props.discussion}
      getVote={props.getVote}
    />
    {(showButton) ?

      props.showResults ?

        <EnterStory 
          room={props.room} 
          createDiscussion={props.createDiscussion} 
          loadingRoom={props.loadingRoom}
          player={player}
        /> :

        <Button 
          className={'menu__button'} 
          value={'Finish voting'} 
          onClick={props.onCloseDiscussion}
        /> :

      null}

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

export default Menu;
