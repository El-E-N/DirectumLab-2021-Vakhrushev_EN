import * as React from 'react';
import {RouteComponentProps} from 'react-router';
import {withRouter} from 'react-router-dom';
import {RoutePath} from '../../routes';
import MainLabel from '../main__label/main__label';
import Button from '../button/button';
import './invite-page.css';

interface IMatchParams {
  id: string;
}

const values = [
  {label: 'User name', placeHolder: 'Enter your name', name: 'userName', id: 'invite-name'}
];

interface IProps extends RouteComponentProps<IMatchParams> {
  onHideUser?(): void;
  isShowUser?: boolean;
  onAddAuthentication?(): void;
  // eslint-disable-next-line no-unused-vars
  onAddName?(value: string): void;
}

const InvitePage: React.FunctionComponent<IProps> = (props) => {
  const handleSubmit = (evt: React.FormEvent) => {
    evt.preventDefault();
    let name: string = (document.getElementById('invite-name') as HTMLInputElement).value;
    props.onAddAuthentication && props.onAddAuthentication();
    props.onAddName && props.onAddName(name);
    props.history.push(`${RoutePath.MAIN}/${props.match.params.id}`);
  };

  props.isShowUser && props.onHideUser && props.onHideUser();

  return <main className="main">
    <form action={'POST'} onSubmit={handleSubmit} className={'main__content invite'}>
      <span className="main__tagline">{'Let\'s start!'}</span>
      <h2 className="main__title">{'Join the room:'}</h2>
      {values.map((array) => {
        return <MainLabel key={array.name} name={array.name} title={array.label} placeHolder={array.placeHolder} id={array.id}/>;
      })}
      <Button className={'main__button'} value={'Enter'}/>
    </form>
  </main>;
};

export default withRouter(InvitePage);
