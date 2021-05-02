import * as React from 'react';
import {RouteComponentProps} from 'react-router';
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
  // eslint-disable-next-line no-unused-vars
  addNewUser(id: string, name: string): void;
  removeUser(): void;
}

class InvitePageView extends React.Component<IProps, {}> {
  constructor(props: IProps) {
    super(props);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.props.removeUser();
  }

  handleSubmit(evt: React.FormEvent) {
    evt.preventDefault();
    let name = ((evt.target as Element).children.item(2)!.children.namedItem('userName') as HTMLInputElement).value;
    if (name !== undefined && name !== '') {
      const userId = `${Math.round(Math.random() * (1000 - 1) + 1)}`;
      this.props.addNewUser(userId, name);
      this.props.history.push(`${RoutePath.MAIN}/${this.props.match.params.id}`);
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
