import * as React from 'react';
import userIcon from './../../images/userIcon.svg';
import './modal__user.css';

export interface IUser {
  name: string;
  value: string;
}

const ModalUser: React.FunctionComponent<IUser> = (props) => {
  return <li className="modal__user">
    <div className="modal__user-wrapper">
      <img className="modal__user-image" alt={'modal__user-img'} src={userIcon}/>
      <span className="modal__user-name">{props.name}</span>
    </div>
    <span className="modal__user-number">{props.value}</span>
  </li>;
};

export default ModalUser;
