import * as React from 'react';
import {RouteComponentProps} from 'react-router';
import {RoutePath} from '../../routes';
import MainLabel from '../main__label/main__label';
import Button from '../button/button';
import {IRoom, IPlayer} from '../../store/types';
import './invite-page.css';
import { addPlayerIntoRoomRequest } from '../../api/room-api';

export interface IProps extends RouteComponentProps {
  room: IRoom | null;
  player: IPlayer | null;
  updateUser(name: string | null): IPlayer | null;
  addUserIntoRoom(room: IRoom, newUser: IPlayer): void;
}

interface IState {
  userName: string;
  value: {
    label: string;
    class: string;
    placeHolder: string;
    name: string;
    update: (evt: React.ChangeEvent<HTMLInputElement>) => void;
  }
}

class InvitePageView extends React.Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.state = {
      userName: '',
      value: {
        label: 'User name', 
        class: '', 
        placeHolder: 'Enter your name',
        name: 'userName', 
        update: this.updateUserValue.bind(this)
      }
    };
    this.props.updateUser(null);
  }

  updateUserValue(evt: React.ChangeEvent<HTMLInputElement>) {
    this.setState({
      userName: evt.target.value
    });
  }

  async handleSubmit(evt: React.FormEvent) {
    evt.preventDefault();
    if (this.state.userName !== '' && this.props.room !== null) {
      this.setState({
        value: {
          ...this.state.value,
          class: '',
          placeHolder: 'Enter your name'
        }
      });

      await this.props.updateUser(this.state.userName);

      this.props.player && await addPlayerIntoRoomRequest(this.props.room.hash, this.props.player.id);

      this.props.history.push(`${RoutePath.MAIN}/${this.props.room.hash}`);
    } else {

      let tempValue: {
        label: string;
        class: string;
        placeHolder: string;
        name: string;
        update: (evt: React.ChangeEvent<HTMLInputElement>) => void;
      } = this.state.value;

      if (this.state.userName === '') {
        tempValue = {
          ...this.state.value,
          class: 'red',
          placeHolder: 'Empty value'
        };
      } else {
        tempValue = {
          ...this.state.value,
          class: '',
          placeHolder: 'Enter your name'
        };
      }

      this.setState({
        value: tempValue
      });
    }
  }

  render() {
    const {value} = this.state;
    return <main className="main">
      <form action={'POST'} onSubmit={this.handleSubmit} className={'main__content invite'}>
        <span className="main__tagline">{'Let\'s start!'}</span>
        <h2 className="main__title">{'Join the room:'}</h2>
        <MainLabel
          updateValue={value.update}
          key={value.name}
          name={value.name}
          title={value.label}
          placeHolder={value.placeHolder}
          class={value.class}
        />
        <Button className={'main__button'} value={'Enter'}/>
      </form>
    </main>;
  }

  componentDidMount() {
    if (this.props.room === null)
      this.props.history.push(`/error`);
  }
}

export default InvitePageView;
