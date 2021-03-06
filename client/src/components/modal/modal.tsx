import * as React from 'react';
import {IUser} from '../modal__user/modal__user';
import ModalUsers from '../modal__users/modal__users';
import Button from '../button/button';
import './modal.css';

const users: Array<IUser> = [
  {name: 'test', number: 3},
  {name: 'test 2', number: 8},
];

interface IProps {
  onHideModal?(): void;
}

const Modal: React.FunctionComponent<IProps> = (props) => {
  return <div className="modal">
    <div className="modal__header">Story Details</div>
    <h3 className="modal__title">Players:</h3>
    <ModalUsers users={users}/>
    <Button className={'modal__button'} onClick={props.onHideModal} value={'Close'}/>
  </div>;
};

export default Modal;
