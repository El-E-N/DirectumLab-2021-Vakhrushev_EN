import * as React from 'react';
import Header from '../header/header';
import Main from '../main/main';
import Footer from '../footer/footer';

export const values = [['User name', 'Enter your name']];

const Invite: React.FunctionComponent = () => {
  return <React.Fragment>
    <Header />
    <Main className={'invite'} mainTitle={'Join the room:'} values={values} />
    <Footer />
  </React.Fragment>;
};

export default Invite;
