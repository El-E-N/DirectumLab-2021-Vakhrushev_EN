import * as React from 'react';
import Story from '../story/story';
import {IDiscussion, IRoom} from '../../store/types';
import './stories.css';

interface IProps {
  stories: Array<IDiscussion>;
  room: IRoom;
  changeChoosedDiscussion(discussionId: string): void;
  loadingRoom(hash: string, choosedDiscussionId: string | null): void;
}

const Stories: React.FunctionComponent<IProps> = (props) => {
  return <table className="stories">
    {props.stories.map((story) => {
      if (story.average !== null && story.name !== null) {
        return <Story
          key={story.name + story.id}
          name={story.name}
          average={story.average}
          discussionId={story.id}
          room={props.room}
          changeChoosedDiscussion={props.changeChoosedDiscussion}
          loadingRoom={props.loadingRoom}
        />;
      }
    })}
  </table>;
};

export default Stories;
