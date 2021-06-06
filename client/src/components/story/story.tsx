import * as React from 'react';
import deleteImg from './../../images/delete.svg';
import Button from '../button/button';
import './story.css';
import { deleteDiscussionRequest } from '../../api/discussion-api';
import { IRoom } from '../../store/types';
import { loadingRoom } from '../../store/room/room-operations';

interface IStory {
  name: string | null;
  average: number;
  discussionId: string;
  room: IRoom;
  changeChoosedDiscussion(discussionId: string): void;
  loadingRoom(hash: string, choosedDiscussionId: string | null): void;
}

const Story: React.FunctionComponent<IStory> = (props) => {
  const onClick = (event: React.FormEvent) => {
    event.preventDefault();
    props.changeChoosedDiscussion(props.discussionId);
  };

  const onDelete = async () => {
    console.log('Удалено');
    await deleteDiscussionRequest(props.discussionId);
    await props.loadingRoom(props.room.id, props.room.choosedDiscussionId);
  }

  const storyDeleteImg = <img className="story__delete" alt={'storyDelete'} src={deleteImg}/>;

  return <tr className="story">
    <td className="story__name">
      <a href={'/#'} className="story__link" onClick={onClick}>{props.name}</a>
    </td>
    <td className="story__count">{props.average}</td>
    <td className="story__delete-cell">
      <Button value={storyDeleteImg} className={'story__delete-wrapper'} onClick={onDelete}/>
    </td>
  </tr>;
};

export default Story;
