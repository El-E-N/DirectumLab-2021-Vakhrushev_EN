import * as React from 'react';
import download from '../../images/download.svg';
import Stories from '../stories/stories';
import {IDiscussion} from '../../store/types';
import Button from '../button/button';
import './history.css';

interface IProps {
  discussions: Array<IDiscussion>;
  changeShownModal(activated: boolean): void;
}

const History: React.FunctionComponent<IProps> = (props) => {
  const downloadImg = <img className="history__download" alt={'historyDownload'} src={download}/>;
  return <div className="history">
    <div className="history__header">
      <div className="history__header-wrapper">
        <h3 className="history__title">Completed Stories</h3>
        <div className="history__count">{props.discussions.length}</div>
      </div>
      <Button value={downloadImg} className={'history__button'}/>
    </div>
    <Stories stories={props.discussions} changeShownModal={props.changeShownModal}/>
  </div>;
};

export default History;
