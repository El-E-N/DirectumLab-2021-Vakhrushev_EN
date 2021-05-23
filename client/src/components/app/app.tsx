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

export const App: React.FunctionComponent = () => {
  return <React.Fragment>
    <Header/>
    <Switch>
      <Route path={RoutePath.INDEX} exact={true} component={CreatePage}/>
      <Route path={`${RoutePath.MAIN}/:hash`} exact={true} component={MainPage}/>
      <Route path={`${RoutePath.INVITE}/:hash`} exact={true} component={InvitePage}/>
      <Route component={NoMatchPage}/>
    </Switch>
    <Footer/>
    <MiddleOpacity/>
    <Modal/>
  </React.Fragment>;
};

export default App;
