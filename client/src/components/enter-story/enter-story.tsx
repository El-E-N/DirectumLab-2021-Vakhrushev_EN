import * as React from 'react';
import Input from '../input/input';
import Button from '../button/button';
import './enter-story.css';
import {IPlayer, IRoom} from '../../store/types';
import * as discussionApi from '../../api/discussion-api';

interface IProps {
  room: IRoom;
  player: IPlayer;
  createDiscussion(roomId: string): void;
  loadingRoom(hash: string, choosedDiscussionId: string | null): void;
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
      discussionName: ''
    };
  }

  async handleSubmit(evt: React.FormEvent) {
    evt.preventDefault();

    const {room} = this.props;
    if (room.currentDiscussionId !== null && this.state.discussionName !== '') {
      await discussionApi.setDiscussionNameRequest(room.currentDiscussionId, this.state.discussionName);
      this.props.createDiscussion(room.hash);
      this.props.loadingRoom(room.hash, room.choosedDiscussionId);
    }
  }

  updateDiscussionName(evt: React.ChangeEvent<HTMLInputElement>): void {
    this.setState({
      discussionName: evt.target.value
    });
  }

  render() {
    return <form onSubmit={this.handleSubmit} className={'enter-story'}>
      <Input 
        type={'text'} 
        name={'story'} 
        className={'enter-story__input'} 
        onBlur={(evt) => this.updateDiscussionName(evt)}
      />
      <Button 
        value={'Go'} 
        className={'enter-story__button'} 
      />
    </form>;
  }
}

export default EnterStory;
