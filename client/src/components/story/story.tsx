import * as React from 'react';
import deleteImg from './../../images/delete.svg';
import Button from '../button/button';
import './story.css';

interface IStory {
  name: string | null;
  average: number | null;
  changeShownModal(activated: boolean): void;
}

const Story: React.FunctionComponent<IStory> = (props) => {
  const onClick = (event: React.FormEvent) => {
    event.preventDefault();
    props.changeShownModal(true);
  };

  const storyDeleteImg = <img className="story__delete" alt={'storyDelete'} src={deleteImg}/>;

  return <tr className="story">
    <td className="story__name">
      <a href={'/#'} className="story__link" onClick={onClick}>{props.name}</a>
    </td>
    <td className="story__count">{props.average}</td>
    <td className="story__delete-cell">
      <Button value={storyDeleteImg} className={'story__delete-wrapper'}/>
    </td>
  </tr>;
};

export default Story;
