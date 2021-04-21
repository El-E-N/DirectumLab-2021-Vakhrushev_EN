import * as React from 'react';
import ModalUser, {IUser} from '../modal__user/modal__user';
import './modal__users.css';

interface IProps {
  users: Array<IUser>;
}

const ModalUsers: React.FunctionComponent<IProps> = (props) => {
  return <ul className="modal__users">
    {props.users.map((user) => {
      return <ModalUser
        key={user.name + user.number}
        name={user.name}
        number={user.number}
      />;
    })}
  </ul>;
};

export default ModalUsers;
