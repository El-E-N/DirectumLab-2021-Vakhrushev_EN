import * as React from 'react';
import Input from '../input/input';
import Button from '../button/button';
import './enter-story.css';

const EnterStory: React.FunctionComponent = () => {
  return <div className="enter-story">
    <Input type={'text'} name={'story'} className={'enter-story__input'}/>
    <Button value={'Go'} className={'enter-story__button'}/>
  </div>;
};

export default EnterStory;
