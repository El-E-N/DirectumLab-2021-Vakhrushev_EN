import * as React from 'react';
import Logo from './../logo/logo';
import User from '../user/user';
import {IUser, IRoom} from '../../store/types';
import './header.css';

interface IProps {
  user: IUser | null;
  room: IRoom | null;
}

const HeaderView: React.FunctionComponent<IProps> = (props) => {
  return <header className="header">
    <div className="header__content">
      <Logo/>
      {props.user !== null && props.room !== null && props.user.id && <User/>}
    </div>
  </header>;
};

export default HeaderView;
