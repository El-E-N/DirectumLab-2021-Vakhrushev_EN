import * as React from 'react';
import Header from '../header/header';
import Room from '../room/room';
import Footer from '../footer/footer';

const Planning: React.FunctionComponent = () => {
  return <React.Fragment>
    <Header addUser={true}/>
    <Room/>
    <Footer />
  </React.Fragment>;
};

export default Planning;
