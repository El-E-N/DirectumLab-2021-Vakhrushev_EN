import * as React from 'react';
import Logo from './../logo/logo';
import User from './../user/user';
import {IUser} from '../../store/types';
import './header.css';

interface IProps {
  user: IUser | null;
}

const HeaderView: React.FunctionComponent<IProps> = ({user}) => {
  return <header className="header">
    <div className="header__content">
      <Logo/>
      {/* eslint-disable-next-line no-console */}
      {user !== null && user.id && <User user={user}/>}
    </div>
  </header>;
};

export default HeaderView;
