import * as React from 'react';
import download from './../../images/download.svg';
import Stories from '../stories/stories';
import {IStory} from '../story/story';
import Button from '../button/button';
import './history.css';

const stories: Array<IStory> = [
  {name: 'Story', count: 14},
  {name: 'Story', count: 14},
  {name: 'Story', count: 14},
  {name: 'Story', count: 14},
  {name: 'Story', count: 14},
];

interface IProps {
  count: number;
}

const History: React.FunctionComponent<IProps> = (props) => {
  const downloadImg = <img className="history__download" alt={'historyDownload'} src={download}/>;
  return <div className="history">
    <div className="history__header">
      <div className="history__header-wrapper">
        <h3 className="history__title">Completed Stories</h3>
        <div className="history__count">{props.count}</div>
      </div>
      <Button value={downloadImg} className={'history__button'}/>
    </div>
    <Stories stories={stories}/>
  </div>;
};

export default History;
