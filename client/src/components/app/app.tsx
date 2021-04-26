import * as React from 'react';
import {Switch, Route} from 'react-router-dom';
import InvitePage from '../invite-page/invite-page';
import MainPage from '../main-page/main-page';
import CreatePage from '../create-page/create-page';
import NoMatchPage from '../no-match-page/no-match-page';
import Header from '../header/header';
import Footer from '../footer/footer';
import {RoutePath} from '../../routes';
import MiddleOpacity from '../middle-opacity/middle-opacity';
import Modal from '../modal/modal';

interface IProps {
  roomName: string,
  name: string,
}

interface IState {
  userVisibility: boolean;
  viewModal: boolean;
}

export class App extends React.Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);
    this.state = {
      userVisibility: false,
      viewModal: false,
    };
    this.handleUserVisibilityTrue = this.handleUserVisibilityTrue.bind(this);
    this.handleUserVisibilityFalse = this.handleUserVisibilityFalse.bind(this);
    this.handleShowModal = this.handleShowModal.bind(this);
    this.handleHideModal = this.handleHideModal.bind(this);
  }

  public handleUserVisibilityTrue() {
    this.setState({
      userVisibility: true,
    });
  }

  public handleUserVisibilityFalse() {
    this.setState({
      userVisibility: false,
    });
  }

  public handleShowModal() {
    this.setState({
      viewModal: true,
    });
  }

  public handleHideModal() {
    this.setState({
      viewModal: false,
    });
  }

  render() {
    return <React.Fragment>
      <Header userVisibility={this.state.userVisibility}/>
      <Switch>
        <Route path={RoutePath.INDEX} exact={true} render={() =>
          <CreatePage
            onHideUser={this.handleUserVisibilityFalse}
            isShowUser={this.state.userVisibility}
          />
        }/>
        <Route path={`${RoutePath.MAIN}/:id`} exact={true} render={() =>
          <MainPage
            roomName={this.props.roomName}
            name={this.props.name}
            onShowModal={this.handleShowModal}
            onShowUser={this.handleUserVisibilityTrue}
          />
        }/>
        <Route path={`${RoutePath.INVITE}/:id`} exact={true} render={() =>
          <InvitePage
            onHideUser={this.handleUserVisibilityTrue}
            isShowUser={this.state.userVisibility}
          />
        }/>
        <Route component={NoMatchPage}/>
      </Switch>
      <Footer/>
      {this.state.viewModal && <React.Fragment>
        <MiddleOpacity/>
        <Modal onHideModal={this.handleHideModal}/>
      </React.Fragment>}
    </React.Fragment>;
  }
}

export default App;
