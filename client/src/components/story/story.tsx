import * as React from 'react';
import deleteImg from './../../images/delete.svg';
import Button from '../button/button';
import './story.css';

export interface IStory {
  name: string;
  count: number;
  onShowModal?(): void;
}

const Story: React.FunctionComponent<IStory> = (props) => {
  const storyDeleteImg = <img className="story__delete" alt={'storyDelete'} src={deleteImg}/>;
  return <tr className="story">
    <td className="story__name">
      <a href={void (0)} className="story__link" onClick={props.onShowModal}>{props.name}</a>
    </td>
    <td className="story__count">{props.count}</td>
    <td className="story__delete-cell">
      <Button value={storyDeleteImg} className={'story__delete-wrapper'}/>
    </td>
  </tr>;
};

export default Story;
