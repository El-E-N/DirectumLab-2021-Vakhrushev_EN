import * as React from 'react';
import ModalUsers from '../modal__users/modal__users';
import { IDiscussion, IRoom } from '../../store/types';
import Button from '../button/button';
import './modal.css';

interface IProps {
  room: IRoom | null;
  discussion: IDiscussion | null;
  closeModal(): void;
}

const ModalView: React.FunctionComponent<IProps> = (props) => {
  return (props.room && props.room.choosedDiscussionId) ?
    <div className="modal">
      <div className="modal__header">Story Details</div>
      <h3 className="modal__title">Players:</h3>
  
      {props.discussion &&
      <ModalUsers players={props.discussion.players} voteArray={props.discussion.voteArray}/>}

      <Button className={'modal__button'} onClick={props.closeModal} value={'Close'}/>
    </div>:
    null;
};

export default ModalView;
