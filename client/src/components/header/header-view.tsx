import * as React from 'react';
import Logo from './../logo/logo';
import User from '../user/user';
import {IPlayer} from '../../store/types';
import './header.css';

interface IProps {
  user: IPlayer | null;
}

const HeaderView: React.FunctionComponent<IProps> = (props) => {
  return <header className="header">
    <div className="header__content">
      <Logo/>
      {
        (props.user !== null) ?
          <User user={props.user}/> :
          null
      }
    </div>
  </header>;
};

export default HeaderView;
