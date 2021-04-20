import * as React from 'react';
import userImage from '../../images/userIcon.svg';
import Button from '../button/button';
import './user.css';

const User: React.FunctionComponent = () => {
  const userButton = <React.Fragment>
    <span className="user__name">test</span>
    <img className="user__image" alt={'userImage'} src={userImage}/>
  </React.Fragment>;
  return <div className="user">
    <Button className={'user__button'} value={userButton}/>
    <div className="user__menu-wrapper">
      <div className="rhombus"/>
      <div className="user__menu">
        <a href="/#" className="sign-out">Sign Out</a>
      </div>
    </div>
  </div>;
};

export default User;
