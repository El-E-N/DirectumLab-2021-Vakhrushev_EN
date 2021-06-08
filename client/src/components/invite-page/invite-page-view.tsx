import * as React from 'react';
import {RouteComponentProps} from 'react-router';
import {RoutePath} from '../../routes';
import MainLabel from '../main__label/main__label';
import Button from '../button/button';
import {IRoom, IPlayer} from '../../store/types';
import './invite-page.css';
import { addPlayerIntoRoomRequest } from '../../api/room-api';
import authService from '../../services/auth-service';

interface IMatchParams {
  hash: string;
}

export interface IProps extends RouteComponentProps<IMatchParams> {
  room: IRoom | null;
  player: IPlayer | null;
  updateUser(name: string | null): void;
  loadingRoom(hash: string, choosedDiscussionId: string | null): void;
  getPlayerByToken(): void;
}

interface IState {
  userName: string;
}

class InvitePageView extends React.Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.state = {
      userName: '',
    };
    this.props.updateUser(null);
  }

  async componentDidMount() {
    await this.props.loadingRoom(this.props.match.params.hash, null);

    if (this.props.room === null)
      this.props.history.push(`/error`);
    if (this.props.player === null && authService.get() !== '')
      await this.props.getPlayerByToken();
  }

  updateUserValue(evt: React.ChangeEvent<HTMLInputElement>) {
    this.setState({
      userName: evt.target.value
    });
  }

  async handleSubmit(evt: React.FormEvent) {
    evt.preventDefault();
    if (this.state.userName !== '' && this.props.room !== null) {
      await this.props.updateUser(this.state.userName);

      if (this.props.player) {
        const response = await addPlayerIntoRoomRequest(this.props.room.hash, this.props.player.id);
        authService.set(response.token);
      }

      this.props.history.push(`${RoutePath.MAIN}/${this.props.room.hash}`);
    }
  }

  render() {
    const value = {
      label: 'User name', 
      placeHolder: 'Enter your name',
      name: 'userName', 
      update: this.updateUserValue.bind(this)
    }
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
        />
        <Button className={'main__button'} value={'Enter'}/>
      </form>
    </main>;
  }
}

export default InvitePageView;
