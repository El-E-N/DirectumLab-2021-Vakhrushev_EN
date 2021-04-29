import * as React from 'react';
import userImage from '../../images/userIcon.svg';
import Button from '../button/button';
import {withRouter, RouteComponentProps, Link} from 'react-router-dom';
import {RoutePath} from '../../routes';
import './user.css';

interface IMatchParams {
  id: string;
}

interface IState {
  showUserMenu: boolean;
}

interface IProps extends RouteComponentProps<IMatchParams> {
  name?: string;
}

class User extends React.Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);
    this.state = {
      showUserMenu: false,
    };
    this.handleShowOrHide = this.handleShowOrHide.bind(this);
  }

  public handleShowOrHide() {
    this.setState({
      showUserMenu: !this.state.showUserMenu,
    });
  }

  private userButton = (name: string) => {
    return <React.Fragment>
      <span className="user__name">{name}</span>
      <img className="user__image" alt={'userImage'} src={userImage}/>
    </React.Fragment>;
  }

  render() {
    return <div className="user">
      <Button className={'user__button'} value={this.userButton(this.props.name || '')} onClick={this.handleShowOrHide}/>
      {this.state.showUserMenu && <div className="user__menu-wrapper">
        <div className="rhombus"/>
        <div className="user__menu">
          <Link to={`${RoutePath.INVITE}/${this.props.match.params.id}`} className="sign-out">Sign Out</Link>
        </div>
      </div>}
    </div>;
  }
}

export default withRouter(User);
