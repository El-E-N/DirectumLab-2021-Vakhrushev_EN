import * as React from 'react';
import {RouteComponentProps} from 'react-router-dom';
import MainLabel from '../main__label/main__label';
import Button from '../button/button';
import {IDiscussion, IPlayer, IRoom} from '../../store/types';
import {RoutePath} from '../../routes';
import './create-page.css';

export interface IProps extends RouteComponentProps {
  player: IPlayer | null;
  room: IRoom | null;
  discussion: IDiscussion | null;
  createRoom(roomName: string, creatorId: string): IRoom;
  createUser(name: string | null): IPlayer | null;
  createDiscussion(roomId: string): void;
}

interface IState {
  userName: string;
  roomName: string;
}

class CreatePageView extends React.Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.updateUserValue = this.updateUserValue.bind(this);
    this.updateRoomValue = this.updateRoomValue.bind(this);
    this.state = {
      userName: '',
      roomName: '',
    };
    this.props.createUser(null);
  }

  async handleSubmit(evt: React.FormEvent) {
    evt.preventDefault();
    if (this.state.roomName !== '' && this.state.userName !== '') {
      await this.props.createUser(this.state.userName);

      this.props.player && await this.props.createRoom(this.state.roomName, this.props.player.id);

      this.props.room && await this.props.createDiscussion(this.props.room.id);

      this.props.room && this.props.history.push(`${RoutePath.MAIN}/${this.props.room.hash}`);
    }
  }

  updateUserValue(evt: React.ChangeEvent<HTMLInputElement>): void {
    this.setState({
      userName: evt.target.value
    });
  }

  updateRoomValue(evt: React.ChangeEvent<HTMLInputElement>): void {
    this.setState({
      roomName: evt.target.value
    });
  }

  render() {
    const values = [
      {label: 'User name', placeHolder: 'Enter your name', name: 'userName', update: this.updateUserValue},
      {label: 'Room name', placeHolder: 'Enter room name', name: 'roomName', update: this.updateRoomValue}
    ];
    return <main className="main">
      <form action={'POST'} onSubmit={this.handleSubmit} className={'main__content'}>
        <span className="main__tagline">{'Let\'s start!'}</span>
        <h2 className="main__title">{'Create the room:'}</h2>
        {values.map((value) => {
          return <MainLabel
            updateValue={(evt) => value.update(evt)}
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
