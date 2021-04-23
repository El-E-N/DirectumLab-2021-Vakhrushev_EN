import * as React from 'react';
import Story, {IStory} from '../story/story';
import './stories.css';

interface IProps {
  stories: Array<IStory>;
}

const Stories: React.FunctionComponent<IProps> = (props) => {
  return <table className="stories">
    {props.stories.map((story) => {
      return <Story
        key={story.name + story.count}
        name={story.name}
        count={story.count}
      />;
    })}
  </table>;
};

export default Stories;
