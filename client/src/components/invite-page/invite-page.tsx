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
  {label: 'User name', placeHolder: 'Enter your name', name: 'userName'}
];

interface IProps extends RouteComponentProps<IMatchParams> {
  onClick?(): void;
}

const InvitePage: React.FunctionComponent<IProps> = (props) => {
  const handleSubmit = (evt: React.FormEvent) => {
    evt.preventDefault();
    props.history.push(`${RoutePath.MAIN}/${props.match.params.id}`);
    props.onClick && props.onClick();
  };

  return <main className="main">
    <form action={'POST'} onSubmit={handleSubmit} className={'main__content invite'}>
      <span className="main__tagline">{'Let\'s start!'}</span>
      <h2 className="main__title">{'Join the room:'}</h2>
      {values.map((array) => {
        return <MainLabel key={array.name} name={array.name} title={array.label} placeHolder={array.placeHolder} />;
      })}
      <Button className={'main__button'} value={'Enter'}/>
    </form>
  </main>;
};

export default withRouter(InvitePage);
