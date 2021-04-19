import * as React from 'react';
import userImage from '../../images/userIcon.svg';
import './user.css';

const User: React.FunctionComponent = () => {
  return <div className="user">
    <button className="user__button">
      <span className="user__name">test</span>
      <img className="user__image" alt={'user__image'} src={userImage}/>
    </button>
    <div className="user__menu-wrapper">
      <div className="rhombus"/>
      <div className="user__menu">
        <a href="/#" className="sign-out">Sign Out</a>
      </div>
    </div>
  </div>;
};

export default User;
