import * as React from 'react';
import Story from '../story/story';
import {IStory} from '../../store/types';
import './stories.css';

interface IProps {
  stories: Array<IStory>;
  onShowModal?(): void;
}

const Stories: React.FunctionComponent<IProps> = (props) => {
  return <table className="stories">
    {/* eslint-disable-next-line consistent-return */}
    {props.stories.map((story) => {
      if (story.average) {
        return <Story
          key={story.name + story.id}
          name={story.name}
          average={story.average}
          onShowModal={props.onShowModal}
        />;
      }
    })}
  </table>;
};

export default Stories;
