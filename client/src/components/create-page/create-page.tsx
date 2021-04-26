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

interface IProps extends RouteComponentProps {
  onHideUser?(): void;
  isShowUser?: boolean;
}

const CreatePage: React.FunctionComponent<IProps> = (props) => {
  const handleSubmit = (evt: React.FormEvent) => {
    evt.preventDefault();
  };

  const handleClick = () => {
    const roomId = Math.round(Math.random() * (1000 - 1) + 1);
    props.history.push(`${RoutePath.MAIN}/${roomId}`);
  };

  props.isShowUser && props.onHideUser && props.onHideUser();

  return <main className="main">
    <form action={'POST'} onSubmit={handleSubmit} className={'main__content'}>
      <span className="main__tagline">{'Let\'s start!'}</span>
      <h2 className="main__title">{'Create the room:'}</h2>
      {values.map((array) => {
        return <MainLabel key={array.name} name={array.name} title={array.label} placeHolder={array.placeHolder} />;
      })}
      <Button className={'main__button'} value={'Enter'} onClick={handleClick}/>
    </form>
  </main>;
};

export default withRouter(CreatePage);
