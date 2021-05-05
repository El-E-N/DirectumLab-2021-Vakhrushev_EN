import * as React from 'react';
import {RouteComponentProps} from 'react-router';
import {RoutePath} from '../../routes';
import MainLabel from '../main__label/main__label';
import Button from '../button/button';
import {IRoom, IUser} from '../../store/types';
import './invite-page.css';

const values = [
  {label: 'User name', placeHolder: 'Enter your name', name: 'userName'}
];

export interface IProps extends RouteComponentProps {
  room: IRoom;
  // eslint-disable-next-line no-unused-vars
  updateUser(user: IUser | null): void;
  // eslint-disable-next-line no-unused-vars
  addUserIntoRoom(room: IRoom, newUser: IUser): void;
}

class InvitePageView extends React.Component<IProps, {}> {
  constructor(props: IProps) {
    super(props);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.props.updateUser(null);
  }

  handleSubmit(evt: React.FormEvent) {
    evt.preventDefault();
    let name = ((evt.target as Element).children.item(2)!.children.namedItem('userName') as HTMLInputElement).value;
    if (name !== undefined && name !== '') {
      const userId = `${Math.round(Math.random() * (1000 - 1) + 1)}`;
      this.props.updateUser({id: userId, name});
      this.props.addUserIntoRoom(this.props.room, {id: userId, name});
      this.props.history.push(`${RoutePath.MAIN}/${this.props.room.id}`);
    }
  }

  render() {
    return <main className="main">
      <form action={'POST'} onSubmit={this.handleSubmit} className={'main__content invite'}>
        <span className="main__tagline">{'Let\'s start!'}</span>
        <h2 className="main__title">{'Join the room:'}</h2>
        {values.map((value) => {
          return <MainLabel key={value.name} name={value.name} title={value.label} placeHolder={value.placeHolder}/>;
        })}
        <Button className={'main__button'} value={'Enter'}/>
      </form>
    </main>;
  }
}

export default InvitePageView;
