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
  // eslint-disable-next-line no-unused-vars
  onSubmit(name: string, rName: string): void;
  onClear(): void;
  name?: string;
}

const CreatePage: React.FunctionComponent<IProps> = (props) => {
  const handleSubmit = (evt: React.FormEvent) => {
    evt.preventDefault();
    let name = ((evt.target as Element).children.item(2)!.children.namedItem('userName') as HTMLInputElement).value;
    let rName = ((evt.target as Element).children.item(3)!.children.namedItem('roomName') as HTMLInputElement).value;
    const roomId = Math.round(Math.random() * (1000 - 1) + 1);
    props.onSubmit(name, rName);
    name !== undefined && rName !== undefined && name !== '' && rName !== '' && props.history.push(`${RoutePath.MAIN}/${roomId}`);
  };

  props.name && props.onClear();

  return <main className="main">
    <form action={'POST'} onSubmit={handleSubmit} className={'main__content'}>
      <span className="main__tagline">{'Let\'s start!'}</span>
      <h2 className="main__title">{'Create the room:'}</h2>
      {values.map((value) => {
        return <MainLabel key={value.name} name={value.name} title={value.label} placeHolder={value.placeHolder}/>;
      })}
      <Button className={'main__button'} value={'Enter'}/>
    </form>
  </main>;
};

export default withRouter(CreatePage);
