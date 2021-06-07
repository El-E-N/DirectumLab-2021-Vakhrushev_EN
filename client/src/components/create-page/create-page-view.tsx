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
  values: {
    label: string;
    class: string;
    placeHolder: string;
    name: string;
    update: (evt: React.ChangeEvent<HTMLInputElement>) => void;
  }[]
}

class CreatePageView extends React.Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.state = {
      userName: '',
      roomName: '',
      values: [
        {label: 'User name', class: '', placeHolder: 'Enter your name', name: 'userName', update: this.updateUserValue.bind(this)},
        {label: 'Room name', class: '', placeHolder: 'Enter room name', name: 'roomName', update: this.updateRoomValue.bind(this)}
      ]
    };
    this.props.createUser(null);
  }

  async handleSubmit(evt: React.FormEvent) {
    evt.preventDefault();
    
    if (this.state.roomName !== '' && this.state.userName !== '') {
      this.setState({
        values: [
          {
            ...this.state.values[0],
            class: '',
            placeHolder: 'Enter your name'
          },
          {
            ...this.state.values[1],
            class: '',
            placeHolder: 'Enter room name'
          }
        ]
      });

      await this.props.createUser(this.state.userName);

      this.props.player && await this.props.createRoom(this.state.roomName, this.props.player.id);

      this.props.room && await this.props.createDiscussion(this.props.room.hash);

      this.props.room && this.props.history.push(`${RoutePath.MAIN}/${this.props.room.hash}`);
    } else {

      const tempValues: {
        label: string;
        class: string;
        placeHolder: string;
        name: string;
        update: (evt: React.ChangeEvent<HTMLInputElement>) => void;
      }[] = [];

      if (this.state.userName === '') {
        tempValues.push({
          ...this.state.values[0],
          class: 'red',
          placeHolder: 'Empty value'
        });
      } else {
        tempValues.push({
          ...this.state.values[0],
          class: '',
          placeHolder: 'Enter your name'
        });
      }

      if (this.state.roomName === '') {
        tempValues.push({
          ...this.state.values[1],
          class: 'red',
          placeHolder: 'Empty value'
        });
      } else {
        tempValues.push({
          ...this.state.values[1],
          class: '',
          placeHolder: 'Enter room name'
        });
      }

      this.setState({
        values: tempValues
      });
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
    return <main className="main">
      <form action={'POST'} onSubmit={this.handleSubmit} className={'main__content'}>
        <span className="main__tagline">{'Let\'s start!'}</span>
        <h2 className="main__title">{'Create the room:'}</h2>
        {this.state.values.map((value) => {
          return <MainLabel
            updateValue={value.update}
            key={value.name}
            name={value.name}
            title={value.label}
            placeHolder={value.placeHolder}
            class={value.class}
          />;
        })}
        <Button className={'main__button'} value={'Enter'}/>
      </form>
    </main>;
  }
}

export default CreatePageView;
