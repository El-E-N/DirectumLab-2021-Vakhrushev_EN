import * as React from 'react';
import {withRouter, RouteComponentProps} from 'react-router-dom';
import MainLabel from '../main__label/main__label';
import Button from '../button/button';
import {RoutePath} from '../../routes';
import './create-page.css';

const values = [
  {label: 'User name', placeHolder: 'Enter your name', name: 'userName'},
  {label: 'Room name', placeHolder: 'Enter room name', name: 'roomName'}
];

export interface IProps extends RouteComponentProps {
  // eslint-disable-next-line no-unused-vars
  addRoomId(id: string): void;
  // eslint-disable-next-line no-unused-vars
  createRoom(roomId: string, name: string, cards: Array<string>, selectedCard: string | null, ownerId: string): void;
  // eslint-disable-next-line no-unused-vars
  createUser(id: string, name: string): void;
  removeUser(): void;
}

class CreatePageView extends React.Component<IProps, {}> {
  constructor(props: IProps) {
    super(props);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.props.removeUser();
  }

  handleSubmit(evt: React.FormEvent) {
    evt.preventDefault();
    let userName = ((evt.target as Element).children.item(2)!.children.namedItem('userName') as HTMLInputElement).value;
    let roomName = ((evt.target as Element).children.item(3)!.children.namedItem('roomName') as HTMLInputElement).value;
    if (userName && roomName && userName !== '' && roomName !== '') {
      const roomId = `${Math.round(Math.random() * (1000 - 1) + 1)}`;
      const userId = `${Math.round(Math.random() * (1000 - 1) + 1)}`;
      this.props.addRoomId(roomId);
      this.props.createUser(userId, userName);
      this.props.createRoom(roomId,
          roomName,
          ['0', '0.5', '1', '2', '3', '5', '8', '13', '20', '40', '100', '?', '∞', 'coffee'],
          null,
          userId);
      this.props.history.push(`${RoutePath.MAIN}/${roomId}`);
    }
  }

  render() {
    return <main className="main">
      <form action={'POST'} onSubmit={this.handleSubmit} className={'main__content'}>
        <span className="main__tagline">{'Let\'s start!'}</span>
        <h2 className="main__title">{'Create the room:'}</h2>
        {values.map((value) => {
          return <MainLabel key={value.name} name={value.name} title={value.label} placeHolder={value.placeHolder}/>;
        })}
        <Button className={'main__button'} value={'Enter'}/>
      </form>
    </main>;
  }
}

export default withRouter(CreatePageView);
