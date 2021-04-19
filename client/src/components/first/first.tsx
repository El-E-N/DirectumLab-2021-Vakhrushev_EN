import * as React from 'react';
import Header from '../header/header';
import Main from '../main/main';
import Footer from '../footer/footer';

const values = [['User name', 'Enter your name'], ['Room name', 'Enter room name']];

const First: React.FunctionComponent = () => {
  return <React.Fragment>
    <Header />
    <Main mainTitle={'Create the room:'} values={values} />
    <Footer />
  </React.Fragment>;
};

export default First;
