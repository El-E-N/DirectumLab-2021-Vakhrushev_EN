import * as React from 'react';
import deleteImg from './../../images/delete.svg';
import Button from '../button/button';
import {deleteDiscussionRequest} from '../../api/discussion-api';
import {IPlayer, IRoom} from '../../store/types';
import './story.css';
import authService from '../../services/auth-service';

interface IStory {
  name: string;
  average: number;
  discussionId: string;
  room: IRoom;
  player: IPlayer;
  changeChoosedDiscussion(discussionId: string): void;
  loadingRoom(hash: string, choosedDiscussionId: string | null): void;
}

const Story: React.FunctionComponent<IStory> = (props) => {
  const onShowModal = (event: React.FormEvent) => {
    event.preventDefault();
    props.changeChoosedDiscussion(props.discussionId);
  };

  const onDelete = async () => {
    const response: {token: string} = await deleteDiscussionRequest(props.discussionId);
    authService.set(response.token);
    await props.loadingRoom(props.room.hash, props.room.choosedDiscussionId);
  }

  const storyDeleteImg = <img className="story__delete" alt={'storyDelete'} src={deleteImg}/>;

  return <tr className="story">
    <td className="story__name">
      <a href={'/#'} className="story__link" onClick={onShowModal}>{props.name}</a>
    </td>
    <td className="story__count">{props.average}</td>
    {(props.player.id === props.room.hostId) ?
      <td className="story__delete-cell">
        <Button value={storyDeleteImg} className={'story__delete-wrapper'} onClick={onDelete}/>
      </td> :
      null}
  </tr>;
};

export default Story;
