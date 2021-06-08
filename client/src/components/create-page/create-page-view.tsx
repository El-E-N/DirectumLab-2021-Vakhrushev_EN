import * as React from 'react';
import {RouteComponentProps} from 'react-router-dom';
import MainLabel from '../main__label/main__label';
import Button from '../button/button';
import {IDiscussion, IPlayer, IRoom} from '../../store/types';
import {RoutePath} from '../../routes';
import './create-page.css';
import authService from '../../services/auth-service';

export interface IProps extends RouteComponentProps {
  player: IPlayer | null;
  room: IRoom | null;
  discussion: IDiscussion | null;
  createRoom(roomName: string, creatorId: string): IRoom;
  createUser(name: string | null): IPlayer | null;
  createDiscussion(roomId: string): void;
  clearDates(room: IRoom, playerId: string | null, discussion: IDiscussion): void;
}

interface IState {
  userName: string;
  roomName: string;
}

class CreatePageView extends React.Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.state = {
      userName: '',
      roomName: '',
    };

    this.props.createUser(null);

    if (this.props.room !== null && this.props.discussion !== null)
      this.props.clearDates(
        this.props.room, 
        this.props.player ? this.props.player.id : null, 
        this.props.discussion
      );

    authService.set('');
  }

  async handleSubmit(evt: React.FormEvent) {
    evt.preventDefault();
    
    if (this.state.roomName !== '' && this.state.userName !== '') {
      await this.props.createUser(this.state.userName);

      if (this.props.player) 
        await this.props.createRoom(this.state.roomName, this.props.player.id);

      if (this.props.room) {
        await this.props.createDiscussion(this.props.room.hash);
        this.props.history.push(`${RoutePath.MAIN}/${this.props.room.hash}`);
      }
    } 
  }

  updateUserValue(evt: React.ChangeEvent<HTMLInputElement>) {
    this.setState({
      userName: evt.target.value
    });
  }

  updateRoomValue(evt: React.ChangeEvent<HTMLInputElement>) {
    this.setState({
      roomName: evt.target.value
    });
  }

  render() {
    const values = [
      {label: 'User name', placeHolder: 'Enter your name', name: 'userName', update: this.updateUserValue.bind(this)},
      {label: 'Room name', placeHolder: 'Enter room name', name: 'roomName', update: this.updateRoomValue.bind(this)}
    ];

    return <main className="main">
      <form action={'POST'} onSubmit={this.handleSubmit} className={'main__content'}>
        <span className="main__tagline">{'Let\'s start!'}</span>
        <h2 className="main__title">{'Create the room:'}</h2>
        {values.map((value) => {
          return <MainLabel
            updateValue={value.update}
            key={value.name}
            name={value.name}
            title={value.label}
            placeHolder={value.placeHolder}
          />;
        })}
        <Button className={'main__button'} value={'Enter'}/>
      </form>
    </main>;
  }
}

export default CreatePageView;
