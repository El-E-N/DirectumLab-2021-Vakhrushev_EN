import * as React from 'react';
import {RouteComponentProps} from 'react-router';
import {RoutePath} from '../../routes';
import MainLabel from '../main__label/main__label';
import Button from '../button/button';
import {IRoom, IPlayer} from '../../store/types';
import './invite-page.css';

export interface IProps extends RouteComponentProps {
  room: IRoom | null;
  player: IPlayer | null;
  updateUser(name: string | null): IPlayer | null;
  addUserIntoRoom(room: IRoom, newUser: IPlayer): void;
}

interface IState {
  userName: string;
}

class InvitePageView extends React.Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.updateUserValue = this.updateUserValue.bind(this);
    this.state = {
      userName: '',
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
      await this.props.updateUser(this.state.userName);

      this.props.player && await this.props.addUserIntoRoom(this.props.room, this.props.player);

      this.props.history.push(`${RoutePath.MAIN}/${this.props.room.hash}`);
    }
  }

  render() {
    const values = [
      {label: 'User name', placeHolder: 'Enter your name', name: 'userName', update: this.updateUserValue}
    ];
    return <main className="main">
      <form action={'POST'} onSubmit={this.handleSubmit} className={'main__content invite'}>
        <span className="main__tagline">{'Let\'s start!'}</span>
        <h2 className="main__title">{'Join the room:'}</h2>
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

export default InvitePageView;
