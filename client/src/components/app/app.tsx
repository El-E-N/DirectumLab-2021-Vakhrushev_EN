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
  roomId: string | null;
}

export class App extends React.Component<unknown, IState> {
  constructor() {
    super(null);
    this.state = {
      viewModal: false,
      roomId: null,
    };
    this.handleShowModal = this.handleShowModal.bind(this);
    this.handleHideModal = this.handleHideModal.bind(this);
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
      <Header/>
      <Switch>
        <Route path={RoutePath.INDEX} exact={true} component={CreatePage}/>
        <Route path={`${RoutePath.MAIN}/:hash`} exact={true} render={() =>
          <MainPage onShowModal={this.handleShowModal}/>
        }/>
        <Route path={`${RoutePath.INVITE}/:hash`} exact={true} component={InvitePage}/>
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
