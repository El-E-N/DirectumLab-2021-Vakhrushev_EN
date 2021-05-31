import * as React from 'react';
import Input from '../input/input';
import Button from '../button/button';
import './enter-story.css';
import { IDiscussion, IRoom } from '../../store/types';
import * as discussionApi from '../../api/discussion-api';

interface IProps {
  room: IRoom;
  discussions: IDiscussion[];
  createDiscussion(roomId: string): void;
  loadingRoom(hash: string): IRoom;
  showPlanning(): void;
}

interface IState {
  discussionName: string;
}

class EnterStory extends React.Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.updateDiscussionName = this.updateDiscussionName.bind(this);
    this.state = {
      discussionName: '',
    };
  }

  async handleSubmit() {
    if (this.props.room !== null && this.props.room.currentDiscussionId !== null) {
      await discussionApi.setDiscussionNameRequest(this.props.room.currentDiscussionId, this.state.discussionName);
      this.props.createDiscussion(this.props.room.id);
      this.props.showPlanning();
      this.props.loadingRoom(this.props.room.hash);
    }
  }

  updateDiscussionName(evt: React.ChangeEvent<HTMLInputElement>): void {
    this.setState({
      discussionName: evt.target.value
    });
  }

  render() {
    return <div className="enter-story">
      <Input 
        type={'text'} 
        name={'story'} 
        className={'enter-story__input'} 
        onBlur={(evt) => this.updateDiscussionName(evt)}
      />
      <Button 
        value={'Go'} 
        className={'enter-story__button'} 
        onClick={this.handleSubmit}
      />
    </div>;
  }
}

export default EnterStory;
