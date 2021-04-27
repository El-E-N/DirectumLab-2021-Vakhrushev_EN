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
  userVisibility: boolean;
  viewModal: boolean;
  roomName: string;
  name: string;
  isAuthentication: boolean;
}

export class App extends React.Component<any, IState> {
  constructor(props: any) {
    super(props);
    this.state = {
      userVisibility: false,
      viewModal: false,
      roomName: '',
      name: '',
      isAuthentication: false,
    };
    this.handleUserVisibilityTrue = this.handleUserVisibilityTrue.bind(this);
    this.handleUserVisibilityFalse = this.handleUserVisibilityFalse.bind(this);
    this.handleShowModal = this.handleShowModal.bind(this);
    this.handleHideModal = this.handleHideModal.bind(this);
    this.handleAddAuthentication = this.handleAddAuthentication.bind(this);
    this.handleSetName = this.handleSetName.bind(this);
    this.handleSetRoomName = this.handleSetRoomName.bind(this);
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

  public handleAddAuthentication() {
    this.setState({
      isAuthentication: true,
    });
  }

  public handleSetName(newName: string) {
    this.setState({
      name: newName,
    });
  }

  public handleSetRoomName(rName: string) {
    this.setState({
      roomName: rName,
    });
  }

  render() {
    return <React.Fragment>
      <Header userVisibility={this.state.userVisibility} name={this.state.name}/>
      <Switch>
        <Route path={RoutePath.INDEX} exact={true} render={() =>
          <CreatePage
            onHideUser={this.handleUserVisibilityFalse}
            isShowUser={this.state.userVisibility}
            onAddAuthentication={this.handleAddAuthentication}
            onAddName={this.handleSetName}
            onAddRoomName={this.handleSetRoomName}
          />
        }/>
        <Route path={`${RoutePath.MAIN}/:id`} exact={true} render={() =>
          <MainPage
            roomName={this.state.roomName}
            name={this.state.name}
            onShowModal={this.handleShowModal}
            onShowUser={this.handleUserVisibilityTrue}
            isAuthentication={this.state.isAuthentication}
          />
        }/>
        <Route path={`${RoutePath.INVITE}/:id`} exact={true} render={() =>
          <InvitePage
            onHideUser={this.handleUserVisibilityFalse}
            isShowUser={this.state.userVisibility}
            onAddAuthentication={this.handleAddAuthentication}
            onAddName={this.handleSetName}
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
