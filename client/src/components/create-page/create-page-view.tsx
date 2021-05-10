import * as React from 'react';
import {RouteComponentProps} from 'react-router-dom';
import MainLabel from '../main__label/main__label';
import Button from '../button/button';
import {IPlayer, IRoom} from '../../store/types';
import {RoutePath} from '../../routes';
import './create-page.css';

export interface IProps extends RouteComponentProps {
  // eslint-disable-next-line no-unused-vars
  createRoom(roomName: string, creatorId: string): IRoom;
  // eslint-disable-next-line no-unused-vars
  createUser(name: string | null): IPlayer | null;
  // eslint-disable-next-line no-unused-vars
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
      const user = await this.props.createUser(this.state.userName);
      const room = user && await this.props.createRoom(this.state.roomName, user.id);
      room && await this.props.createDiscussion(room.id);
      room && this.props.history.push(`${RoutePath.MAIN}/${room.hash}`);
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
