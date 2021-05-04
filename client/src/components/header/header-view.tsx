import * as React from 'react';
import Logo from './../logo/logo';
import User from './../user/user';
import {IUser} from '../../store/types';
import {RouteComponentProps} from 'react-router-dom';
import './header.css';

interface IProps extends RouteComponentProps<IMatchParams> {
  user: IUser | null;
}

interface IMatchParams {
  id: string;
}

const HeaderView: React.FunctionComponent<IProps> = (props) => {
  return <header className="header">
    <div className="header__content">
      <Logo/>
      {props.user !== null && props.user.id && <User user={props.user}/>}
    </div>
  </header>;
};

export default HeaderView;
