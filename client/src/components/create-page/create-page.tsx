import * as React from 'react';
import {withRouter, RouteComponentProps} from 'react-router-dom';
import MainLabel from '../main__label/main__label';
import Button from '../button/button';
import {RoutePath} from '../../routes';
import './create-page.css';

const values = [
  {label: 'User name', placeHolder: 'Enter your name', name: 'userName', id: 'name'},
  {label: 'Room name', placeHolder: 'Enter room name', name: 'roomName', id: 'rName'}
];

interface IProps extends RouteComponentProps {
  onHideUser?(): void;
  isShowUser?: boolean;
  onAddAuthentication?(): void;
  // eslint-disable-next-line no-unused-vars
  onAddName?(value: string): void;
  // eslint-disable-next-line no-unused-vars
  onAddRoomName?(value: string): void;
}

const CreatePage: React.FunctionComponent<IProps> = (props) => {
  const handleSubmit = (evt: React.FormEvent) => {
    evt.preventDefault();
  };

  const handleClick = () => {
    const roomId = Math.round(Math.random() * (1000 - 1) + 1);
    let name: string = (document.getElementById('name') as HTMLInputElement).value;
    let rName: string = (document.getElementById('rName') as HTMLInputElement).value;
    props.onAddAuthentication && props.onAddAuthentication();
    props.onAddName && props.onAddName(name);
    props.onAddRoomName && props.onAddRoomName(rName);
    props.history.push(`${RoutePath.MAIN}/${roomId}`);
  };

  props.isShowUser && props.onHideUser && props.onHideUser();

  return <main className="main">
    <form action={'POST'} onSubmit={handleSubmit} className={'main__content'}>
      <span className="main__tagline">{'Let\'s start!'}</span>
      <h2 className="main__title">{'Create the room:'}</h2>
      {values.map((array) => {
        return <MainLabel key={array.name} name={array.name} title={array.label} placeHolder={array.placeHolder} id={array.id}/>;
      })}
      <Button className={'main__button'} value={'Enter'} onClick={handleClick}/>
    </form>
  </main>;
};

export default withRouter(CreatePage);
