import * as React from 'react';
import Input from '../input/input';
import Button from '../button/button';
import './enter-story.css';
import { IDiscussion, IPlayer, IRoom } from '../../store/types';
import * as discussionApi from '../../api/discussion-api';

interface IProps {
  room: IRoom;
  discussions: IDiscussion[];
  player: IPlayer;
  createDiscussion(roomId: string): void;
  loadingRoom(hash: string, choosedDiscussionId: string | null): void;
}

interface IState {
  discussionName: string;
  placeHolder: string;
  class: string;
}

class EnterStory extends React.Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.updateDiscussionName = this.updateDiscussionName.bind(this);
    this.state = {
      discussionName: '',
      placeHolder: 'Enter discussion name',
      class: ''
    };
  }

  async handleSubmit() {
    const {room} = this.props;
    if (room !== null && room.currentDiscussionId !== null) {
      if (this.state.discussionName !== '') {
        this.setState({
          placeHolder: 'Enter discussion name',
          class: ''
        });

        await discussionApi.setDiscussionNameRequest(room.currentDiscussionId, this.state.discussionName);
        this.props.createDiscussion(room.hash);
        this.props.loadingRoom(room.hash, room.choosedDiscussionId);
      } else {
        this.setState({
          placeHolder: 'Empty value',
          class: 'red'
        });
      }
    }
  }

  updateDiscussionName(evt: React.ChangeEvent<HTMLInputElement>): void {
    this.setState({
      discussionName: evt.target.value
    });
  }

  render() {
    return <div className={'enter-story ' + this.state.class}>
      <Input 
        type={'text'} 
        name={'story'} 
        className={'enter-story__input'} 
        onBlur={(evt) => this.updateDiscussionName(evt)}
        placeHolder={this.state.placeHolder}
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
