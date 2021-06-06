import * as React from 'react';
import Logo from './../logo/logo';
import User from '../user/user';
import {IDiscussion, IPlayer, IRoom} from '../../store/types';
import './header.css';

interface IProps {
  user: IPlayer | null;
  room: IRoom | null;
  currentDiscussion: IDiscussion | null;
  onIndex(room: IRoom, playerId: string | null, discussion: IDiscussion): void;
}

const HeaderView: React.FunctionComponent<IProps> = (props) => {
  return <header className="header">
    <div className="header__content">
      <Logo
        room={props.room}
        discussion={props.currentDiscussion}
        playerId={props.user !== null ? props.user.id : null}
        onIndex={props.onIndex}
      />
      {(props.user !== null && props.room !== null && props.currentDiscussion !== null) ?
      <User
        room={props.room}
        user={props.user}
        discussion={props.currentDiscussion}
        onIndex={props.onIndex}
      /> :
      null}
    </div>
  </header>;
};

export default HeaderView;
