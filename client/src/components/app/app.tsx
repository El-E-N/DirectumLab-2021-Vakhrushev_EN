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

interface IState {
  viewModal: boolean;
  roomName: string;
  name?: string;
  isAuthentication: boolean;
}

export class App extends React.Component<any, IState> {
  constructor(props: any) {
    super(props);
    this.state = {
      viewModal: false,
      roomName: '',
      isAuthentication: false,
    };
    this.handleShowModal = this.handleShowModal.bind(this);
    this.handleHideModal = this.handleHideModal.bind(this);
    this.handleAddCreateStates = this.handleAddCreateStates.bind(this);
    this.handleAddInviteStates = this.handleAddInviteStates.bind(this);
    this.handleClearCreate = this.handleClearCreate.bind(this);
    this.handleClearInvite = this.handleClearInvite.bind(this);
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

  public handleAddCreateStates(newName: string, rName: string) {
    this.setState({
      roomName: rName,
      name: newName,
      isAuthentication: true,
    });
  }

  public handleAddInviteStates(newName: string) {
    this.setState({
      name: newName,
      isAuthentication: true,
    });
  }

  public handleClearCreate() {
    this.setState({
      name: undefined,
      roomName: '',
    });
  }

  public handleClearInvite() {
    this.setState({
      name: undefined,
    });
  }

  render() {
    return <React.Fragment>
      <Header name={this.state.name}/>
      <Switch>
        <Route path={RoutePath.INDEX} exact={true} render={() =>
          <CreatePage
            onSubmit={this.handleAddCreateStates}
            name={this.state.name}
            onClear={this.handleClearCreate}
          />
        }/>
        <Route path={`${RoutePath.MAIN}/:id`} exact={true} render={() =>
          <MainPage
            roomName={this.state.roomName}
            name={this.state.name}
            onShowModal={this.handleShowModal}
            isAuthentication={this.state.isAuthentication}
          />
        }/>
        <Route path={`${RoutePath.INVITE}/:id`} exact={true} render={() =>
          <InvitePage
            onSubmit={this.handleAddInviteStates}
            name={this.state.name}
            onClear={this.handleClearInvite}
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
